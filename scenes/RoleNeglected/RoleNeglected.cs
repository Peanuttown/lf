using Godot;
using System;
using System.Collections.Generic;

public class RoleNeglected : RoleBase
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tzzGodot.AnimatorSprite animator = new tzzGodot.AnimatorSprite(RoleNeglectedDef.Def.All,10,7);
        //todo set animator
        this.setAnimator(animator);
        List<StateBase> states =new List<StateBase>();
        states.Add(new RoleNeglectedIdleState());
        states.Add(new RoleNeglectedMoveState());
        states.Add(new RoleNeglectedJumpState());
        states.Add(new RoleNeglectedAttackState(this));
        this.RegisterState(
            states
        );
        this.getAnimator().addToChild(this);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
