using System;
using System.Collections.Concurrent;
using Saif.Core;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Saif.Behaviours
{
    public class MapDrawer : MonoBehaviour
    {
        [SerializeField] private TileBase defaultTilePrefab;
        [SerializeField] private Tilemap tilemap;

        private bool _play;
        private Vector2Int _size;
        private ConcurrentQueue<MapCellUpdateEvent> _updatedCells;

        public bool Play
        {
            get => _play;
            set
            {
                CheckSize(_size);
                _play = value;
            }
        }

        private void Update()
        {
            if (Play)
            {
                while (_updatedCells.Count > 0)
                {
                    if (_updatedCells.TryDequeue(out MapCellUpdateEvent cell))
                        tilemap.SetColor(cell.Position, cell.Color);
                    else break;
                }
            }
        }

        public void SetColorAtPosition(Vector2Int position, Color color)
        {
            _updatedCells.Enqueue(new MapCellUpdateEvent(position, color));
        }

        public void SetColorAtPosition(int x, int y, Color color)
        {
            _updatedCells.Enqueue(new MapCellUpdateEvent(x, y, color));
        }


        public void SetSize(Vector2Int size)
        {
            CheckSize(size);

            for (int y = 0; y < size.y; y++)
            for (int x = 0; x < size.x; x++)
            {
                var position = new Vector3Int(x, y, 0);
                // Display current time on the tilemap
                tilemap.SetTile(position, defaultTilePrefab);
                // Enable ability to change tile color
                tilemap.SetTileFlags(position, TileFlags.None);
            }
        }

        private static void CheckSize(Vector2Int size)
        {
            if (size.x < 1 || size.y < 1)
                throw new ArgumentException("Map size is invalid.");
        }
    }
}