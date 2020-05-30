using Godot;
namespace tzzGodot{
    public class Node25D:Node2D{
        public static Vector2  ToVector2(Vector3 v3){
            return new Vector2(v3.x,v3.y-v3.z);
        }
        static public Vector3 ToVec3(Vector2 vec)
        {
            return new Vector3(vec.x,vec.y,0);
        }
        public float z;
        public bool onGround(){
            return this.z <= 0;
        }
    }
}