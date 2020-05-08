using System.Collections.Generic;
public class RoleNeglectedAttackState:AttackStateBase
{
    public RoleNeglectedAttackState(tzzGodot.Owner owner,RoleBase selfRole):base(
        owner,
        new ComboMgr(
            new List<Action>(){new RoleNeglectedAction_Attack_StraightPunch()},
                    2,
                    selfRole
                    )
        ){
    }
}