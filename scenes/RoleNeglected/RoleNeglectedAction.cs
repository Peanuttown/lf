using System.Diagnostics;
using RoleNeglectedDef;
using System.Collections.Generic;

namespace Define{
    static public class RoleNeglectedSpriteIdx{
        public static int Idel0=0;
        public static int Idel3=3;
        public static int Walk0=4;
        public static int Walk3=7;
        public static int RightPunchReady=10;
        public static int RightPunch=11;
        public static int LeftPunchReady=12;
        public static int LeftPunch=13;
        public static int KickReady=14;
        public static int Kick=15;
        public static int Run0=20;
        public static int Run2=22;

        public static int JumpReady0=70;
        public static int JumpReady1=71;
        public static int Jump=72;
    }
}

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

public class JumpAction:tzzGodot.ActionMulti{
    public JumpAction(){
        this.actions=new List<tzzGodot.ActionV2>();
        this.actions.Add(new JumpActionSquatDown(Define.RoleNeglectedSpriteIdx.JumpReady0,(float)0.3));
        this.actions.Add(new JumpActionSquatDown(Define.RoleNeglectedSpriteIdx.JumpReady1,(float)0.3));
        this.actions.Add(new JumpActionJump());
    }
    private class JumpActionSquatDown:tzzGodot.ActionSingle{
        public int frameIdx;
        public JumpActionSquatDown(int frameIdx,float duration):base(duration){
            this.frameIdx = frameIdx;
        }
        public override void DoAction(tzzGodot.Actioner actioner,float timeAcc,float dt){
            RoleBase role = actioner as RoleBase;
            role.getAnimator().showWithFrameIdx(this.frameIdx);
        }
    }
    public class JumpActionJump:tzzGodot.ActionV2{
        public JumpActionJump(float duration){

        }
        public override void Do(tzzGodot.Actioner actioner,  float dt){
            RoleBase role = actioner as RoleBase;
            role.getAnimator().showWithFrameIdx(Define.RoleNeglectedSpriteIdx.Jump);
            // < move  actioner
            // >
        }
    }
}