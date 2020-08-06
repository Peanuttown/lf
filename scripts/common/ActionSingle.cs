
namespace tzzGodot{
    //单一的一个动作
    abstract public class ActionSingle:ActionV2{
        public float timeAcc ;//该动作已经触发的时长
        public float duration ;//该动作的时长

        //
        public ActionSingle(float duration){
            this.timeAcc = 0;
            this.duration= duration;
        }
        public override bool Do(Actioner actioner,float dt){
            if (this.timeAcc >= this.duration){
                return true;
            }
            this.DoAction(actioner,this.timeAcc,dt);
            this.timeAcc += dt;
            return  false;
        }
        abstract public void DoAction(Actioner actioner,float timeAcc,float dt);


    }

}