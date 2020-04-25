using Godot;
using System;

public class Role : RoleBase
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public override void RegisterState(){


    }

    // Called when the node enters the scene tree for the first time.
    public virtual void _Ready()
    {
        ((RoleBase)this)._Ready();
        Console.WriteLine("role ready");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
