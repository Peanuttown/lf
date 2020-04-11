extends Node

class_name Combo

var actions = []

signal combo_over
var sig_combo_over_switch=false

func register_actions(actions)->void:
	for action in actions:
		assert(self.has_method("handle_action_over"))
		(action as Action).connect_action_over(self,"handle_action_over")

func handle_action_over()->void:
	self.actions.pop_front()

func push_action(action:Action)->void:
	if !self.has_action():
		self.sig_combo_over_switch = false
	self.actions.push_back(action)

func has_action()->bool:
	return self.actions.size()>0

func combo_end()->void:
	if !self.sig_combo_over_switch:
		self.sig_combo_over_switch = !self.sig_combo_over_switch
		emit_signal("combo_over")

func action(dt):
	if !self.has_action():
		self.combo_end()
		return
	self.actions.front().action(dt)
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
