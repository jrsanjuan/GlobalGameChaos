using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	int contadorActivacion;
	int sleepyCounter;
	public float rateContagious = 0.05f;
	int contFramesTrigger = 0;
	
	public GameObject manager;




	//Variables generales del player
	public float baseProductivityRate; 
	public float baseTirednessRate;
	public float tiredness;
	public float productivity;
	public float tiredIncrease;
	public bool slept;
	public bool partying;
	public int sleepingFrames;
	
	
	//booleans que dictan los comportamientos exclusivos de cada player y sus probabilidades
	public bool suicide = false;
	public float suicideChance; //si true, mandar suicide
	public bool party = false;
	public float partyChance;
	public bool fat = false;
	public float chipsIncrease;
	public bool perfect = false;
	public float perfectChance;
	public bool escapist = false;
	public float escapeChance;
	public bool smoker = false;
	
	//bool de traits?
	public bool productive = false;
	public bool counterProductive = false;
	public bool tiry = false;
	public bool fresh = false;
	
	
	//
	//public GameObject playerPrefab;
	public GameObject[] players;
	
	
	//Probabilidades base de que pasen ciertos eventos (a todos los players!)
	public float probBaseGatitos;
	//public float probBaseSleepy;
	
	
		
	
	// Use this for initialization
	void Start () {
		
		//Lista de players
		if (players == null)
			players = GameObject.FindGameObjectsWithTag("Player");	
	
	
		partying = false;
		contadorActivacion = 1;
		sleepyCounter = 0;
		
		//Valores por defecto
		baseProductivityRate = 1;
		baseTirednessRate = 0.5f;
		tiredIncrease = 0.5f;		
		
		//Aplico traits
		if (productive){		
			baseProductivityRate *= 1.2f; 
			productivity *= 1.2f;
			}
		if (counterProductive)
			baseProductivityRate *= 0.8f; 
			productivity *= 0.8f;
		if (tiry)
			baseTirednessRate *= 1.2f;
		if (fresh)
			baseTirednessRate *= 0.8f;
			
			
		
		
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {	
		
		contFramesTrigger++;
		
		if (!slept){	
				
			if (contadorActivacion%60 == 0)
				UpdateTiredness (tiredIncrease);
			contadorActivacion++;	
			if (tiredness > 100){
				slept = true;
			}else{			
				//gameObject.SendMessage("UpdateGameProgress", productivity);
				manager.GetComponent<GameManager>().progreso += productivity;
			}
			if (contFramesTrigger%60 == 0)
				TriggerEvents ();
		}
		sleepyCounter++;
		if (sleepyCounter > sleepingFrames){
			sleepyCounter = 0;
			slept = false;
		}
		if (partying){
			productivity = 0;
			ContagiarParty();
		}
		
	
	}
	
	void TriggerEvents(){
		if (suicide){			
			if (Random.value < suicideChance*FuncionProbabilidadPorCansancio())	
				gameObject.SendMessage("TriggerEvent", "suicide");		
		}
		if (party){			
			if (Random.value < partyChance*FuncionProbabilidadPorCansancio())	
				gameObject.SendMessage("TriggerEvent", "party");		
		}
		if (perfect){			
			if (Random.value < perfectChance*FuncionProbabilidadPorCansancio())	
				gameObject.SendMessage("TriggerEvent", "perfectionist");		
		}
		/*
		if (smoker){			
			if (Random.value < perfectChance+(tiredness/50))	
				gameObject.SendMessage("TriggerEvent", "smoke");		
		}
		*/
		if (escapist){			
			if (Random.value < escapeChance*FuncionProbabilidadPorCansancio())	
				gameObject.SendMessage("TriggerEvent", "escape");		
		}
		
	}
	
	
	void UpdateProductivity(float ammount){
		productivity = productivity + ammount;
	}
	
	
	void UpdateTiredness(float ammount){
		tiredness = tiredness + ammount;		
	}
	
	void Rest(){
		tiredness = 0;
	}
	
	float FuncionProbabilidadPorCansancio(){
		return tiredness/10;
	}
	
	
	void OnMouseDown(){
		if (partying){
			partying = false;
			productivity = baseProductivityRate;
		}
	}
	
	void ContagiarParty(){
		foreach (GameObject player in players) {
			if (true) {
				Debug.Log("CAsi Contagiado!");
				player.GetComponent<Player>().partying = true;
				Debug.Log("Contagiado!");
			}
		}
	}
	
	
	
	
}
