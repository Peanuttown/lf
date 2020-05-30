using Godot;
using System;

public class MoveStateBase : StateBase
{
    // Declare member variables here. Examples:

    public const string stateName = "move";
    public override string getStateName(){
        return MoveStateBase.stateName;
    }
     public MoveStateBase(tzzGodot.Owner owner):base(owner){
        //todo
    }
    public override void on_enter(object args){
        this.handle_action(MoveStateBase.stateName,args);
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
        this.owner.updatePos(dt);
        //move input pressd?
        if (!tzzGodot.Input.IsPressedMove()){
            Console.WriteLine("move state over");
            this.state_over();
        }
    }   
}
