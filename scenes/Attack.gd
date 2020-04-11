extends RoleStateBase


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var comboMgr = Combo.new()

class ActionA extends Action:
	func _init(interval,frame_releative_index).(interval,frame_releative_index):
		pass
	func play_frame(sprite,frame)->void:
		sprite.frame=frame+10
	
var actionA = ActionA.new(1,1)

func _ready():
	self.state_name = "attack"
	self.comboMgr.connect_combo_over(self,"handle_combo_over")

func handle_combo_over()->void:
	self.state_over(null)

func onEnter(params):
	self.comboMgr.push_action(self.actionA)

func onExit():
	pass

func custom_physics_process(dt:float)->void:
	self.comboMgr.action(owner.get_body_sprite(),dt)

func custom_process(dt:float)->void:
	pass

func custom_unhandle_input(event:InputEvent)->void:
	pass




func attack(dt:float)->void:
	pass



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
