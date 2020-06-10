using Godot;
using System;
using StateMachine;
using System.Collections.Generic;
using System.Diagnostics;


abstract public class  RoleBase : tzzGodot.Node25D
{
    private int Count;
    private bool direction = true;
    public Vector3 speed =new Vector3(0,0,0);
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
                //Debug.WriteLine("register state "+ state.getStateName());
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
    public RunStateBase runState;


    public void handle_physics_process(float dt){
        this.fSM.handle_physics_process(dt);
    }
    private string curStateName(){
        return this.fSM.curStateName();
    }

    public override void _PhysicsProcess(float dt){
        this.handle_physics_process(dt);
    }
    public override void _Input(InputEvent @event){
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

    public void Move(Godot.Vector2 dirc){
        if (this.is_idle()){
            this.fSM.push_state(MoveStateBase.stateName,dirc);
            return;
        }
        this.fSM.handle_action(MoveStateBase.stateName,dirc);
    }
    public void Run(bool right){
        if (this.is_idle() || this.is_moving()){
            this.fSM.push_state(RunStateDef.Def.StateName,right);
        }
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
            this.speed.x*dt,
            dt*this.speed.y,moveZ);
        //Console.WriteLine(shift);
        this.OwnerMove(shift);
    }
    public bool GetDirection(){
        return this.direction;
    }
    public override void _UnhandledInput(InputEvent @event){
        //Debug.WriteLine("role base unhandle input");
        this.fSM.handle_input(@event);
    }
    public void SetXSpeed(float speed){
        this.speed.x = speed;
    }
    public float GetXSpeed(){
        return this.speed.x;
    }

    public void ChangeFaceDirection(Vector2 vec){
        //Debug.WriteLine("change face direction ");
        if (vec.x > 0){
            this.animator.SetFlipH(false);
            this.direction= true;
        }else if (vec.x <0) {
            this.animator.SetFlipH(true);
            this.direction=false;
        }
    }
    public Godot.SceneTree get_tree(){
        return this.GetTree();
    }
    public void set_speed(Godot.Vector3 v){
        this.speed = v;
    }
    public Godot.Vector3 get_speed(){
        return this.speed;
    }
    public void set_y_speed(float v){
        this.speed.y = v;
    }

}
