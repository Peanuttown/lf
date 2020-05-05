using System.Collections.Generic;
public class RoleNeglectedAttackState:AttackStateBase
{
    public RoleNeglectedAttackState():base(
        new ComboMgr(
            new List<Action>(){new RoleNeglectedAction()},
                    2)
        ){
    }
}