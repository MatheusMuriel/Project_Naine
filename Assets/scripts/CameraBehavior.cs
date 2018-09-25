using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    //Variavel public que representa o objeto (do tipo Transform) que a camera vai seguir
    public Transform ObjASeguir;
    public float velocidade;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        //O Vector3 recebe x, y e z (Que é -40 pois o objeto camera tem que estar atras de tudo)
        transform.position = new Vector3(ObjASeguir.position.x, ObjASeguir.position.y);

    }
}
