using System.Collections.Generic;
public class RoleNeglectedAttackState:AttackStateBase
{
    public RoleNeglectedAttackState(RoleBase selfRole):base(
        new ComboMgr(
            new List<Action>(){new RoleNeglectedAction()},
                    2,
                    selfRole
                    )
        ){
    }
}