using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeControler : MonoBehaviour {

    public int playTime = 0;
    public GameObject spawPoint;

    public int minutes = 0;
    public int seconds = 0;
    public int hours = 0;
    public int days = 0;
    public GameObject button;

	void Start ()
    {
        //Time.timeScale = 0;
        this.button = GameObject.Find("ButtonTry");
        this.spawPoint = GameObject.Find("InstantiateSPoint");
        StartCoroutine(PlayTimer());
         
	}
    
    IEnumerator Victory(int sec)
    {
		int b = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().chances;
        yield return new WaitForSeconds(sec);
		if (b == GameObject.FindGameObjectWithTag ("Main").GetComponent<Main> ().chances)
        { GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().ChangeBalance(); }
        this.playTime = 0;
        this.seconds = 0;
       // this.spawPoint.transform.position = new Vector3(94.3f, 1.2f, -1.83f);
    }


    public void BeginTime()
    {
        StartCoroutine(Victory(5));
        Rigidbody[] r = GameObject.FindGameObjectWithTag("Round").GetComponent<Round>().orbitalTarget.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody childR in r)
        {
            childR.useGravity = true;
            childR.isKinematic = false;
        }



       //if (this.name.Equals("Time"))
      // { /*this.button.SetActive(false);*/ }
       Time.timeScale = 1;
    }

    IEnumerator PlayTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            this.playTime += 1;
            this.seconds = (playTime % 60);
            this.minutes = (playTime / 60) % 60;
            this.hours = (playTime / 3600) % 24;
            this.days = (playTime / 86400) % 365;
        }
    }

	void FixedUpdate () 
    {
        if (this.name.Equals("Time"))
        { this.GetComponent<Text>().text = seconds.ToString() + "/" + 60; }

        if(this.seconds > 58)
        { GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().chances--; }

       // Debug.Log("Segundos: " + seconds.ToString() + "  " + "Minutos" + minutes.ToString());
	}
}
