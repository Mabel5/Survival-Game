/**
General Function of Script: Make the camera follow the mouse(along all axis')
& to rotate the character (along only x axis)
**/

/*-----------------------------------------------------------------------------------------------------------------------*/

/**
Variables: 
**/	
enum Axes {MouseXandY, MouseX, MouseY}
var Axis : Axes = Axes.MouseXandY;

var sensitivity = 5;

var minimumX = -360;
var maximumX = 360;

var maximumY = 90;
var minimumY = -90;

var rotationX = 0;
var rotationY = 0;

var lookSpeed = 0;

function Start () {
	/*if(GetComponent.<Rigidbody>())
	{
		GetComponent.<Rigidbody>().freezeRotation = true;
	}*/
}

function Update () {
	if (Axis == Axes.MouseXandY)
	{
		rotationX += Input.GetAxis("MouseX") * sensitivity;
		rotationY += Input.GetAxis("MouseY") * sensitivity;

		Adjust360Clamp();

		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
	}
	else if (Axis == Axes.MouseX)
	{
		rotationX += Input.GetAxis("MouseX") * sensitivity;

		Adjust360Clamp();

		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
	}
	else if (Axis == Axes.MouseY)
	{
		rotationY += Input.GetAxis("MouseY") * sensitivity;

		Adjust360Clamp();

		transform.localRotation = Quaternion.AngleAxis(rotationY, Vector3.left);
	}
}

function Adjust360Clamp ()
{
	if (rotationX < -360)
	{
		rotationX += 360;
	}
	else if (rotationX > 360)
	{
		rotationX -= 360;
	}

	if (rotationY < -360)
	{
		rotationY += 360;
	}
	else if (rotationY > 360)
	{
		rotationY -= 360;
	}

	rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
	rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
}
