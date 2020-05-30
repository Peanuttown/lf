using Godot;
using System;
using StateMachine;
using System.Collections.Generic;
using System.Diagnostics;


abstract public class  RoleBase : tzzGodot.Node25D
{
    public Vector3 speed =new Vector3(10,10,0);
    private tzzGodot.Animator animator;
    public static int IdleStateIdx = 0;
    public static int MoveStateIdx  =1;
    public static int JumpStateIdex= 2;
    public static int AttackStateIdx= 3;
    public void OwnerMove(Godot.Vector3 vec){
        this.z = Godot.Mathf.Max(this.z+vec.z,0);
        this.Position +=tzzGodot.Node25D.ToVector2(vec);
    }

    public void setAnimator(tzzGodot.Animator animator){
        this.animator = animator;
    }

    public tzzGodot.Animator getAnimator(){
        return this.animator;
    }
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
                Debug.WriteLine("register state "+ state.getStateName());
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

    public void Move(Vector2 direction){
        if (this.is_idle()){
            this.fSM.push_state(MoveStateBase.stateName,direction);
            return;
        }
        this.fSM.handle_action(MoveStateBase.stateName,direction);
    }

    public float VerticalSpeed(){
        return this.speed.z;
    }

    public void setVerticalSpeed(float speed){
        this.speed.z=speed;
    }


    public void updateVerticalSpeed(float dt,float acceleration){
        this.speed.z += dt * acceleration;
    }

    public void updatePos(float dt){
        //vertical
        float moveZ = dt * this.VerticalSpeed();
        Vector2 direction  = tzzGodot.Input.getInputDirection();
        Vector3 shift = new Vector3(
            direction.x*this.speed.x*dt,
            direction.y*dt*this.speed.y,moveZ);
        Console.WriteLine(shift);
        this.OwnerMove(shift);
    }

}
