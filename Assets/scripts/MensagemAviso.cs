using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensagemAviso : MonoBehaviour {
    public float tempoDaMensagem;
    public Text texto;
    public GameObject objetoGatilho;
    public GameObject objetoAtivador;
    public float      rangeDeAtivacao;

    void Start () {
	}

    void Update () {

        Vector2 objA = objetoAtivador.transform.position; //Posicao do personagem
        Vector2 objB = objetoGatilho.transform.position;  //Posicao do gatilho


        if (Vector2.Distance(objA, objB) <= rangeDeAtivacao) {
            texto.enabled = true;
        } else
        {
            texto.enabled = false;
        }

    }
}
