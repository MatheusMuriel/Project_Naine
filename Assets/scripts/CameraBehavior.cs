using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    //Variavel public que representa o objeto (do tipo Transform) que a camera vai seguir
    public Transform ObjASeguir;

    //Variavel para compensar a altura da camera, pois ela fica muito baixa se pegar só o eixo Y do personagem
    public float compensacaoDoChao;

    public Transform finalEsquerda;  // End of screen Left
    public Transform finalDireita;  //End of Screen Right

    public float compensacaoFimDoCenario;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		if (Vector2.Distance(ObjASeguir.position, finalEsquerda.position) >= compensacaoFimDoCenario && Vector2.Distance(ObjASeguir.position, finalDireita.position) >= compensacaoFimDoCenario) {
            //Muda normal
            transform.position = new Vector3(ObjASeguir.position.x, (ObjASeguir.position.y + compensacaoDoChao), -40);
        } else
        {
            //Não muda o eixo X
            transform.position = new Vector3(transform.position.x, (ObjASeguir.position.y + compensacaoDoChao), -40);
        }

        //O Vector3 recebe x, y e z (Que é -40 pois o objeto camera tem que estar atras de tudo)
        //transform.position = new Vector3(ObjASeguir.position.x, (ObjASeguir.position.y + compensacaoDoChao), -40);
    }
}