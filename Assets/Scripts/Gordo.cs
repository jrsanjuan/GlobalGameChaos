using UnityEngine;
using System.Collections;

public class Gordo : MonoBehaviour {

	public GameObject Comilon;
	public GameObject Patatas;
	private float patataTiempo;
	private float coolDown;
	private float maxHambre = 80f;
	private float curHambre = 40f;

	// For states
	public Animator animador;
	const int STATE_IDLE = 0;
	const int STATE_ANDA = 1;
	const int STATE_COME = 2;

	int _currentAnimationState = STATE_IDLE;

	// Use this for initialization
	void Start () {
		animador = GetComponent<Animator>();
		patataTiempo = 0;
		coolDown = 1.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (20f<curHambre && curHambre<60f)
		{
			Comilon.gameObject.transform.localScale = new Vector3(curHambre/3f,20,1);
		}
		if (patataTiempo > 0) {
			patataTiempo -= Time.deltaTime;		
		} 
		else if (patataTiempo < 0) 
		{
			patataTiempo = 0;
		}
		
		if (patataTiempo == 0) {
				cogerPatata ();
				patataTiempo = coolDown;
		}
	}

	private void cogerPatata(){
			
		var distance = Vector2.Distance (Comilon.transform.position, Patatas.transform.position);
			
		if (curHambre < 1)
		{
			curHambre = 0;
		}	
		if (curHambre > maxHambre) 
		{
			curHambre = maxHambre;	
		}
		if (distance < 25)
		{
			curHambre+=1;
		}
		else if (distance > 25)
		{
			curHambre-=1;
		}
		
	}

	void changeState(int state)
    {
        if (_currentAnimationState == state)
            return;
        switch (state)
        {
            case STATE_IDLE:
                animador.SetInteger("state", STATE_IDLE);
                break;
            case STATE_ANDA:
                animador.SetInteger("state", STATE_ANDA);
                break;
            case STATE_COME:
                animador.SetInteger("state", STATE_COME);
                break;
        }
        _currentAnimationState = state;
    }		
}