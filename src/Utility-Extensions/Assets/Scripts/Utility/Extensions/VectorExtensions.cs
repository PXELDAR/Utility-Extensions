using System;
using UnityEngine;

namespace PXELDAR
{
    public static class VectorExtensions
    {
        //===================================================================================

        public static Vector2 ConvertV3ToV2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        //===================================================================================

        public static Vector2 SetX(this Vector2 vector, float x)
        {
            return new Vector2(x, vector.y);
        }

        //===================================================================================

        public static Vector2 SetY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, y);
        }

        //===================================================================================

        public static Vector2 AddX(this Vector2 vector, float x)
        {
            return new Vector2(vector.x + x, vector.y);
        }

        //===================================================================================

        public static Vector2 AddY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, vector.y + y);
        }

        //===================================================================================

        public static Vector2 Normalize(this Vector2 vector, float magnitude)
        {
            return vector.normalized * magnitude;
        }

        //===================================================================================

        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        //===================================================================================

        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        //===================================================================================

        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        //===================================================================================

        public static Vector3 AddX(this Vector3 vector, float x)
        {
            return new Vector3(vector.x + x, vector.y, vector.z);
        }

        //===================================================================================

        public static Vector3 AddY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, vector.y + y, vector.z);
        }

        //===================================================================================

        public static Vector3 AddZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, vector.z + z);
        }

        //===================================================================================

        public static Vector3 Normalize(this Vector3 vector, float magnitude = 1)
        {
            return vector.normalized * magnitude;
        }

        //===================================================================================

        public static Vector3 GetClosestVector3From(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            float minDistance = Vector3.Distance(vector, otherVectors[0]);
            Vector3 minVector = otherVectors[0];
            for (int i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }

        //===================================================================================

        public static Vector2 GetClosestVector2From(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            float minDistance = Vector2.Distance(vector, otherVectors[0]);
            Vector2 minVector = otherVectors[0];
            for (int i = otherVectors.Length - 1; i > 0; i--)
            {
                float newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }

        //===================================================================================

        public static float GetClosestDistanceFrom(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            float minDistance = Vector3.Distance(vector, otherVectors[0]);
            for (int i = otherVectors.Length - 1; i > 0; i--)
            {
                float newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                    minDistance = newDistance;
            }
            return minDistance;
        }

        //===================================================================================

        public static float GetClosestDistanceFrom(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            float minDistance = Vector2.Distance(vector, otherVectors[0]);
            for (int i = otherVectors.Length - 1; i > 0; i--)
            {
                float newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                    minDistance = newDistance;
            }
            return minDistance;
        }

        //===================================================================================

        public static Vector3 GetFarthestVector3From(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            float maxDistance = Vector3.Distance(vector, otherVectors[0]);
            Vector3 maxVector = otherVectors[0];
            for (int i = otherVectors.Length - 1; i > 0; i--)
            {
                float newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    maxVector = otherVectors[i];
                }
            }
            return maxVector;
        }

        //===================================================================================

        public static Vector2 GetFarthestVector2From(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            float maxDistance = Vector2.Distance(vector, otherVectors[0]);
            Vector2 maxVector = otherVectors[0];
            for (int i = otherVectors.Length - 1; i > 0; i--)
            {
                float newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    maxVector = otherVectors[i];
                }
            }
            return maxVector;
        }

        //===================================================================================

        public static float GetFarthestDistanceFrom(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            float maxDistance = Vector3.Distance(vector, otherVectors[0]);
            for (int i = otherVectors.Length - 1; i > 0; i--)
            {
                float newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                    maxDistance = newDistance;
            }
            return maxDistance;
        }

        //===================================================================================

        public static float GetFarthestDistanceFrom(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            float maxDistance = Vector2.Distance(vector, otherVectors[0]);
            for (int i = otherVectors.Length - 1; i > 0; i--)
            {
                float newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                    maxDistance = newDistance;
            }
            return maxDistance;
        }

        //===================================================================================

    }
}