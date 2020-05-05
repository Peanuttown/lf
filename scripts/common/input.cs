namespace tzzGodot{
    public class Input{
        public static string InputDefAttack = "attack";
        public static string InputDefJump = "jump";
        public static string InputDefMove = "move";
        public static bool IsAttack(Godot.InputEvent @event){
            return @event.IsAction(Input.InputDefAttack);
        }
        public static bool IsJump(Godot.InputEvent @event){
            return @event.IsAction(Input.InputDefJump);
        }
        public static bool IsMove(Godot.InputEvent @event){
            return @event.IsAction(Input.InputDefMove);
        }
    }
}