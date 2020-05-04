using Godot;
using System;

public class AttackStateBase : StateBase
{
    public static string stateName ="atk";
    public override string getStateName(){
        return AttackStateBase.stateName;
    }
    private int actionCounter;
    public AttackStateBase():base(){

    }

    // Called when the node enters the scene tree for the first time.
    private void Attack()
    {
        Console.WriteLine("attack");
    }

    public override void on_enter(dynamic args)
    {
        Console.WriteLine("attack enter");
    }

    public override void on_exit(dynamic args)
    {
        Console.WriteLine("attack exit");
    }

    public override void handle_action(string action_name, dynamic arg){
        if (action_name == this.getStateName()){
            this.Attack();
        }
    }

    public override void handle_physics_process(float dt){
        //todo
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
