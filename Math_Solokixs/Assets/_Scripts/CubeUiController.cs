using UnityEngine;
using System.Collections;

public class CubeUiController : MonoBehaviour {


    public Main main;

	void Start () 
    {
        this.main = GameObject.Find("GameController").GetComponent<Main>();
	}
	
    void ChancesControl()
    {
        if(this.name.Equals("Cube3") && this.main.chances < 3)
        { Destroy(gameObject); }
        if (this.name.Equals("Cube2") && this.main.chances < 2)
        { Destroy(gameObject); }
        if (this.name.Equals("Cube1") && this.main.chances < 1)
        { Destroy(gameObject); }
    }

	void FixedUpdate () 
    {
        ChancesControl();
	}
}
