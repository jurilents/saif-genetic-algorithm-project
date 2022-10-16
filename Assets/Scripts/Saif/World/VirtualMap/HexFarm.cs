using System;
using System.Collections.Generic;
using Saif.Behaviours;
using Saif.World.Core;
using UnityEngine;

namespace Saif.World.VirtualMap
{
    public class HexFarm : Farm
    {
        public HexFarm(MapDrawer drawer, Size size)
            : base(drawer, size) { }


        public override IEnumerable<Vector3Int> GetNeighbors(in Vector3Int pos)
        {
            return pos.y % 2 == 0
                ? new List<Vector3Int>
                {
                    new(pos.x - 1, pos.y + 1, BASE_Z),
                    new(pos.x, pos.y + 1, BASE_Z),
                    new(pos.x + 1, pos.y, BASE_Z),
                    new(pos.x, pos.y - 1, BASE_Z),
                    new(pos.x - 1, pos.y - 1, BASE_Z),
                    new(pos.x - 1, pos.y, BASE_Z)
                }
                : new List<Vector3Int>
                {
                    new(pos.x, pos.y + 1, BASE_Z),
                    new(pos.x + 1, pos.y + 1, BASE_Z),
                    new(pos.x + 1, pos.y, BASE_Z),
                    new(pos.x + 1, pos.y - 1, BASE_Z),
                    new(pos.x, pos.y - 1, BASE_Z),
                    new(pos.x - 1, pos.y, BASE_Z)
                };
        }


        public override ICell GetCellByMove(ICell from, in Turn turn)
        {
            Vector3Int pos = from.Position;
            return GetCell(pos.y % 2 == 0
                ? turn.Side switch
                {
                    0 => new Vector3Int(pos.x - 1, pos.y + 1, BASE_Z),
                    1 => new Vector3Int(pos.x, pos.y + 1, BASE_Z),
                    2 => new Vector3Int(pos.x + 1, pos.y, BASE_Z),
                    3 => new Vector3Int(pos.x, pos.y - 1, BASE_Z),
                    4 => new Vector3Int(pos.x - 1, pos.y - 1, BASE_Z),
                    5 => new Vector3Int(pos.x - 1, pos.y, BASE_Z),
                    _ => throw new IndexOutOfRangeException("Turn #" + turn + " was unexpected")
                }
                : turn.Side switch
                {
                    0 => new Vector3Int(pos.x, pos.y + 1, BASE_Z),
                    1 => new Vector3Int(pos.x + 1, pos.y + 1, BASE_Z),
                    2 => new Vector3Int(pos.x + 1, pos.y, BASE_Z),
                    3 => new Vector3Int(pos.x + 1, pos.y - 1, BASE_Z),
                    4 => new Vector3Int(pos.x, pos.y - 1, BASE_Z),
                    5 => new Vector3Int(pos.x - 1, pos.y, BASE_Z),
                    _ => throw new IndexOutOfRangeException("Turn #" + turn + " was unexpected")
                });
        }
    }
}