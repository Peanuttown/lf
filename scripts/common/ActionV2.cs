using System.Collections.Generic;
namespace tzzGodot{
    public interface Actioner{

    }
    abstract public class ActionV2{
        // param:
        //   actioner: 释放者
        //   dt 距上一帧过去的时间
        // return:
        //   bool : 动作是否结束
        abstract public bool Do(Actioner actioner,float dt);
    }

}