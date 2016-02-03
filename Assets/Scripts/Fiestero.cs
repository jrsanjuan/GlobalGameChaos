using UnityEngine;
using System.Collections;


public class Fiestero : MonoBehaviour {

    public GameObject fiestero, silla;
    private Player fiestas;
    public Animator animador;

    const int STATE_IDLE = 0;
    const int STATE_COMPUTARING = 1;
    const int STATE_WALKING = 2;
    const int STATE_FIESTEANDO = 3;

    int _currentAnimationState = STATE_IDLE;

    void Start()
    {
        animador = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (transform.position.x == silla.transform.position.x && transform.position.y == silla.transform.position.y)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            changeState(STATE_COMPUTARING);
        }
    }

    void TriggerEvent(string evento)
    {
        if (evento.Equals("party"))
        {
            fiestas = fiestero.GetComponent<Player>();
            fiestas.partying = true;
            changeState(STATE_FIESTEANDO);
            Debug.Log("Fiestero fiesteando!");
        }
        
        
    }
    
    
    
    void OnMouseDown(){
    	fiestas.partying = false;
        changeState(STATE_IDLE);
        transform.Translate(silla.transform.position * Time.deltaTime);
        changeState(STATE_WALKING);

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
            case STATE_COMPUTARING:
                animador.SetInteger("state", STATE_COMPUTARING);
                break;
            case STATE_WALKING:
                animador.SetInteger("state", STATE_WALKING);
                break;
            case STATE_FIESTEANDO:
                animador.SetInteger("state", STATE_FIESTEANDO);
                break;         
        }
        _currentAnimationState = state;
    }

}
