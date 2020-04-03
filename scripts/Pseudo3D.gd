extends Node2D

class_name Pseudo3D

# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var z =0;
var speed_vertical=0 ;
var speed_x_scalar =0 ;
var speed_y_scalar =0 ;
var y = 0



func update_pos(dt:float,direction:Vector2):
	self.y += self.speed_y_scalar*direction.y * dt
	self.position.x = self.position.x + self.speed_x_scalar *direction.x* dt
	self.position.y = self.y
	self.z = max(0,self.z + dt  * speed_vertical)
	self.position.y -= self.z

func on_ground()->bool:
	return self.z == 0
# Called when the node enters the scene tree for the first time.
func _ready():
	self.y = self.position.y


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
