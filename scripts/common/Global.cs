namespace tzzGodot{
public class Global:Godot.Node2D
    {
        static public Global get_global(Godot.Node2D node)
        {
            return (Global)(node.GetNode("/root/Global"));
        }
        public int count;
        public BackgroundRepo  bg_repo;
        public override void _Ready(){
            //<init bg_repo
            this.bg_repo = new BackgroundRepo();
            //this.bg_repo.register_repo()

            //
        }
    }
}