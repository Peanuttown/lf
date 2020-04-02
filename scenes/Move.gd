extends State

var owner_:Node2D

func onEnter(_params):
	owner.speed = Vector2(100,0)

func onExit():
	owner.speed = Vector2(0,0)


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

func custom_physics_process(dt:float):
	var directions =self.get_input_direction()
	var move = directions[0]
	var direction =directions[1]
	if direction.length() == 0 && !move :
		emit_signal("state_over","move",null)
	else:
		 #owner.speed = Vector2(100,100)
		 owner.update_speed(direction)
		 owner.update_pos(dt)
	
