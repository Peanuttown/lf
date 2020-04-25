using Godot;
using System;

public class AttackStateBase : StateBase
{
    static public string name="atk";
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private int actionCounter;
    public AttackStateBase():base(AttackStateBase.name){

    }

    // Called when the node enters the scene tree for the first time.
    private void Attack()
    {
        Console.WriteLine("attack");
    }

    public override void on_enter<T>(T args)
    {
        Console.WriteLine("attack enter");
    }

    public override void on_exit<T>(T args)
    {
        Console.WriteLine("attack exit");
    }

    public override void handle_action(string action_name, dynamic arg){
        if (action_name == AttackStateBase.name){
            this.Attack();
        }
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
