using System.Diagnostics;
using RoleNeglectedDef;

public class RoleNeglectedAction:Action{

    public RoleNeglectedAction():base((float)(0.3)){
    }
    public override void showAction(float elapseTime,tzzGodot.Animator animator){
        animator.showWithFrameIdx(10);
    }
}