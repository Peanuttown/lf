using System;
namespace tzzGodot{
    public static class Key{
        public static int KeyDefMoveLeft;

        public static void Load(){
            //move left
            Godot.Collections.Array moveLeftInput =Godot.InputMap.GetActionList(tzzGodot.Input.InputDefLeft);
            foreach (Godot.InputEvent e in moveLeftInput){
                if (e.GetType() == typeof(Godot.InputEventKey)){
                }
            }
        }
    }
}