namespace tzzGodot{
    public class AnimatorSprite:Animator{
        private Godot.Sprite sprite;

        public override void addToChild(Godot.Node parent){
            parent.AddChild(this.sprite);
        }
        public AnimatorSprite(Godot.Texture texture,int hFrames,int vFrames){
            this.sprite = new Godot.Sprite();
            this.sprite.Texture = texture;
            this.sprite.Hframes = hFrames;
            this.sprite.Vframes = vFrames;
        }
        public AnimatorSprite(string texturePath,int hFrames,int vFrames){
            this.sprite = new Godot.Sprite();
            Godot.Resource res =Godot.ResourceLoader.Load(texturePath);
            this.sprite.Texture = (Godot.Texture)res;
            this.sprite.Hframes = hFrames;
            this.sprite.Vframes = vFrames;
        }

        public Godot.Sprite GetSprite(){
            return this.sprite;
        }

        public override void show(){
            //todo
        }
        public override void showWithFrameIdx(int frameIdx){
            this.sprite.Frame = frameIdx;
        }
    }
}