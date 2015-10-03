using UnityEngine;
using System.Collections;

public class Round : MonoBehaviour 
{
	public float m = 2;
    public GameObject orbitalTarget;
	private Quaternion targetRotation;
    public GameObject[] gangorras;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, orbitalTarget.transform.position, 1f);
        orbitalTarget = gangorras[Main.actualGangorra];

        
    }

	void Start()
	{ targetRotation = transform.rotation; }

	void FixedUpdate () 
	{
		Vector3 q = targetRotation.eulerAngles;
        
		if (Input.GetMouseButton(1) && Input.GetAxis("Mouse X") > 0) 
		{
			//transform.Rotate(new Vector3(0,m,0));
			q += new Vector3(0,m,0);
		}
		else if (Input.GetMouseButton(1) && Input.GetAxis("Mouse X") < 0) 
		{
			//transform.Rotate(new Vector3(0,-m,0));
			q += new Vector3(0,-m,0);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 ) 
		{
			//Camera.main.fieldOfView += -m;
            Camera.main.transform.Translate(0, 0, 100 * Time.deltaTime);
		}
        if (Input.GetAxis("Mouse ScrollWheel") < 0 ) 
		{
			//Camera.main.fieldOfView += m;
            Camera.main.transform.Translate(0, 0, -100 * Time.deltaTime);
		}
		if (Input.GetAxis ("Mouse Y") > 0 && Input.GetMouseButton (1)  && q.x >= 1) 
		{
			//transform.Rotate (new Vector3(-m,0,0));
			q += new Vector3(-m,0,0);
		}
		else if (Input.GetAxis ("Mouse Y") < 0 && Input.GetMouseButton (1) && q.x <= 45) 
		{
			//transform.Rotate (new Vector3(m,0,0));
			q += new Vector3(m,0,0);
		}
		targetRotation = Quaternion.Euler (FixR(q.x), FixR(q.y), 0);
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 0.1f);
		//transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

	}

	float FixR(float f)
	{
		/*while (f > 360)
			f -= 360;
		while (f < 0)
			f += 360;
		return f;*/
		return f%360;
	}
}