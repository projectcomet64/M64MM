using System;
using System.Drawing;
using System.Numerics;

namespace M64MM2.Helpers {
    public static class VectorHelpers {
        /// <summary>
        /// Projects a 3d point to a 2d plane using a weak perspective projection (Ortho + scaling factor) technique.
        /// </summary>
        /// <param name="vec">The vector to project</param>
        /// <param name="fov">The field of view (Z scaling factor) to use</param>
        /// <returns>A projected Vector2</returns>
        public static Vector2 WeakPerspective(Vector3 vec, float fov)
        {
            // Weak perspective projection
            return new Vector2(vec.X * (fov / vec.Z), vec.Y * (fov / vec.Z));
        }

        public static Vector3 ToVector3(this Point pt) {
            return new Vector3(pt.X, pt.Y, 1);
        }

        public static PointF ToPointF(this Vector2 vec) {
            return new PointF(vec.X, vec.Y);
        }
    }
}