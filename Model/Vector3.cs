using UnityEngine.UI;

namespace Code.BonusGame.Model
{
    public sealed class Vector3
    {
        public float x { get; private set; }
        public float y { get; private set; }
        public float z { get; private set; }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Set(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public void Set(Vector3 v1)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v1.z;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3
            (
                v1.x + v2.x,
                v1.y + v2.y,
                v1.z + v2.z
            );
        }
        
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3
            (
            v1.x - v2.x,
            v1.y - v2.y,
            v1.z - v2.z
            );
        }
    }
}