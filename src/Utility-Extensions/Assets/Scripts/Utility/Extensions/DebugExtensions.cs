using UnityEngine;

namespace PXELDAR
{
    public static class DebugExtensions
    {
        //===================================================================================

        public static void DrawCube(Vector3 center, float length,
                Color? color = null, float duration = 0.0f, bool depthTest = true)
        {
            float hLength = length / 2;
            DrawRectangularPrism(center + new Vector3(hLength, hLength, hLength),
                center - new Vector3(hLength, hLength, hLength), color ?? Color.white, duration, depthTest);
        }

        //===================================================================================

        public static void DrawRectangularPrism(Vector3 p1, Vector3 p2,
            Color? color = null, float duration = 0.0f, bool depthTest = true)
        {
            float h = p2.y - p1.y;
            float w = p2.x - p1.x;
            float d = p2.z - p1.z;

            Debug.DrawLine(p1, p1 + Vector3.right * w, color ?? Color.white, duration, depthTest);
            Debug.DrawLine(p1, p1 + Vector3.forward * d, color ?? Color.white, duration, depthTest);
            Debug.DrawLine(p1, p1 + Vector3.up * h, color ?? Color.white, duration, depthTest);
            Debug.DrawLine(p1 + Vector3.up * h, p1 + Vector3.up * h + Vector3.right * w, color ?? Color.white, duration,
                depthTest);
            Debug.DrawLine(p1 + Vector3.up * h, p1 + Vector3.up * h + Vector3.forward * d, color ?? Color.white,
                duration,
                depthTest);
            Debug.DrawLine(p1 + Vector3.right * w, p1 + Vector3.right * w + Vector3.up * h, color ?? Color.white,
                duration,
                depthTest);

            Debug.DrawLine(p2, p2 - Vector3.right * w, color ?? Color.white, duration, depthTest);
            Debug.DrawLine(p2, p2 - Vector3.forward * d, color ?? Color.white, duration, depthTest);
            Debug.DrawLine(p2, p2 - Vector3.up * h, color ?? Color.white, duration, depthTest);
            Debug.DrawLine(p2 - Vector3.up * h, p2 - Vector3.up * h - Vector3.right * w, color ?? Color.white, duration,
                depthTest);
            Debug.DrawLine(p2 - Vector3.up * h, p2 - Vector3.up * h - Vector3.forward * d, color ?? Color.white,
                duration,
                depthTest);
            Debug.DrawLine(p2 - Vector3.right * w, p2 - Vector3.right * w - Vector3.up * h, color ?? Color.white,
                duration,
                depthTest);
        }

        //===================================================================================

        public static void DrawRect(Rect rect, Color col)
        {
            Vector3 pos = new Vector3(rect.x + rect.width / 2, rect.y + rect.height / 2, 0.0f);
            Vector3 scale = new Vector3(rect.width, rect.height, 0.0f);

            DrawRect(pos, col, scale);
        }

        //===================================================================================

        public static void DrawRect(Vector3 pos, Color col, Vector3 scale)
        {
            Vector3 halfScale = scale * 0.5f;

            Vector3[] points = new Vector3[]
            {
            pos + new Vector3(halfScale.x,      halfScale.y,    halfScale.z),
            pos + new Vector3(-halfScale.x,     halfScale.y,    halfScale.z),
            pos + new Vector3(-halfScale.x,     -halfScale.y,   halfScale.z),
            pos + new Vector3(halfScale.x,      -halfScale.y,   halfScale.z),
            };

            Debug.DrawLine(points[0], points[1], col);
            Debug.DrawLine(points[1], points[2], col);
            Debug.DrawLine(points[2], points[3], col);
            Debug.DrawLine(points[3], points[0], col);
        }

        //===================================================================================

        public static void DrawPoint(Vector3 pos, Color col, float scale)
        {
            Vector3[] points = new Vector3[]
            {
            pos + (Vector3.up * scale),
            pos - (Vector3.up * scale),
            pos + (Vector3.right * scale),
            pos - (Vector3.right * scale),
            pos + (Vector3.forward * scale),
            pos - (Vector3.forward * scale)
            };

            Debug.DrawLine(points[0], points[1], col);
            Debug.DrawLine(points[2], points[3], col);
            Debug.DrawLine(points[4], points[5], col);

            Debug.DrawLine(points[0], points[2], col);
            Debug.DrawLine(points[0], points[3], col);
            Debug.DrawLine(points[0], points[4], col);
            Debug.DrawLine(points[0], points[5], col);

            Debug.DrawLine(points[1], points[2], col);
            Debug.DrawLine(points[1], points[3], col);
            Debug.DrawLine(points[1], points[4], col);
            Debug.DrawLine(points[1], points[5], col);

            Debug.DrawLine(points[4], points[2], col);
            Debug.DrawLine(points[4], points[3], col);
            Debug.DrawLine(points[5], points[2], col);
            Debug.DrawLine(points[5], points[3], col);
        }

        //===================================================================================

        public static void DrawCircle(Vector3 center, Vector3 normal, float radius,
            Color? color = null, float duration = 0.0f, bool depthTest = true, int resolution = 16)
        {
            Vector3 cross = Vector3.up != normal ? Vector3.up : Vector3.right;
            Vector3 start = Vector3.Cross(normal, cross).normalized * radius;
            Quaternion r1, r2;
            for (int i = 0; i < resolution; i++)
            {
                r1 = Quaternion.AngleAxis(360f / resolution * i, normal);
                r2 = Quaternion.AngleAxis(360f / resolution * (i + 1), normal);
                Debug.DrawLine(center + r1 * start, center + r2 * start, color ?? Color.white, duration, depthTest);
            }
        }

        //===================================================================================

        public static void DrawWireSphere(Vector3 center, float radius,
            Color? color = null, float duration = 0.0f, bool depthTest = true, int resolution = 16)
        {
            DrawCircle(center, Vector3.forward, radius, color, duration, depthTest, resolution);
            DrawCircle(center, Vector3.right, radius, color, duration, depthTest, resolution);
            DrawCircle(center, Vector3.up, radius, color, duration, depthTest, resolution);
        }

        //===================================================================================

        public static void DrawMesh(Mesh mesh, Vector3 position, Color? color = null,
            Vector3? scale = null, Quaternion? rotation = null, float duration = 0.0f, bool depthTest = true)
        {
            Vector3 p1, p2, p3;
            for (int i = 0; i < mesh.triangles.Length; i += 3)
            {
                p1 = mesh.vertices[mesh.triangles[i + 0]];
                p2 = mesh.vertices[mesh.triangles[i + 1]];
                p3 = mesh.vertices[mesh.triangles[i + 2]];
                p1 = (rotation ?? Quaternion.identity) * p1;
                p2 = (rotation ?? Quaternion.identity) * p2;
                p3 = (rotation ?? Quaternion.identity) * p3;
                p1.Scale(scale ?? Vector3.one);
                p2.Scale(scale ?? Vector3.one);
                p3.Scale(scale ?? Vector3.one);
                p1 += position;
                p2 += position;
                p3 += position;

                Debug.DrawLine(p1, p2, color ?? Color.white, duration, depthTest);
                Debug.DrawLine(p2, p3, color ?? Color.white, duration, depthTest);
                Debug.DrawLine(p3, p1, color ?? Color.white, duration, depthTest);
            }
        }

        //===================================================================================

    }
}