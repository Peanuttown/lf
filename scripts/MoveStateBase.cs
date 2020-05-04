using Godot;
using System;

public class MoveStateBase : StateBase
{
    // Declare member variables here. Examples:
    public override string getStateName(){
        return "move";
    }
     public MoveStateBase():base(){
        //todo
    }
    public override void on_enter(dynamic args){
        //todo
    }

    public override void on_exit(dynamic args){
        //todo
    }

    public override void handle_action(string action_name, dynamic arg){
        //todo
    }

    public override void handle_physics_process(float dt){

    }   // private int a = 2;
}
