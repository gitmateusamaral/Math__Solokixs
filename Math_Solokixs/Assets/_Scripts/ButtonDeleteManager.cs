using UnityEngine;
using UnityEngine.UI;

public class ButtonDeleteManager : MonoBehaviour {

    ColorBlock initialBlock;

	void Start () 
    {
        initialBlock = this.gameObject.GetComponent<Button>().colors;
	}

    public void ChangeColor()
    {
        if (Main.deleteMode)
        {
            ColorBlock c = initialBlock;
            c.normalColor = Color.blue;
            c.highlightedColor = Color.blue;
            c.pressedColor = Color.blue;
            this.gameObject.GetComponent<Button>().colors = c;
            Main.deleteMode = false;
        }
        else if (!Main.deleteMode)
        {
            ColorBlock c = initialBlock;
            c.normalColor = Color.red;
            c.highlightedColor = Color.red;
            c.pressedColor = Color.red;
            this.gameObject.GetComponent<Button>().colors = c;
            Main.deleteMode = true;
        }
    }

    void FixedUpdate () 
    {
	    
	}
}
