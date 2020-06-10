using Godot;
using System;
using System.Diagnostics;


public class MoveStateBase : StateBase
{
    // Declare member variables here. Examples:
    public Godot.Vector3 scalar_speed=new Vector3();
    public const string stateName = "move";
    private Godot.Vector2 prevMove ;
    private DateTime prevMoveTime;
    private tzzGodot.AnimatorSpriteContinous animator;
    public override string getStateName(){
        return MoveStateBase.stateName;
    }
     public MoveStateBase(tzzGodot.Owner owner,tzzGodot.AnimatorSpriteContinous animator):base(owner){
         this.animator = animator;
         this.prevMoveTime = DateTime.MinValue;
    }
    public override void on_enter(object args){
        //update prevMove
        //Debug.WriteLine("move state on enter");
        //change speed
        Godot.Vector2  dirc= (Godot.Vector2)(args);
        this.owner.set_speed(new Godot.Vector3(dirc.x*30,dirc.y*30,0));
        Debug.WriteLine("move on enter dirc"+dirc);
        Godot.Vector2 prevMove =this.prevMove;
        DateTime prevMoveTime = this.prevMoveTime;
        this.prevMove = dirc;
        this.prevMoveTime = DateTime.Now;
        this.owner.ChangeFaceDirection(dirc);
        if (prevMoveTime!= null){
            if (DateTime.Now.Subtract(prevMoveTime).Seconds<1){
                Debug.WriteLine("start run");
                ((RoleBase)this.owner).Run(tzzGodot.Coordinate.is_right(dirc));
                return;
            }
        }
        //this.handle_action(MoveStateBase.stateName,args);
    }

    public override void on_exit(object args){
        //todo
    }

    public override void handle_action(string action_name, object arg){
        //if (action_name == MoveStateBase.stateName){
        //    Godot.Vector2 direction = (Godot.Vector2)(arg);
        //    this.owner.OwnerMove(tzzGodot.Node25D.ToVec3(direction));
        //}
    }

    public override void handle_physics_process(float dt){
        this.animator.Update(dt);
        this.owner.updatePos(dt);
        //move input pressd?
        if (!tzzGodot.Input.IsPressedMove()){
            this.state_over();
            return;
        }
        animator.Update(dt);
    }   

    public override void handle_input_event(InputEvent @event){
        //revers press
        if (@event.IsPressed()){
            Godot.Vector2 dirc  = tzzGodot.Input.getDirection(@event);
            if (dirc.x != 0){
                this.owner.SetXSpeed(dirc.x*2);
            }

        }

        if (tzzGodot.Input.IsActionReleasedCommon(@event,new string[]{tzzGodot.Input.InputDefLeft,tzzGodot.Input.InputDefRight})){
            //direction
            this.owner.GetTree().SetInputAsHandled();
            Godot.Vector2  releaseDirc = tzzGodot.Input.getReleasedDirection(@event);
            //Debug.WriteLine("release Direction "+releaseDirc);
            //face direction
            bool right = this.owner.GetDirection();
            //Debug.WriteLine("face right?"+right);
            if (right && releaseDirc.x > 0){
                if (Godot.Input.IsActionPressed(tzzGodot.Input.InputDefLeft)){
                    this.owner.ChangeFaceDirection(new Godot.Vector2(tzzGodot.Coordinate.Left,0));
                }
            }else if (!right && releaseDirc.x < 0){
                if (Godot.Input.IsActionPressed(tzzGodot.Input.InputDefRight)){
                    this.owner.ChangeFaceDirection(new Godot.Vector2(tzzGodot.Coordinate.Right,0));
                }
            }
        }

    }
}
