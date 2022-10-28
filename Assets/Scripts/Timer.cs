using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

	public float timer = 0;
	public TextMeshProUGUI textoTimerPro;
	public TextMeshProUGUI ganaste;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	
	timer -= Time.deltaTime;

	if(timer>=0 && ganaste.text.Length <=0){
        textoTimerPro.text = "" + timer.ToString("f0");
	}
	if(timer<=0 && ganaste.text.Length <=0){
        timer = 60;
	}
    }
}
