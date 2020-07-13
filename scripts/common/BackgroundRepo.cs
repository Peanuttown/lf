using System.Collections.Generic;
using System;
namespace tzzGodot{
    public class BackgroundRepo{
        public BackgroundRepo(){
            this.repos = new Dictionary<string, string>();
        }
        public string selected_bg;
        public Godot.Node get_selected_bg(){
            if (this.selected_bg==null){
                if (this.repos.Count ==0){
                    tzzGodot.Except.Throw("未注册过地图资源");
                }
                //pesudo random
                foreach (var item in this.repos)
                {
                    var scene = Scene.load_scene_resource(item.Value);
                    return scene.Instance();
                }
            }
            return Scene.load_scene_resource(this.repos[this.selected_bg]).Instance();
        }
        public Dictionary<string,string> repos;
        public void register_repo(string id,string path){
            if (this.repos.ContainsKey(id)){
                throw(new System.Exception(String.Format("{0} has registered",id)));
            }
            this.repos.Add(id,path);
        }
    }
}