using System.Collections.Generic;
using UnityEngine;

namespace PXELDAR
{
    public static class ColorExtensions
    {
        //===================================================================================

        public static Color Lerp(Color c1, Color c2, float value)
        {
            if (value > 1.0f)
                return c2;
            if (value < 0.0f)
                return c1;
            return new Color(c1.r + (c2.r - c1.r) * value,
                             c1.g + (c2.g - c1.g) * value,
                             c1.b + (c2.b - c1.b) * value,
                             c1.a + (c2.a - c1.a) * value);
        }

        //===================================================================================

        public static Color MakeRandomColor(this Color color, float minClamp = 0.5f)
        {
            Vector3 randCol = UnityEngine.Random.onUnitSphere * 3;
            randCol.x = Mathf.Clamp(randCol.x, minClamp, 1f);
            randCol.y = Mathf.Clamp(randCol.y, minClamp, 1f);
            randCol.z = Mathf.Clamp(randCol.z, minClamp, 1f);

            return new Color(randCol.x, randCol.y, randCol.z, 1f);
        }
        //===================================================================================

        public static Color AddToSaturation(this Color _col, float changeAmount)
        {
            float H, S, V;
            Color.RGBToHSV(_col, out H, out S, out V);
            S = S + changeAmount / 100f;
            if (S < 0) S = 0;
            if (S > 1) S = 1;
            return Color.HSVToRGB(H, S, V);
        }

        //===================================================================================

        public static Color ChangeSaturationPercent(this Color _col, float changePercent)
        {
            float H, S, V;
            Color.RGBToHSV(_col, out H, out S, out V);
            S = S * changePercent / 100f;
            if (S < 0) S = 0;
            if (S > 1) S = 1;
            return Color.HSVToRGB(H, S, V);
        }

        //===================================================================================

        public static Color ChangeSaturationTo(this Color _col, float saturation)
        {
            float H, S, V;
            Color.RGBToHSV(_col, out H, out S, out V);
            S = saturation;
            return Color.HSVToRGB(H, S, V);
        }

        //===================================================================================

        public static Color ChangeSaturationToHalf(this Color _col)
        {
            float H, S, V;
            Color.RGBToHSV(_col, out H, out S, out V);
            S /= 2f;
            return Color.HSVToRGB(H, S, V);
        }

        //===================================================================================

        public static Color ChangeBrightnessTo(this Color _col, float brightness)
        {
            float H, S, V;
            Color.RGBToHSV(_col, out H, out S, out V);
            V = brightness;
            return Color.HSVToRGB(H, S, V);
        }

        //===================================================================================

    }
}