using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Porteria : MonoBehaviour
{
	//Audio Source
	AudioSource fuenteDeAudio;
	//Clips de audio
	public AudioClip audioFin;
	public TextMeshProUGUI ganaste;
	
	void Start()
    {
     
     //Recupero el componente audio source;
	fuenteDeAudio = GetComponent<AudioSource>();

    }

	

   //detecto si la bola atraviesa la porteria
	void OnTriggerEnter2D(Collider2D bola) {
		
		if (bola.name == "Bola"){
		//Si es la portería izquierda
		if (this.name == "Izquierda"){
		//Cuento el gol y reinicio la bola
		bola.GetComponent<Bola>().reiniciarBola("Derecha");
		}
		//Si es la portería derecha
		else if (this.name == "Derecha"){
		//Cuento el gol y reinicio la bola
		bola.GetComponent<Bola>().reiniciarBola("Izquierda");
		
	    	}
	
	}
	
	}
	
	


	
}
