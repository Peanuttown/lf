using Godot;
namespace tzzGodot{
    public class Screen{
        public static Vector2 get_resolution(Node node){
            return ((Godot.Viewport)node.GetNode("/root")).Size;
        }
    }
}