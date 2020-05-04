using Godot;
using System;
using System.Collections.Generic;

public class Role : RoleBase
{

    public  Role(){


    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ((RoleBase)this)._Ready();
        Console.WriteLine("role ready");
    }

}
