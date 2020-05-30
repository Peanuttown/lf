using Godot;
using System;
using System.Collections.Generic;

public class RoleNeglected : RoleBase,tzzGodot.Owner
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public void HandleAttackStateOver(){

    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Godot.InputEventKey k=new Godot.InputEventKey();
        //k.Scancode = (int)Godot.KeyList.K;
        //Godot.InputMap.ActionAddEvent(tzzGodot.Input.InputDefAttack,k);
        tzzGodot.AnimatorSprite animator = new tzzGodot.AnimatorSprite(RoleNeglectedDef.Def.All,10,7);
        //todo set animator
        this.setAnimator(animator);
        List<StateBase> states =new List<StateBase>();
        states.Add(new RoleNeglectedIdleState(this));
        states.Add(new RoleNeglectedMoveState(this));
        states.Add(new RoleNeglectedJumpState(this));
        states.Add(new RoleNeglectedAttackState(this,this));
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
