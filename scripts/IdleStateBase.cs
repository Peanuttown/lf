using Godot;
using System;
using System.Diagnostics;

public class IdleStateBase : StateBase
{
    public override string getStateName(){
        return "idle";
    }
    public IdleStateBase():base(){
        //todo
    }
    public override void on_enter(dynamic args){
        Debug.WriteLine(String.Format("%s on enter",this.getStateName()));
    }

    public override void on_exit(dynamic args){
        Debug.WriteLine(String.Format("%s on exit",this.getStateName()));
    }

    public override void handle_action(string action_name, dynamic arg){
        //todo
    }

    public override void handle_physics_process(float dt){

    }
}
