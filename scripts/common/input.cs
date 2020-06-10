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
        public static bool IsKeyPressed(Godot.InputEvent @event,Godot.KeyList key){
            if (@event is Godot.InputEventKey){
                Godot.InputEventKey e = ((Godot.InputEventKey)(@event));
                return e.Scancode==(uint)key && e.IsPressed();
            }
            return false;
        }
        public static bool IsKeyRelease(Godot.InputEvent @event,Godot.KeyList key){
            if (@event is Godot.InputEventKey){
                Godot.InputEventKey e = ((Godot.InputEventKey)(@event));
                return e.Scancode==(uint)key && !e.IsPressed();
            }
            return false;
        }
        public static bool IsActionReleased(Godot.InputEventKey @event,string action){
            return @event.IsActionReleased(action);
        }
        public static bool IsActionReleasedCommon(Godot.InputEvent @event,string []actions){
            if (@event is Godot.InputEventKey){
                for (int i =0;i<actions.Length;i++){
                    if (IsActionReleased((Godot.InputEventKey)(@event),actions[i])){
                        return true;
                    }
                }
            }
            return false;
            //todo
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
        public static Godot.Vector2 getReleasedDirection(Godot.InputEvent input){
            var tpe = typeof(Godot.InputEventKey);
            Godot.Vector2 dir = new Godot.Vector2();
            if (input.IsActionReleased(InputDefLeft))
            {
                dir.x -= 1;
            }
            if (input.IsActionReleased(InputDefRight))
            {
                dir.x += 1;
            }
            if (input.IsActionReleased(InputDefUp))
            {
                dir.y -= 1;
            }
            if (input.IsActionReleased(InputDefDown))
            {
                dir.y += 1;
            }
            return dir;
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

        public static Godot.Vector2 getDirection(Godot.InputEvent @event)
        {
            Godot.Vector2 v = new Godot.Vector2();
            if (@event.IsActionPressed(InputDefUp))
            {
                v.y = (float)(Coordinate.Up);
                return v;
            }
            if (@event.IsActionPressed(InputDefDown))
            {
                v.y =(float)(Coordinate.Down);
                return v;
            }
            if (@event.IsActionPressed(InputDefLeft))
            {
                v.x =(float)(Coordinate.Left);
                return v;
            }
            if (@event.IsActionPressed(InputDefRight))
            {
                v.x =(float)(Coordinate.Right);
                return v;
            }
            return v;
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

    public static class Coordinate{
        public static int Left = -1;
        public static int  Right= 1;
        public static int Down= 1;
        public static int Up= -1;
        public static bool is_right(Godot.Vector2 dirc){
            return tzzMath.Math.is_same_sign(dirc.x,Coordinate.Right);
        }
        public static bool is_left(Godot.Vector2 dirc){
            return tzzMath.Math.is_same_sign(dirc.x,Coordinate.Left);
        }
        public static bool is_up(Godot.Vector2 dirc){
            return tzzMath.Math.is_same_sign(dirc.y,Coordinate.Up);
        }
        public static bool is_down(Godot.Vector2 dirc){
            return tzzMath.Math.is_same_sign(dirc.y,Coordinate.Down);
        }

    }
}
