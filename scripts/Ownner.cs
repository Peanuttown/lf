namespace tzzGodot{
    public  interface Owner{
        void OwnerMove(Godot.Vector3 vec);
        void HandleAttackStateOver();

        void updateVerticalSpeed(float dt,float acceleration);
        bool onGround();
        void setVerticalSpeed(float speed);

        float VerticalSpeed();
        tzzGodot.Animator getAnimator();
        void updatePos(float dt);
    }
}