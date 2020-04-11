extends RoleStateBase


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var frame_offset=20
var frame_window_len=3
var frame_change_dt = 200#毫秒




func onEnter(_params)->void:
	self.set_sprite_frame(self.frame_offset)

func onExit()->void:
	print("run exit")

# Called when the node enters the scene tree for the first time.
func _ready():
	self.state_name = "run"

func custom_process(dt:float)->void:
	var now =OS.get_system_time_msecs()
	var frame_index = now % self.frame_window_len
	self.set_sprite_frame(self.frame_offset + frame_index)

func custom_physics_process(dt:float)->void:
	self.update_x_axis_pos(dt,200,200)

func custom_unhandle_input(event:InputEvent)->void:
	if event.is_action_released("move") && !self.input_has_move():
		self.state_over(null)



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
