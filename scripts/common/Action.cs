namespace tzzGodot
{
    abstract public class ActionBase
    {
        public string name;
        private List<Action> subActions;
        private int subActionIdx;
        private float duration;
        private float elapseTimeCounter;

        private tzzGodot.Animator animator;

        protected void showSubAction(float dt, float elapseTime, tzzGodot.Animator animator)
        {
            //need sub action elasped time
            if (this.subActions[this.subActionIdx].Do(dt, animator))
            {
                this.subActionIdx = (this.subActionIdx + 1) % this.subActions.Count;
            }
        }

        public bool hasSubAction()
        {
            return (this.subActions != null) && (this.subActions.Count != 0);
        }

        public float getActionDuration()
        {
            if (!this.hasSubAction())
            {
                return this.duration;
            }
            float duration = 0;
            this.subActions.ForEach(
                delegate (Action o)
                {
                    duration += o.getActionDuration();
                }
            );
            return duration;
        }

        public abstract void showAction(float dt, float elapseTime, tzzGodot.Animator animator);

        public void setAnimator(tzzGodot.Animator animator)
        {
            this.animator = animator;
        }
        public Action()
        {

        }

        public Action(float duration)
        {
            this.duration = duration;
            this.elapseTimeCounter = 0;
        }

        public Action(List<Action> subActions)
        {
            this.setActions(subActions);
        }

        public void setActions(List<Action> subActions)
        {
            this.subActions = subActions;
            this.duration = this.getActionDuration();
        }

        private void clean()
        {
            this.elapseTimeCounter = 0;
        }

        public bool Do(float dt, tzzGodot.Animator animator)
        {//return weather the action over
            if (this.elapseTimeCounter == 0)
            {
                this.showAction(dt, this.elapseTimeCounter, animator);
                this.elapseTimeCounter += dt;
                //if (this.name == "debug"){
                //    Console.WriteLine("elapsed Time :"+this.elapseTimeCounter);
                //}
                return false;
            }
            else
            {
                this.elapseTimeCounter += dt;
                //if (this.name == "debug"){
                //    Console.WriteLine("elapsed Time :"+this.elapseTimeCounter);
                //}
                if (this.duration < this.elapseTimeCounter)
                {
                    if (this.name == "debug")
                    {
                        Console.WriteLine("action over");
                    }
                    this.clean();
                    return true;
                }
                this.showAction(dt, this.elapseTimeCounter, animator);
                return false;
            }
        }

    }
}