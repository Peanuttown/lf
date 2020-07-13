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
    private Godot.InputEvent lastMoveEvent;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Console.WriteLine(Global.get_global(this).count);
        this.role = new RoleNeglected();
        this.AddChild(this.role);
    }
    public override void _UnhandledKeyInput(InputEventKey @event){
        if (tzzGodot.Input.IsAttack(@event))
        {
            this.role.Attack();
        }
        else if (tzzGodot.Input.IsJump(@event))
        {
            this.role.Jump();
        }
        else if (tzzGodot.Input.IsMove(@event))
        {
            //Debug.WriteLine("play move");
            this.role.Move(tzzGodot.Input.getInputDirection(@event));
        }
        GetTree().SetInputAsHandled();
    }


    public override void _PhysicsProcess(float delta){
        if (tzzGodot.Input.IsPressedMove()){
            this.role.Move(tzzGodot.Input.getInputDirection());
        }
    }
}