extends RoleStateBase

var owner_:Node2D

func onEnter(_params):
	pass

func onExit():
	owner.speed_x_scalar = 0
	owner.speed_y_scalar = 0


# Called when the node enters the scene tree for the first time.
func _ready():
	self.state_name="move"
	self.owner_ = owner as Node2D
	pass # Replace with function body.

func custom_process(_dt:float):
	pass

func custom_unhandle_input(event:InputEvent):
	if event.is_action_pressed("jump"):
		push_state("jump",null)
	if event.is_action_pressed("move"):
		print("move get move")

func custom_physics_process(dt:float):
	self.update_x_axis_pos(dt,100,100)
	#var directions =self.get_input_direction()
	#var move = directions[0]
	#var direction =directions[1]
	#if direction.length() == 0 && !move :
	#	emit_signal("state_over","move",null)
	#else:
	#	 owner.update_pos(dt,direction)
	
