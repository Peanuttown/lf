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
class ActionB extends Action:
	func _init(interval,frame_releative_index).(interval,frame_releative_index):
		pass
	func play_frame(sprite,frame)->void:
		sprite.frame=frame+12
	
var actionA = ActionA.new(0.1,1)
var actionB = ActionB.new(0.1,1)

func _ready():
	self.state_name = "attack"
	self.comboMgr.register_actions([actionA,actionB])
	self.comboMgr.connect_combo_over(self,"handle_combo_over")

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
