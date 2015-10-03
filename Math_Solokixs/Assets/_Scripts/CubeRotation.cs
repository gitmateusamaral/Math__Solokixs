using UnityEngine;
using System.Collections;

public class CubeRotation : MonoBehaviour {

	Quaternion rotate = new Quaternion();

	void FixedUpdate () 
    {
		rotate.eulerAngles = new Vector3(rotate.eulerAngles.y + 20*Time.deltaTime,rotate.eulerAngles.y + 20*Time.deltaTime,0);
		transform.rotation = rotate;
	}

	float fixR(float f)
	{ return f % 360; }

}
