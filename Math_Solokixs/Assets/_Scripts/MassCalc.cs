using UnityEngine;
using System.Collections;

public class MassCalc : MonoBehaviour {

	void Start () 
    {
		if(gameObject.layer.Equals(8))
		{ rigidbody.mass = CubeMass(transform.localScale,gameObject.tag); }

        else if (gameObject.layer.Equals(9))
		{ rigidbody.mass = CylinderMass(transform.localScale, gameObject.tag); }
	}

	float CubeMass(Vector3 Scale, string material)
	{
        float p;

		switch (material) 
		{
			case "Ferro":
				p = Scale.x*Scale.y*Scale.z*7.5f;
				break;
			case "Madeira":
				p = Scale.x*Scale.y*Scale.z*1.25f;
				break;
            case "Ouro":
                p = Scale.x * Scale.y * Scale.z * 20f;
                break;
            case "Plastico":
                p = Scale.x * Scale.y * Scale.z * 1.05f;
                break;
            case "Chumbo":
                p = Scale.x * Scale.y * Scale.z * 11.5f;
                break;
            case "Diamante":
                p = Scale.x * Scale.y * Scale.z * 3.5f;
                break;
            case "Mercurio":
                p = Scale.x * Scale.y * Scale.z * 13f;
                break;
            case "Poliestireno":
                p = Scale.x * Scale.y * Scale.z * 1f;
                break;
			default:
				p = Scale.x*Scale.y*Scale.z*1;
				break;
		}
        return p;
	}


	float CylinderMass(Vector3 Scale, string material)
	{
        float p;
		switch (material) 
		{
            case "Madeira":
                p = (Mathf.PI * Scale.x * Scale.y * Scale.z) * 1.25f;
                break;
			case "Ferro":
				p = (Mathf.PI*Scale.x*Scale.y*Scale.z)*7.5f;
				break;
            case "Ouro":
                p = (Mathf.PI * Scale.x * Scale.y * Scale.z) * 20f;
                break;
            case "Plastico":
                p = (Mathf.PI * Scale.x * Scale.y * Scale.z) * 1.05f;
                break;
            case "Chumbo":
                p = (Mathf.PI * Scale.x * Scale.y * Scale.z) * 11.5f;
                break;
            case "Diamante":
                p = (Mathf.PI * Scale.x * Scale.y * Scale.z) * 3.5f;
                break;
            case "Mercurio":
                p = (Mathf.PI * Scale.x * Scale.y * Scale.z) * 13f;
                break;
            case "Gelo":
                p = (Mathf.PI * Scale.x * Scale.y * Scale.z) * 1f;
                break;
            default:
                p = (Mathf.PI * Scale.x * Scale.y * Scale.z) * 1f;
                break;
		}
        return p;
	}
}
