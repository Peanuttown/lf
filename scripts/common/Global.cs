class Global:Godot.Node2D{
    private int count;
    public override void _Ready(){
        this.count++;
        System.Console.WriteLine("global ready"+this.count);
    }
}