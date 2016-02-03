using UnityEngine;
using System.Collections;

public class Escapist : MonoBehaviour {

	public float speed;
	private Player ps;
	public Vector2 movement = new Vector2 (0.0f, 0.0f);
	bool escaping = false;
	bool triggered = false;
	
	
	public int contFrames = 0;
	bool wandering = false;
	bool contarFrames = false;
	private GameObject silla;

	// For States
	public Animator animador;
	const int STATE_IDLE = 0;
	const int STATE_WALKING = 1;
	const int STATE_NUDE = 2;
	const int STATE_ESCAPING = 4;

	int _currentAnimationState = STATE_IDLE;
	
	// Use this for initialization
	void Start () {
		silla = GameObject.FindGameObjectWithTag("silla");	
		animador = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (contarFrames) contFrames++;
		if (contFrames > 60){
			contarFrames = false;
			contFrames = 0;
			escaping = false;	
		}
		GetComponent<Rigidbody2D>().velocity = movement;
		GetComponent<Rigidbody2D>().position = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, -8, 8), Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, -5, 5));
	}
	
	void OnMouseOver(){
		//Añadir que no se mueva si no se ha trigereado
		if (triggered){
			if(!escaping){	
				movement =  new Vector2(Random.Range (-1.0f,1.0f), Random.Range (-1.0f,1.0f));
				movement.Normalize();
				movement = movement * speed * 2;
				Debug.Log("Turning!");
				escaping = true;
				contarFrames = true;			
			}
		}
	}
	
	void TriggerEvent (string evento) {
		
		ps = gameObject.GetComponent <Player> ();
		//escaping = true;
		if (evento.Equals("escape")) {
			triggered = true;
			//InvokeRepeating("Wander", 2, 200.0F);			
			if (!wandering) {
				wandering = true;	
				Wander ();
			
			}
			
		}
		
	}
	
	void Wander(){						
		movement =  new Vector2(Random.Range (-1.0f,1.0f), Random.Range (-1.0f,1.0f));
		movement.Normalize();
		movement = movement * speed;
		Debug.Log("Wandering");
		
		
		
	}
	
	
	// Se para la ejecucion de escapista	
	void OnMouseDown () {
		if (triggered){		
			Debug.Log("escapista");
			triggered = false;
			//movement = new Vector2 (0.0f, 0.0f);
			gameObject.transform.Translate(silla.transform.position*Time.deltaTime);
			//transform.position = Vector2.MoveTowards(transform.position, silla.transform.position, Time.deltaTime*speed);
			//movement = new Vector2.MoveTowards(transform.position, silla.transform.position, Time.deltaTime*speed);
			//movement = new Vector2(silla.transform.position.x, silla.transform.position.y) * Time.deltaTime*speed;
		}
	}

	void changeState(int state)
    {
        if (_currentAnimationState == state)
            return;
        switch(state){
            case STATE_IDLE:
                animador.SetInteger("state", STATE_IDLE);
                break;
            case STATE_WALKING:
                animador.SetInteger("state", STATE_WALKING);
                break;
            case STATE_NUDE:
                animador.SetInteger("state", STATE_NUDE);
                break;
            case STATE_ESCAPING:
                animador.SetInteger("state", STATE_ESCAPING);
                break;
        }
        _currentAnimationState = state;
    }
	
	
}
