using System.Diagnostics;
public class RoleNeglectedAction:Action{

    public RoleNeglectedAction():base((float)(0.3)){

    }
    public override void playAnimation(){
        Debug.WriteLine("play animation");
    }
}