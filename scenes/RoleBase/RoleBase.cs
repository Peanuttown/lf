using Godot;
using System;
using StateMachine;
using System.Collections.Generic;


abstract public class  RoleBase : Node2D
{
    public static int IdleStateIdx = 0;
    public static int MoveStateIdx  =1;
    public static int JumpStateIdex= 2;
    public static int AttackStateIdx= 3;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    //states order : idle,atk,jump
    public void RegisterState(List<StateBase> states){
        if (states.Count<4){
            throw new Exception(String.Format("role min need 3 state,but give %d\n",states.Count));
        }
        this.idleState = (IdleStateBase)states[RoleBase.IdleStateIdx];
        this.moveState= (MoveStateBase)states[RoleBase.MoveStateIdx];
        this.jumpState= (JumpStateBase)states[RoleBase.JumpStateIdex];
        this.attackState= (AttackStateBase)states[RoleBase.AttackStateIdx];
        this.fSM = new FSM();
        states.ForEach(
            delegate(StateBase state){
                this.fSM.register_state(state.getStateName(),state);
            }
        );
        //push default state
        this.fSM.push_state(this.idleState.getStateName(),null);
    }
    private StateMachine.FSM fSM;

    public AttackStateBase attackState;
    public IdleStateBase idleState;
    public JumpStateBase jumpState;

    public MoveStateBase moveState;


    public void handle_physics_process(float dt){
        this.fSM.handle_physics_process(dt);
    }
    private string curStateName(){
        return this.fSM.curStateName();
    }

    public override void _PhysicsProcess(float dt){
        this.handle_physics_process(dt);
    }

    private bool is_attacking(){
        return this.curStateName()==AttackStateBase.stateName;
    }

    private bool is_idle(){
        return this.curStateName() == IdleStateBase.stateName;
    }

    private bool is_moving(){
        return this.curStateName() == MoveStateBase.stateName;
    }

    private bool is_jumping(){
        return this.curStateName() == JumpStateBase.stateName;
    }


    public void Attack(){
        if (this.is_idle()){
            this.fSM.push_state(AttackStateBase.stateName,null);
            return;
        }
        this.fSM.cur_state().handle_action(AttackStateBase.stateName,null);
    }

    public void Jump(){
        if (this.is_idle()){
            this.fSM.push_state(JumpStateBase.stateName,null);
        }
    }

    public void Move(){
        if (this.is_idle()){
            this.fSM.push_state(MoveStateBase.stateName,null);
        }
    }



//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
