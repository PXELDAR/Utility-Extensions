using System.Collections.Generic;
using UnityEngine;

namespace PXELDAR
{
    public static class BezierInterpolations
    {
        public static class Quadratic
        {
            //===================================================================================

            public static Vector2 CalculateBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2)
            {
                float u = 1f - t;
                float t2 = t * t;
                float u2 = u * u;

                Vector2 p = p0 * u2;

                p += p1 * 2 * u * t;
                p += p2 * t2;

                return p;
            }

            //===================================================================================

            public static IEnumerable<Vector2> CalculateBezierCurvePoints(int segmentsCount, Vector2 p0, Vector2 p1, Vector2 p2)
            {
                float convertedCount = (float)segmentsCount;

                for (int i = 0; i <= segmentsCount; i++)
                {
                    yield return CalculateBezierPoint(i / convertedCount, p0, p1, p2);
                }
            }

            //===================================================================================
        }

        public static class Cubic
        {
            //===================================================================================

            public static Vector2 CalculateBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
            {
                float u = 1f - t;
                float t2 = t * t;
                float u2 = u * u;
                float u3 = u2 * u;
                float t3 = t2 * t;
                Vector2 p = p0 * u3;

                p += p1 * 3 * u2 * t;
                p += p2 * 3 * u * t2;
                p += p3 * t3;

                return p;
            }

            //===================================================================================

            public static IEnumerable<Vector2> CalculateBezierCurvePoints(int segmentsCount, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
            {
                float convertedCount = (float)segmentsCount;

                for (int i = 0; i <= segmentsCount; i++)
                {
                    yield return CalculateBezierPoint(i / convertedCount, p0, p1, p2, p3);
                }
            }

            //===================================================================================

        }
    }
}