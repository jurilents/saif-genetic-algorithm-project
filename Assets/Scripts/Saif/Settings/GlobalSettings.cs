using Saif.Core;
using Saif.World.VirtualMap;
using UnityEngine;

namespace Saif.Settings
{
    public static class GlobalSettings
    {
        public static Size Size { get; set; }
        public static AnimationCurve MineralsDistFunc { get; set; }
        public static AnimationCurve SunlightDistFunc { get; set; }


        private static readonly float MineralsDistOffset = Random.Range(10f, 700f) * 100f;
        private static readonly float SunlightDistOffset = Random.Range(-10f, 400f) * 100f;

        public static float GetSunlightValue(Vector3Int position)
        {
            float value = SunlightDistFunc.Evaluate(Size.Height);
            return value * Noiser.GetNoise(position, 0.25f, MineralsDistOffset);
        }

        public static float GetMineralsValue(Vector3Int position)
        {
            float value = MineralsDistFunc.Evaluate(Size.Height);
            return value * Noiser.GetNoise(position, 0.25f, SunlightDistOffset);
        }
    }
}