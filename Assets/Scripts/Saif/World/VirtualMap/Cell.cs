using Saif.Settings;
using Saif.World.ArtificialLife;
using Saif.World.Core;
using UnityEngine;

namespace Saif.World.VirtualMap
{
    /// <summary>
    /// Single farm map cell class
    /// </summary>
    public class Cell : ICell
    {
        public Vector3Int Position { get; }

        public CellContentType ContentType { get; private set; }

        public IFarmObject Content { get; private set; }
        public Color Color { get; }

        public float SunModifier { get; }
        public float MineralsModifier { get; }


        public Cell(Vector3Int position, Size? mapSize = null)
        {
            Position = position;
            ContentType = CellContentType.Void;
            Content = null;

            if (mapSize is null)
            {
                SunModifier = 1;
                MineralsModifier = 0;
            }
            else
            {
                SunModifier = GlobalSettings.GetMineralsValue(position);
                MineralsModifier = GlobalSettings.GetSunlightValue(position);
            }
        }

        public bool SetUnit(BioUnit bot)
        {
            throw new System.NotImplementedException();
        }

        public bool Clear()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Set cell content type and bot
        /// </summary>
        /// <param name="contentType">Cell content type enum value</param>
        /// <param name="farmObj">Instance of the bot (if you need)</param>
        public void SetContent(CellContentType contentType, IFarmObject farmObj = null)
        {
            ContentType = contentType;
            Content = farmObj;
        }

        // public bool AdoptNewBot(IBot bot)
        // {
        //     if (ContentType != CellContentType.Void) return false;
        //
        //     bot.Cell.SetContent(CellContentType.Void);
        //     bot.Cell = this;
        //     SetContent(CellContentType.Organism, bot);
        //     return true;
        // }


        // public override string ToString() => $"Cell[x:{Pos.x}, y={Pos.y}] ({Reflection.GetTypeName(ContentType)})";
    }
}