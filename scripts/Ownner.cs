using Godot;
namespace tzzGodot{
    public  interface Owner{
        void ChangeFaceDirection(Vector2 vec);

        void SetXSpeed(float speed);
        void set_speed(Vector3 speed);
        void set_y_speed(float v);
        Godot.Vector3 get_speed();
        float GetXSpeed();
        void OwnerMove(Godot.Vector3 vec);
        void HandleAttackStateOver();

        void updateVerticalSpeed(float dt,float acceleration);
        bool onGround();
        void setVerticalSpeed(float speed);

        float VerticalSpeed();
        tzzGodot.Animator getAnimator();
        void updatePos(float dt);
        bool GetDirection();

        SceneTree GetTree();
    }
}