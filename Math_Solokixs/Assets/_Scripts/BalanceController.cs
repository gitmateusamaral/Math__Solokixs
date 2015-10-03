using UnityEngine;
using System.Collections;

public class BalanceController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void ChangeScene()
    {
        GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().chances--;
        if (GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().chances < 1)
        { Application.LoadLevel("Menu"); }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag.Equals("Ground"))
        {
			Debug.Log("ground");
			GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().ReInitializeBalance();
            ChangeScene();
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
