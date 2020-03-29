extends State

var owner_:Node2D

func onEnter(_params):
	pass

func onExit():
	print("move over")
	pass


# Called when the node enters the scene tree for the first time.
func _ready():
	self.state_name="move"
	assert(owner.is_class("Node2D"))
	self.owner_ = owner as Node2D
	pass # Replace with function body.

func custom_process(_dt:float):
	pass

func custom_unhandle_input(_event:InputEvent):
	pass

func custom_physics_process(dt:float):
	var speed =Vector2() 
	var move =false
	if Input.is_action_pressed("ui_left"):
		move = true
		speed.x -= 100
	if Input.is_action_pressed("ui_right"):
		move = true
		speed.x += 100
	if Input.is_action_pressed("ui_up"):
		move = true
		speed.y -= 100
	if Input.is_action_pressed("ui_down"):
		move = true
		speed.y += 100
	if speed.length() == 0 && !move :
		print(0)
		emit_signal("state_over","move",null)
	else:
		self.owner_.position += speed * dt
	
