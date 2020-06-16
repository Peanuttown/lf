using Godot;
namespace tzzGodot{

    public static class Scene{
        static public void change_scene(){
            //todo
        }
        static public object get_scene_param(){
            //todo
            return 1;
        }
        static public PackedScene load_scene_resource(string path){
            return (PackedScene)ResourceLoader.Load(path);
        }
    }

}