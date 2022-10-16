using UnityEngine;

namespace Saif.Core
{
    public struct MapCellUpdateEvent
    {
        public Vector3Int Position { get; }
        public Color Color { get; }

        public MapCellUpdateEvent(Vector2Int position, Color color)
            : this(position.x, position.y, color) { }

        public MapCellUpdateEvent(int x, int y, Color color)
        {
            Position = new Vector3Int(x, y, 0);
            Color = color;
        }
    }
}