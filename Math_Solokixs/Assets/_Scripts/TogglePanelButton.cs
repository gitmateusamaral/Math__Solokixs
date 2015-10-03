using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TogglePanelButton : MonoBehaviour {

    //object main, irá definir o material do cubo criado
    public Main main;

    //pegando o componente de "GameController"
    void Start()
    { this.main = GameObject.Find("GameController").GetComponent<Main>(); }

    public void ChangeHigh(string dimension)
    {
        main.actualHigh = float.Parse(dimension);
    }

    public void ChangeQuantity()
    {
        if (Mathf.RoundToInt(GetComponent<Scrollbar>().value * 10) <= 6)
        {
            main.actualQuantity = Mathf.RoundToInt(GetComponent<Scrollbar>().value * 10) ;
            GetComponentInChildren<Text>().text = "Quantos? " + main.actualQuantity.ToString();
        }
        else
        {
            main.actualQuantity = 6;
            GetComponentInChildren<Text>().text = "Quantos? " + main.actualQuantity.ToString();
        }
    }

    //função que modificara a string "actualCube", para que ela seja igual ao material clicado
    public void ChangeMaterial()
    { main.actualMaterial = this.gameObject.name; Debug.Log(gameObject.name); }

    public void ChangePoligon()
    { main.actualPoligon = this.name; }

    //debug para verificar qual material foi clicado
    void FixedUpdate()
    { }

    //inverter o estado ativo/desativo de um painel
	public void TogglePanel (GameObject panel)
	{ panel.SetActive(!panel.activeSelf); }

    //ativar painel
    public void ActivePanel (GameObject painel)
    { painel.SetActive(true); }

    //desativar painel
    public void DesablePanel (GameObject painel)
    { painel.SetActive(false); }
}
