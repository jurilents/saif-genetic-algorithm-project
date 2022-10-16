using Saif.World.ArtificialLife;
using Saif.World.Core;
using UnityEngine;

namespace Saif.World.VirtualMap
{
    public interface ICell
    {
        Vector3Int Position { get; }
        IFarmObject Content { get; }
        Color Color { get; }

        bool SetUnit(BioUnit bot);
        bool Clear();

        float SunModifier { get; }
        float MineralsModifier { get; }
    }
}