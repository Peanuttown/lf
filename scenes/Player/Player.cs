using Godot;
using System;
using System.Diagnostics;
using tzzGodot;

public class Player : Node2D
{
    public RoleBase  role ;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.role = new RoleNeglected();
        this.AddChild(this.role);
    }

    public override void _UnhandledInput(InputEvent @event){
        if (tzzGodot.Input.IsAttack(@event)){
            this.role.Attack();
        }else if(tzzGodot.Input.IsJump(@event)){
            this.role.Jump();
        }else if (tzzGodot.Input.IsMove(@event)){
            this.role.Move(tzzGodot.Input.getInputDirection(@event));
        }
    }

    public override void _PhysicsProcess(float delta){
        if (tzzGodot.Input.IsPressedAttack()){
            this.role.Attack();
        }else if(tzzGodot.Input.IsPressedJump()){
            this.role.Jump();
        }else if(tzzGodot.Input.IsPressedMove()){
            this.role.Move(tzzGodot.Input.getInputDirection());
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
