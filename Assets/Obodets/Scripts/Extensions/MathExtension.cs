namespace Obodets.Scripts.Extensions
{
    public static class MathExtension
    {
        public static float CalculateRatio(this float a, float b)
        {
            var ratio = a / b;
            return ratio < 1 ? ratio : 1 / ratio;
        }
    }
}