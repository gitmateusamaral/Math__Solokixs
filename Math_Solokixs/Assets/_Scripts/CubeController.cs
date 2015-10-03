using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

    public Vector3 StartPosition;
    public bool isPlayable = false;
    
	public void ReturnStartPos()
	{
		transform.localPosition = StartPosition;
	}

	void Start ()
    { StartPosition = transform.localPosition;  }

    void OnMouseDown()
    {
        if (isPlayable && Main.deleteMode)
        {
            //GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().totalQuantity--;
            GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().deletedPos.Add(transform.position);
            Destroy(gameObject);
        }
    }

	void FixedUpdate () 
    {
	    
	}
}
