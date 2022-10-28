using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    // Start is called before the first frame update
    //Velocidad
    public float velocidad= 30.0f;
    public string eje;
    public string ejeh;
    public float pos;
    public Collision2D micolision;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () {
	//Capto el valor del eje vertical de la raqueta
	float v = Input.GetAxisRaw(eje);
	if(v!=0)
	{
	//Modifico la velocidad de la raqueta
	GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * velocidad);
	

	}
	else
	{
	
	if(GameObject.Find("RaquetaIzquierda").transform.position.x >= -5 || GameObject.Find("RaquetaIzquierda").transform.position.x <= -58){
	GameObject.Find("RaquetaIzquierda").transform.position = new Vector2(-50,GameObject.Find("RaquetaIzquierda").transform.position.y);
	}else if(GameObject.Find("RaquetaDerecha").transform.position.x <= 5 || GameObject.Find("RaquetaDerecha").transform.position.x >= 58){
	GameObject.Find("RaquetaDerecha").transform.position = new Vector2(50,GameObject.Find("RaquetaDerecha").transform.position.y);
	}
	
	pos= transform.position.x;
	Debug.Log("pos is " + pos);
	float vh = Input.GetAxisRaw(ejeh);
	GetComponent<Rigidbody2D>().velocity = new Vector2(vh * velocidad, 0);
	}
        
	
	
	}

}
