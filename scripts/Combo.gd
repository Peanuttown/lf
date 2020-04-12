extends Node

class_name Combo

var actions = []
var registerd_actions=[]
var action_count = 0
var action_index =0

signal combo_over
var sig_nm_combo_over ="combo_over"
var sig_combo_over_switch=false

func register_actions(actions)->void:
	for action in actions:
		assert(self.has_method("handle_action_over"))
		(action as Action).connect_action_over(self,"handle_action_over")
		self.registerd_actions= actions

func handle_action_over()->void:
	self.action_count -=1
	self.action_index = (self.action_index + 1) % self.registerd_actions.size()


func has_action()->bool:
	return self.action_count > 0

func combo_clear()->void:
		self.action_index=0

func combo_end()->void:
	if !self.sig_combo_over_switch:
		self.sig_combo_over_switch = !self.sig_combo_over_switch
		self.combo_clear()
		emit_signal(sig_nm_combo_over)

func action_incr():
	if self.action_count ==0:
		self.sig_combo_over_switch = false
	self.action_count +=1

func action(sprite,dt):
	if !self.has_action():
		self.combo_end()
		return
	self.registerd_actions[self.action_index].action(sprite,dt)

func connect_combo_over(target,method)->void:
	assert(target.has_method(method))
	self.connect(sig_nm_combo_over,target,method)

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
