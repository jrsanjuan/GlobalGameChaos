using UnityEngine;
using System.Collections;

public class FondoController : MonoBehaviour {

	public GameObject[] fondos;
	public int franjaHoraria;

	bool esDia;
	bool esTarde;
	bool esNoche;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(franjaHoraria==0){
			cambiaADia();
		}else if(franjaHoraria==1){
			cambiaATarde();
		}else{
			cambiaANoche();
		}

		fondos[0].SetActive(esDia);
		fondos[1].SetActive(esTarde);
		fondos[2].SetActive(esNoche);

	
	}

	void cambiaADia(){

			esDia=true;
			esTarde=false;
			esNoche=false;

	}

	void cambiaATarde(){
		
			esDia=false;
			esTarde=true;
			esNoche=false;	
	}

	void cambiaANoche(){

			esDia=false;
			esTarde=false;
			esNoche=true;
		
	}
}
