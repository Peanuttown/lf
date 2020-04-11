extends State

class_name RoleStateBase
# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func set_sprite_frame(frame:int):
	self.get_sprite().frame = frame

func get_sprite()->Sprite:
	return owner.get_node("Sprite") as Sprite

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func update_x_axis_pos(dt:float,expect_speed_x:int,expect_speed_y:int)->void:
	var directions =self.get_input_direction()
	var move = directions[0]
	var direction =directions[1]
	if direction.length() == 0 && !move :
		self.state_over(null)
	else:
		if direction[0] != 0:
			owner.speed_x_scalar = expect_speed_x
		if direction[1] != 0:
			owner.speed_y_scalar = expect_speed_y
		owner.update_pos(dt,direction)


func input_has_move()->bool:
	var moves = ["ui_left","ui_right","ui_up","ui_down"]
	for m in moves:
		if Input.is_action_pressed(m):
			return true 
	return false
