using UnityEngine;
using System.Collections;

public class SpawMenuBlock : MonoBehaviour {

    public GameObject Cube;

	void Start () 
    {
        StartCoroutine(Spaw());
	}
	
    IEnumerator Spaw()
    {
        yield return new WaitForSeconds(Random.Range(1,5));
        Instantiate(Cube, this.transform.position, Quaternion.identity);

        StartCoroutine(Spaw()); 
    }

	void Update () 
    {
	
	}
}
