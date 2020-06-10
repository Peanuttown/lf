using System;
using System.Diagnostics;
namespace tzzGodot{
    public class AnimatorSpriteContinous{
        private float duration;
        private float timeAcc;
        private int start;
        private int end;
        private Animator animator;
        public AnimatorSpriteContinous(Animator animator,float duration,int start,int end){
            if (end == start){
                throw new Exception("end can not equal start");
            }
            this.animator = animator;
            this.duration = duration;
            this.timeAcc = 0;
            this.start= start;
            this.end = end;
        }
        public void Update(float dt){
            this.timeAcc += dt;
            int length = (end-start+1);
            int index  = (int)(this.timeAcc/this.duration);
            int offset = (index % (length*2));
            if (offset < length){
                offset = start + offset;
            }else{
                offset =end - (offset-length);
            }
            this.animator.showWithFrameIdx(offset);
        }

        public void Reset(){
            this.timeAcc = 0;
            this.animator.showWithFrameIdx(0);
        }
        
    }
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
            //Debug.WriteLine(Environment.StackTrace);
            //Debug.WriteLine("currnet frame "+frameIdx);
            this.sprite.Frame = frameIdx;
        }

        public override void SetFlipV(bool f){
            this.sprite.FlipV =f;
        }
        public override void SetFlipH(bool f){
            this.sprite.FlipH=f;
        }
    }
}