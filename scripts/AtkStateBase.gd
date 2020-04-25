extends State


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

#Array<Action>
var actions;

# Called when the node enters the scene tree for the first time.
func _ready():
	#set state name
	self.state_name = "attack"

func handle_combo_over()->void:
	self.state_over(null)

func onEnter(params):
	self.comboMgr.action_incr()

func onExit():
	pass

func custom_physics_process(dt:float)->void:
	self.comboMgr.action(owner.get_body_sprite(),dt)

func custom_process(dt:float)->void:
	pass

func custom_unhandle_input(event:InputEvent)->void:
	if event.is_action_pressed("attack"):
		self.comboMgr.action_incr()


func attack(dt:float)->void:
	pass



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
