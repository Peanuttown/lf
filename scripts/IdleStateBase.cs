using Godot;
using System;
using System.Diagnostics;

public class IdleStateBase : StateBase
{
    public const string stateName ="idle";
    public override string getStateName(){
        return IdleStateBase.stateName;
    }
    public IdleStateBase(tzzGodot.Owner owner):base(owner){
        //todo
    }
    public override void on_enter(dynamic args){
        Debug.WriteLine(String.Format("%s on enter",this.getStateName()));
    }

    public override void on_exit(dynamic args){
    }

    public override void on_resume_from_fsm_stack(){
        this.owner.set_speed(new Vector3(0,0,0));
        this.owner.getAnimator().showWithFrameIdx(0);
    }

    public override void handle_action(string action_name, dynamic arg){
        //todo
    }

    public override void handle_physics_process(float dt){

    }
}
