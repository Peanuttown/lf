using System.Collections.Generic;
namespace tzzGodot{
    public class ActionMulti:ActionV2{
        public int curAction =0;
        public List<ActionV2> actions;
        public ActionMulti(List<ActionV2> actions){
            this.actions = actions;
        }
        public ActionMulti(){}
        public void set_actions(List<ActionV2> actions){
            this.actions= actions;
        }
        public void reset(){
            this.curAction=0;
        }
        override public bool Do(Actioner actor,float dt){
            if (this.actions[curAction].Do(actor,dt)){
                this.curAction++;
                if (this.curAction > this.actions.Count){
                    this.reset();
                    return true;
                }
            }
            return false;
        }
    }
}