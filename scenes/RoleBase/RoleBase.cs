using Godot;
using System;
using StateMachine;

abstract public class  RoleBase : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private StateMachine.FSM fSM;

    public AttackStateBase attackState;

    public abstract void RegisterState();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Console.WriteLine("role base ready");
    }

    private string curStateName(){
        return this.fSM.curStateName();
    }

    public override _PhysicsProcess(float delta){
        this.fSM.
    }

    private bool is_attacking(){
        return this.curStateName()==AttackStateBase.name;
    }


    public void Attack(){
        if (this.is_attacking()){
            this.fSM.handle_action(AttackStateBase.name,null);
            return ;
        }
        this.fSM.push_state<int>(AttackStateBase.name,0);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
