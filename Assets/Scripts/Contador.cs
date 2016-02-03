using UnityEngine;
using System.Collections;

public class Contador : MonoBehaviour {

	public GameObject[] numeros;
	public Sprite[] numerosBase;

	public float equivalenciaMundoRealMundoVirtual = 0.25f;
	public float contadorEntreSegundos;

	int hora;
	int minuto;
	string temporizadorString;


	// Use this for initialization
	void Start () {

		hora=48;
		minuto = 0;
		contadorEntreSegundos = 0f;

		//CargamosSpritesNumeros();
		ConstruimosStringTemporizador();

	}
	
	// Update is called once per frame
	void Update () {

		contadorEntreSegundos+= Time.deltaTime;

		if(contadorEntreSegundos>=equivalenciaMundoRealMundoVirtual){

			ConstruimosStringTemporizador();
			minuto--;
			
			if(minuto<0){
				minuto=59;
				hora--;
			}

			contadorEntreSegundos = 0f;


			numeros[0].GetComponent<SpriteRenderer>().sprite = numerosBase[int.Parse(temporizadorString[0].ToString())];
			numeros[1].GetComponent<SpriteRenderer>().sprite = numerosBase[int.Parse(temporizadorString[1].ToString())];
			numeros[2].GetComponent<SpriteRenderer>().sprite = numerosBase[int.Parse(temporizadorString[2].ToString())];
			numeros[3].GetComponent<SpriteRenderer>().sprite = numerosBase[int.Parse(temporizadorString[3].ToString())];

		}


	}

	void ConstruimosStringTemporizador(){

		string horaString;
		string minutoString;

		if(hora<10){
			horaString = "0"+hora.ToString();
		}else{
			horaString = hora.ToString();
		}

		if(minuto<10){
			minutoString = "0"+minuto.ToString();
		}else{
			minutoString = minuto.ToString();
		}

		temporizadorString = horaString+minutoString;

	}

/*	void CargamosSpritesNumeros(){

		sprites = new Sprite[10];
		for(int i=0;i<10;i++){
			Sprite s = Resources.Load <Sprite> (i.ToString());
			sprites[i] = s;
		}

	}
*/

}
