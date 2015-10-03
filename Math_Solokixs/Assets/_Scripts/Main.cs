using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

    public static int actualGangorra = 0;
    public string actualMaterial;
    public string actualPoligon;
    public int actualQuantity;
    public GameObject actualPuzzle;
    public GameObject[] shapes;
    public float actualHigh;
    //public float actualSize = 1;
    public float totalQuantity = 0;
    public static bool deleteMode = false;

    public List<GameObject> buttons = new List<GameObject>();

    public GameObject[] Lifes = new GameObject[3];
    public int chances;

    public List<Vector3> deletedPos = new List<Vector3>();

    public void ChangeBalance()
    {
        for(int i = 0;i< buttons.Count;i++)
        {
            buttons[i].SetActive(true);
        }
        if(actualGangorra.Equals(1))
        {
            buttons[3].SetActive(false);
        }
        else if (actualGangorra.Equals(2))
        {

        }



        GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().totalQuantity = 0;
        GameObject.FindGameObjectWithTag("Main").GetComponent<Main>().deletedPos.Clear();
        actualGangorra++;
    }

    public void ReInitializeBalance()
    {
        CubeController[] c = actualPuzzle.transform.GetComponentsInChildren<CubeController>();
        foreach (CubeController cube in c)
        {
			cube.ReturnStartPos();
			cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
			cube.transform.rotation = Quaternion.identity;
			cube.GetComponent<Rigidbody>().maxAngularVelocity = 0;
            cube.GetComponent<Rigidbody>().useGravity = false;
        }
		BalanceController b = actualPuzzle.GetComponentInChildren<BalanceController> ();
		b.gameObject.transform.localRotation = Quaternion.identity;
		b.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		b.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;

    }


    /*
    public void InstatiateCostume(GameObject obj, Vector3 vector3, Texture3D texture, string tag)
    { 
        Instantiate(obj,vector3, this.transform.rotation);
        obj.tag = tag;
    }
    */


    public void SpawnObject()
    {
        if (actualHigh != 0 && !string.IsNullOrEmpty(actualMaterial) && !string.IsNullOrEmpty(actualPoligon))
        {
            Vector3 t = GameObject.FindGameObjectWithTag("Round").GetComponent<Round>().orbitalTarget.transform.FindChild("InstantiateSPoint").position;
            GameObject obj = new GameObject();
            #region Select Material Cubo
            if (actualPoligon.Equals("Cubo"))
            {
                switch (actualMaterial)
                {

                    case "Ferro":
                        obj = shapes[2];
                        break;
                    case "Madeira":
                        obj = shapes[1];
                        break;
                    case "Ouro":
                        obj = shapes[5];
                        break;
                    case "Poliestireno":
                        obj = shapes[4];
                        break;
                    case "Chumbo":
                        obj = shapes[7];
                        break;
                    case "Diamante":
                        obj = shapes[6];
                        break;
                    case "Mercúrio":
                        obj = shapes[3];
                        break;
                    default:
                        obj = shapes[0];
                        break;
                }
            }
            #endregion

            #region Select Material Cilindro

            if (actualPoligon.Equals("Cilindro"))
            {
                Debug.Log("é cilindro");

                switch (actualMaterial)
                {
                    case "Ferro":
                        obj = shapes[10];
                        break;
                    case "Madeira":
                        obj = shapes[9];
                        break;
                    case "Ouro":
                        obj = shapes[13];
                        break;
                    case "Poliestireno":
                        obj = shapes[12];
                        break;
                    case "Chumbo":
                        obj = shapes[15];
                        break;
                    case "Diamante":
                        obj = shapes[14];
                        break;
                    case "Mercúrio":
                        obj = shapes[11];
                        break;
                    default:
                        obj = shapes[8];
                        break;
                }
            }

            #endregion


            float x = totalQuantity % 2;
            float y = (totalQuantity - (totalQuantity % 2)) / 2;
            if (actualPoligon.Equals("Cilindro"))
            {
                obj.transform.localScale = new Vector3(0.5f, actualHigh, 0.5f);
            }
            else
            {
                obj.transform.localScale = new Vector3(actualHigh, actualHigh, actualHigh);
            }
            if (deletedPos.Count == 0)
            {
                obj.transform.position = new Vector3(t.x, t.y + (2f * y) /*+(actualHigh*(g-1))*/, t.z - (2f * x));
            }

            else
            {
                obj.transform.position = deletedPos[0];
                deletedPos.RemoveAt(0);
            }
            GameObject o = (GameObject)Instantiate(obj);
            o.transform.parent = actualPuzzle.transform;
            totalQuantity++;
        }
     }
        void Start ()
        { 
            this.actualMaterial = ""; this.actualPoligon = ""; this.chances = 3; 
            
        
        }

	    void FixedUpdate ()
        {
            
	    }
    }


