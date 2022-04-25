using System.Collections.Generic;
using UnityEngine;

namespace Obodets.Scripts.Extensions
{
    public static class ColorExtension
    {
        public static Color CalculateAverageColor(this List<Color> colors)
        {
            Color sumColor = default;

            foreach (var color in colors)
            {
                sumColor += color;
            }
            
            return sumColor / colors.Count;
        }

        public static float CalculateColorDifference(this Color color, Color compared)
        {
            var differenceR = color.r.CalculateRatio(compared.r);
            var differenceG = color.g.CalculateRatio(compared.g);
            var differenceB = color.b.CalculateRatio(compared.b);
            var differenceA = color.a.CalculateRatio(compared.a);
            return (differenceR + differenceG + differenceB + differenceA) / 4;
        }
    }
}