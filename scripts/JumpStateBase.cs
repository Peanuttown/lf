using Godot;
using System;

public class JumpStateBase : StateBase
{
    public tzzGodot.ActionV2 jump_action;
    public const string stateName = "jump";
    // Declare member variables here. Examples:
    public override string getStateName(){
        return JumpStateBase.stateName;
    }
     public JumpStateBase(tzzGodot.Owner owner):base(owner){
        //todo
    }
    public void set_jump_action(tzzGodot.ActionV2 jump_action){
        this.jump_action = jump_action;
    }
    public override void on_enter(dynamic args){
        this.owner.setVerticalSpeed(100);
        //todo
    }

    public override void on_exit(dynamic args){
        System.Diagnostics.Debug.WriteLine("jump exit");
        this.owner.setVerticalSpeed(0);
    }

    public override void handle_action(string action_name, dynamic arg){

        //todo
    }


    public override void handle_physics_process(float dt){
        //get input direction
        this.owner.updatePos(dt);
        this.owner.updateVerticalSpeed(dt,tzzGodot.Define.Gravity_Accelaration);
        if (owner.onGround()){
            System.Diagnostics.Debug.WriteLine("on ground");
            this.state_over();
        }


    }   // private int a = 2;
}
