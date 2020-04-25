using Godot;
using System;
using tzzMath;

public class MonoTest : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Godot.Vector2 a = new Godot.Vector2(1,1);
        System.Console.WriteLine(a);
        tzzMath.Adder adder= new tzzMath.Adder();
        System.Console.WriteLine(adder);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
