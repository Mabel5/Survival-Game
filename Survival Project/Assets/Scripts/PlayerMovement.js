#pragma strict
/**
General Function of Script: Control all motion involved with the character(i.e: walking, jumping, sprinting, etc.)
**/

/*-----------------------------------------------------------------------------------------------------------------------*/

/**
Variables: 
**/	
var moveSpeed = 5;
var strafeSpeed = 3;
var jumpHeight = 6;
var Terrain : Transform;
var isGrounded = false;

function Start () {
}

function OnCollisionStay (coll : Collision)
{
	isGrounded = true;
}

function OnCollisionExit (coll : Collision)
{
	isGrounded = false;
}

function Update () {
	
	//Movement
	if(Input.GetButton("Forward"))
	{
		if(Input.GetButton("Sprint"))
		{
			moveSpeed = 7;
		}
		else
		{
			moveSpeed = 5;
		}

		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
	}

	if(Input.GetButton("Backward"))
	{
		transform.Translate(Vector3.back * Time.deltaTime * strafeSpeed);
	}

	if(Input.GetButton("strafeLeft"))
	{
		transform.Translate(Vector3.left * Time.deltaTime * strafeSpeed);
	}

	if(Input.GetButton("strafeRight"))
	{
		transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed);
	}

	/*if(Input.GetButtonDown("Jump") && isGrounded == true)
	{
		GetComponent.<Rigidbody>().velocity.y = jumpHeight;
	}*/
}

