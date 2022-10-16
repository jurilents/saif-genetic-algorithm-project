using System;
using UnityEngine;

namespace Saif.World.VirtualMap
{
    public struct Size
    {
        public int Width { get; }
        public int Height { get; }

        public bool LoopByX { get; }
        public bool LoopByY { get; }


        public int SquareCount => Width * Height;


        public Size(int w, int h, bool loopX = false, bool loopY = false)
        {
            if (w == 0 || h == 0) throw new ArgumentOutOfRangeException();

            Width = w;
            Height = h;

            LoopByX = loopX;
            LoopByY = loopY;
        }

        public Size(Vector2Int size, bool loopX = false, bool loopY = false)
            : this(size.x, size.y, loopX, loopY) { }
    }
}