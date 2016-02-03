using UnityEngine;
using System.Collections;

public class Fumador : MonoBehaviour {

    private GameManager gm;
	private Player pt ;
    public GameObject Manejador; // asignar el objeto que tiene el Game Manager
    private GameObject ventana, silla;
    public Animator animador;

    const int STATE_IDLE = 0;
    const int STATE_COMPUTARING = 1;
    const int STATE_WALKING = 2;
    const int STATE_SMOKING = 3;

    int _currentAnimationState = STATE_IDLE;
    void Start()
    {
		pt = gameObject.GetComponent<Player>();
        gm = Manejador.GetComponent<GameManager>();
        ventana = GameObject.FindGameObjectWithTag("ventana");
        silla = GameObject.FindGameObjectWithTag("silla");
        animador = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (gm.ventana)
        {
            changeState(STATE_WALKING);
            gameObject.transform.Translate(ventana.transform.position * Time.deltaTime);
            if (transform.position == ventana.transform.position)
            {
                changeState(STATE_SMOKING);
                if (pt.tiredness < 100)
                    pt.tiredness += 2 * Time.deltaTime;
            }
        }
        else
        {
            if (GetComponent<Rigidbody2D>().transform.position.x != silla.transform.position.x && GetComponent<Rigidbody2D>().transform.position.y != silla.transform.position.y)
            {
                changeState(STATE_WALKING);
                gameObject.transform.Translate(silla.transform.position * Time.deltaTime);
            }
            else
            {
                changeState(STATE_COMPUTARING);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
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
            case STATE_COMPUTARING:
                animador.SetInteger("state", STATE_COMPUTARING);
                break;
            case STATE_WALKING:
                animador.SetInteger("state", STATE_WALKING);
                break;
            case STATE_SMOKING:
                animador.SetInteger("state", STATE_SMOKING);
                break;
        }
        _currentAnimationState = state;
    }

}
