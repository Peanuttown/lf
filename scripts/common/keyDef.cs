namespace tzzGodot{
    public static class Key{
        public static int KeyDefMoveLeft;
        public static void load(){
            Godot.Collections.Array actions =Godot.InputMap.GetActions();
           System.Console.WriteLine(actions[0]); 
        }
    }
}