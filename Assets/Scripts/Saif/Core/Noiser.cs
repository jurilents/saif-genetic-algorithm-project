using UnityEngine;

namespace Saif.Core
{
    public class Noiser
    {
        public static float GetNoise(Vector3Int pos, float scale = 1, float offset = 0)
        {
            return GetNoise(pos.x, pos.y, scale, offset);
        }

        public static float GetNoise(Vector2Int pos, float scale = 1, float offset = 0)
        {
            return GetNoise(pos.x, pos.y, scale, offset);
        }

        public static float GetNoise(Vector2 pos, float scale = 1, float offset = 0)
        {
            return GetNoise(pos.x, pos.y, scale, offset);
        }

        public static float GetNoise(float x, float y, float scale = 1, float offset = 0)
        {
            return Mathf.PerlinNoise((x + offset) * scale, (y + offset) * scale);
        }
    }
}