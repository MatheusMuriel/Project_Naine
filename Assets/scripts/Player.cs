using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade;
    public float forcaPulo;

    private bool verificaChao;
    private bool estaAbaixado;

    public Transform chaoVerificador;

    public Transform spritePlayer;
    private Animator animator;



    public GameObject player;
	private Vector3 offset; 


    // Inicializa��o
    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
		offset = transform.position - player.transform.position;
    }

    // Update() � chamado uma vez por frame
    void Update()
    {
        Movimentacao();



    }

    void Movimentacao()
    {
        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        verificaChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));
        animator.SetBool("chao", verificaChao);     //"chao" � o Bool criado no animator
        

        //Para a direita
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        //Para esquerda
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        
      
        //Pulando
        if (Input.GetButtonDown("Jump") && verificaChao)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }

        //Abaixando
        estaAbaixado = Input.GetAxisRaw("Vertical") < 0;
        animator.SetBool("abaixado", estaAbaixado);  //"abaixado" � o Bool criado no animator

    }
	
	    // LateUpdate() � chamado depois de cada atualiza��o de frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //Define a posi��o da camera para ser igual a do personagem, sendo compensada pela variavel offset
        transform.position = player.transform.position + offset;
    }
}