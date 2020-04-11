extends Node2D

class ActionA extends Action:
	func _init(interval,max_frame).(interval,max_frame):
		pass
	func play_frame(sprite,frame_index_relative:int)->void:
		print("action:%d" % frame_index_relative)


	

var comboMgr =Combo.new()

# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	var actionA = ActionA.new(1,1)
	self.comboMgr.register_actions([actionA])
	self.comboMgr.push_action(actionA)

func _process(dt):
	self.comboMgr.action(null,dt)

