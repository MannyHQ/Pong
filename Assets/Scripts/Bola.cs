using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    // Start is called before the first frame update
	//Velocidad de la pelota
	public float velocidad = 30.0f;

	//Audio Source
	AudioSource fuenteDeAudio;
	//Clips de audio
	public AudioClip audioGol, audioRaqueta, audioRebote,audioFin,audioInicio;

	//Contadores de goles
	public int golesIzquierda = 0;
	public int golesDerecha = 0;
	
	//Cajas de texto de los contadores
	public TextMeshProUGUI contadorIzquierda;
	public TextMeshProUGUI contadorDerecha;
	public TextMeshProUGUI ganaste;
	public TextMeshProUGUI temporizador;

    void Start()
    {
     //Velocidad inicial hacia la derecha
     	GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;   
     //Recupero el componente audio source;
	fuenteDeAudio = GetComponent<AudioSource>();
	//Pongo los contadores a 0
	contadorIzquierda.text = golesIzquierda.ToString();
	contadorDerecha.text = golesDerecha.ToString();
	ganaste.text="";
	fuenteDeAudio.clip = audioInicio;
	fuenteDeAudio.Play();
	velocidad = 30.0f;
	
    }
    

    void OnCollisionEnter2D(Collision2D micolision){
	//Col contiene toda la información de la colisión
	//Si la bola colisiona con la raqueta:
	// micolision.gameObject es la raqueta
	// micolision.transform.position es la posición de la raqueta
	
	
	if (micolision.gameObject.name == "RaquetaIzquierda"){
	//Valor de x
	int x = 1;
	//Valor de y
	int y = direccionY(transform.position,
	micolision.transform.position);
	//Calculo dirección
	Vector2 direccion = new Vector2(x, y);
	//Aplico velocidad
	GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
	//Reproduzco el sonido de la raqueta
	fuenteDeAudio.clip = audioRaqueta;
	fuenteDeAudio.Play();
	}

	if (micolision.gameObject.name == "RaquetaDerecha"){
	//Valor de x
	int x = -1;
	//Valor de y
	int y = direccionY(transform.position,
	micolision.transform.position);
	//Calculo dirección (normalizada para que de 1 o -1)
	Vector2 direccion = new Vector2(x, y);
	//Aplico velocidad
	GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
	//Reproduzco el sonido de la raqueta
	fuenteDeAudio.clip = audioRaqueta;
	fuenteDeAudio.Play();
	}
	
	//Para el sonido del rebote
	if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo"){
	//Reproduzco el sonido del rebote
	fuenteDeAudio.clip = audioRebote;
	fuenteDeAudio.Play();
  	}
}

	int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
		if (posicionBola.y > posicionRaqueta.y){
		return 1;
		}
		else if (posicionBola.y < posicionRaqueta.y){
		return -1;
		}
		else{
		return 0;
		}
        }
	
	void sonidoGanar(){
	fuenteDeAudio.clip = audioFin;
	fuenteDeAudio.Play();
	}
	IEnumerator waiter()
    	{
     
        //Wait for 8 seconds
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Inicio");



    	}
	
	public void reiniciarBola(string direccion){
		
		
		//Posición 0 de la bola
		transform.position = Vector2.zero;
		//Vector2.zero es lo mismo que new Vector2(0,0);
		//Velocidad inicial de la bola
		//velocidad = 30;
		//Velocidad y dirección

		if (direccion == "Derecha"){
		//Incremento goles al de la derecha
		golesDerecha++;
		velocidad = velocidad + 7.0f;
		//Lo escribo en el marcador
		contadorDerecha.text = golesDerecha.ToString();
		//Reinicio la bola
		GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
		
		//Vector2.right es lo mismo que new Vector2(1,0)
		}
		else if (direccion == "Izquierda"){
		//Incremento goles al de la izquierda
		golesIzquierda++;
		velocidad = velocidad + 7.0f;
		//Lo escribo en el marcador
		contadorIzquierda.text = golesIzquierda.ToString();
		//Reinicio la bola
		GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
		//Vector2.right es lo mismo que new Vector2(-1,0)
		}
	//Reproduzco el sonido del gol
	fuenteDeAudio.clip = audioGol;
	fuenteDeAudio.Play();
		if(golesDerecha == 5){
		fuenteDeAudio.clip = audioFin;
		fuenteDeAudio.Play();
		GetComponent<Rigidbody2D>().velocity = Vector2.left * 0;
		StartCoroutine(waiter());
		}else if(golesIzquierda == 5){
		fuenteDeAudio.clip = audioFin;
		fuenteDeAudio.Play();
		GetComponent<Rigidbody2D>().velocity = Vector2.left * 0;
		StartCoroutine(waiter());
		}

	}
	

	
	void FixedUpdate(){
	//Incremento la velocidad de la bola
	//velocidad = velocidad + 0.01f;
	if(golesIzquierda== 5){
	
	ganaste.text="Ganador jugador 1";
	
	

	}else if(golesDerecha==5){

	
	ganaste.text="Ganador jugador 2";
		
	

	}else if(int.Parse(temporizador.text)==0 && golesDerecha>golesIzquierda){
		ganaste.text="Ganador jugador 2";
	
		transform.position = Vector2.zero;
		
		GetComponent<Rigidbody2D>().velocity = Vector2.left * 0;
		StartCoroutine(waiter());

	}else if(int.Parse(temporizador.text)==0 && golesIzquierda>golesDerecha){
		transform.position = Vector2.zero;
		ganaste.text="Ganador jugador 1";
		
		GetComponent<Rigidbody2D>().velocity = Vector2.left * 0;
		StartCoroutine(waiter());
	

	}

	

	}



}
