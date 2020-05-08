namespace tzzGodot{
    public class Input{
        public static string InputDefAttack = "attack";
        public static string InputDefJump = "jump";
        public static string InputDefMove = "move";
        public static string InputDefDown = "ui_down";
        public static string InputDefUp = "ui_up";
        public static string InputDefLeft = "ui_left";
        public static string InputDefRight = "ui_right";

        public static bool IsAttack(Godot.InputEvent @event){
            return Godot.Input.IsActionJustPressed(Input.InputDefAttack);
        }
        public static bool IsJump(Godot.InputEvent @event){
            return @event.IsAction(Input.InputDefJump);
        }
        public static bool IsMove(Godot.InputEvent @event){
            return @event.IsAction(Input.InputDefMove);
        }
        public static bool IsPressed(string action){
            return Godot.Input.IsActionPressed(action);
        }
        public static bool IsKeyPressed(Godot.KeyList key){
            return Godot.Input.IsKeyPressed((int)(key));
        }
        public static bool IsPressedMove(){
            return Input.IsPressed(InputDefMove) |
             Input.IsPressed(InputDefLeft) |
             Input.IsPressed(Input.InputDefRight) |
            Input.IsPressed(Input.InputDefDown) |
            Input.IsPressed(Input.InputDefUp);
        }
        public static bool IsPressedJump(){
            return Input.IsPressed(InputDefJump) ;
        }
        public static bool IsPressedAttack(){
            return Input.IsPressed(InputDefAttack);
        }
        public static bool keyPressed(Godot.InputEventKey input,Godot.KeyList key){
            return  (input.Scancode == (uint)key);
        }
        public static Godot.Vector2 getInputDirection(Godot.InputEvent input){
            var tpe = typeof(Godot.InputEventKey);
            Godot.Vector2 dir = new Godot.Vector2();
            if (input.IsActionPressed(InputDefLeft)){
                dir.x -= 1;
            }
            if (input.IsActionPressed(InputDefRight)){
                dir.x +=1;
            }
            if (input.IsActionPressed(InputDefUp)){
                dir.y -=1;
            }
            if (input.IsActionPressed(InputDefDown)){
                dir.y +=1;
            }
            System.Console.WriteLine(dir);
            return dir;
        }

        public static Godot.Vector2 getInputDirection(){
            Godot.Vector2 vec = new Godot.Vector2();
            if (Godot.Input.IsActionPressed(InputDefLeft)){
                vec.x -=1;
            }
            if (Godot.Input.IsActionPressed(InputDefRight)){
                vec.x +=1;
            }
            if (Godot.Input.IsActionPressed(InputDefDown)){
                vec.y +=1;
            }
            if (Godot.Input.IsActionPressed(InputDefUp)){
                vec.y -=1;
            }
            return vec;
        }
    }
}