using tzzGodot;
using System.Diagnostics;

namespace RunStateDef{
    public static class Def{
        public static string StateName ="run";
    }

}
public class RunStateBase:StateBase{
    private AnimatorSpriteContinous animator;
    public RunStateBase(Owner owner,AnimatorSpriteContinous animator):base(owner){
        this.animator = animator;
    }
    private float oldXSpeed;

    public override string getStateName(){
        return RunStateDef.Def.StateName;
    }
    public override void on_exit(dynamic args){
        this.owner.SetXSpeed(this.oldXSpeed);
        //todo
    }
    public override void on_enter(dynamic args){
        this.oldXSpeed = this.owner.GetXSpeed();
        bool right = (bool)(args);
        Debug.WriteLine("run state on enter"+right);
        float speed = 50;
        if (right){
            this.owner.SetXSpeed(speed);
        }else{
            this.owner.SetXSpeed(-speed);
        }

    }
    public override void handle_input_event(Godot.InputEvent @event){
        if (@event.IsPressed()){
            Godot.Vector2 dirc = tzzGodot.Input.getDirection(@event);
            if (dirc.y!=0){
                   this.owner.set_y_speed(dirc.y*20);
            }
        }
        //Debug.WriteLine("run state handle input");
        bool faceright  = this.owner.GetDirection();
        if (@event is Godot.InputEventKey ){
            Godot.InputEventKey eventK = (Godot.InputEventKey)(@event);
            if (eventK.IsActionReleased(tzzGodot.Input.InputDefLeft) ||eventK.IsActionReleased(tzzGodot.Input.InputDefRight)){
                this.state_over();
                return;

            }
            if (eventK.IsActionReleased(tzzGodot.Input.InputDefRight)&&faceright){
                this.state_over();
                return;
            }else if(eventK.IsActionReleased(tzzGodot.Input.InputDefLeft)&&!faceright){
                this.state_over();
                return;
            }
        }
    }
    public override void handle_action(string action_name, object arg){
    }
    public override void handle_physics_process(float dt){
        //Debug.WriteLine("run handle physics");
        this.animator.Update(dt);
        this.owner.updatePos(dt);
    }

}