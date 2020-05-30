using System.Diagnostics;
using RoleNeglectedDef;
using System.Collections.Generic;

public class RoleNeglectedAction_Attack_Action_Base:Action{
    public override void showAction(float dt,float elapseTime,tzzGodot.Animator animator){
        this.showSubAction(dt,elapseTime,animator);
    }
}
public class RoleNeglectedAction_Attack_SubAction_Base:Action{
        protected int frameIdx ;
        public  RoleNeglectedAction_Attack_SubAction_Base(int frameIdx ,float duration):base(duration){
            this.frameIdx = frameIdx;
        }
        public override void showAction(float dt, float elapseTime, tzzGodot.Animator animator){
            animator.showWithFrameIdx(this.frameIdx);
        }
}

public class RoleNeglectedAction_Attack_StraightPunch:RoleNeglectedAction_Attack_Action_Base{
    public class StraightPunch_RaiseHand:RoleNeglectedAction_Attack_SubAction_Base{
        public StraightPunch_RaiseHand(int frameIdx,float duration):base(frameIdx,duration){

        }
    }

    public class StraightPunch_Punch:RoleNeglectedAction_Attack_SubAction_Base{
        public StraightPunch_Punch(int frameIdx,float duration):base(frameIdx,duration){

        }
    }

    public RoleNeglectedAction_Attack_StraightPunch():base(){
        //sub actions
        this.name = "debug";
        this.setActions(
            new List<Action>{new StraightPunch_RaiseHand(10,(float)0.2),new StraightPunch_Punch(11,(float)0.2)}
        );
    }
    public override void showAction(float dt,float elapseTime,tzzGodot.Animator animator){
        this.showSubAction(dt,elapseTime,animator);
    }
}

public class  RoleNeglectedAction_Attack_StraightPunch_Left:RoleNeglectedAction_Attack_Action_Base{
    public class StraightPunch_RaiseHand:Action{
        public StraightPunch_RaiseHand(float duration):base(duration){

        }
        public override void showAction(float dt, float elapseTime, tzzGodot.Animator animator){
            animator.showWithFrameIdx(12);
        }
    }

    public class StraightPunch_Punch:Action{
        public StraightPunch_Punch(float duration):base(duration){

        }
        public override void showAction(float dt, float elapseTime, tzzGodot.Animator animator){
            animator.showWithFrameIdx(13);
        }

    }

    public RoleNeglectedAction_Attack_StraightPunch_Left():base(){
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