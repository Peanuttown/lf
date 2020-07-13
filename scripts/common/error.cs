namespace tzzGodot{
    public class Except:System.Exception{
        public static void Throw(string msg){
            throw(new System.Exception(msg));
        }
    }
}