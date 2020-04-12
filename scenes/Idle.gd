extends RoleStateBase


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var lastMoveTime =-1

# Called when the node enters the scene tree for the first time.
func _ready():
	self.state_name ="idle"
	pass # Replace with function body.

func setOriginSpriteFrame():
	self.set_sprite_frame(0)

func onEnter(_params):
	self.setOriginSpriteFrame()

func onStateResume(args):
	self.setOriginSpriteFrame()

func onExit():
	print("idle onExit")

func custom_process(_dt:float):
	pass

func custom_unhandle_input(event:InputEvent):
	owner.handle_input_common(event)
	if event.is_action_pressed("jump"):
		self.push_state("jump",null)
		#emit_signal("push_state","jump")
	if event.is_action_pressed("move"):
		var t = OS.get_system_time_msecs()
		if lastMoveTime != -1 && t - lastMoveTime < 500:
			self.push_state("run",null)
		else:
			self.push_state("move",null)
		lastMoveTime = t
	if event.is_action_pressed("attack"):
		self.push_state("attack",null)


func custom_physics_process(_dt:float):
	pass





