using System.Diagnostics;
using RoleNeglectedDef;
using System.Collections.Generic;

public class RoleNeglectedAction_Attack_StraightPunch:Action{
    public class StraightPunch_RaiseHand:Action{
        public StraightPunch_RaiseHand(float duration):base(duration){

        }
        public override void showAction(float dt, float elapseTime, tzzGodot.Animator animator){
            animator.showWithFrameIdx(10);
        }
    }

    public class StraightPunch_Punch:Action{
        public StraightPunch_Punch(float duration):base(duration){

        }
        public override void showAction(float dt, float elapseTime, tzzGodot.Animator animator){
            animator.showWithFrameIdx(11);
        }

    }

    public RoleNeglectedAction_Attack_StraightPunch():base(){
        //sub actions
        this.name = "debug";
        this.setActions(
            new List<Action>{new StraightPunch_RaiseHand((float)0.2),new StraightPunch_Punch((float)0.2)}
        );
    }
    public override void showAction(float dt,float elapseTime,tzzGodot.Animator animator){
        this.showSubAction(dt,elapseTime,animator);
    }
}
