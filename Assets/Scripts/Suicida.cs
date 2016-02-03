using UnityEngine;
using System.Collections;

public class Suicida : MonoBehaviour {

	public float velocidad;
    private bool ventana;
    public GameObject silla;
    private GameManager gm;
    public GameObject Manejador; // asignar el objeto que tiene el Game Manager
    private GameObject caida;
    private Player py;
    public Animator animador;

    bool _IsAndando_ = false;
    bool _Suicidandose = false;

    const int STATE_IDLE = 0;
    const int STATE_COMPUTARING = 1;
    const int STATE_WALKING = 2;
    const int STATE_SUHUECO = 3;
    const int STATE_SUVENTANA = 4;

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
   
    void TriggerEvent(string metodo)
    {
		gm = Manejador.GetComponent<GameManager>();
		py = gameObject.GetComponent<Player>();
		ventana = gm.ventana;
        if (metodo.Equals("suicide"))
        {
           
            if (ventana)
            {
                caida = GameObject.FindGameObjectWithTag("ventana");
                GetComponent<Rigidbody2D>().velocity = new Vector2(caida.transform.position.x, caida.transform.position.y) * velocidad;
                changeState(STATE_WALKING);
            }
            else
            {
                caida = GameObject.FindGameObjectWithTag("hueco");
                GetComponent<Rigidbody2D>().velocity = new Vector2(caida.transform.position.x, caida.transform.position.y) * velocidad;
                changeState(STATE_WALKING);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (ventana)
        {
            changeState(STATE_SUVENTANA);
        }
        else if (other.name.Equals("hueco"))
            changeState(STATE_SUHUECO);
        Destroy(gameObject);
    }

    void OnClickDown()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        GetComponent<Rigidbody2D>().transform.Translate(silla.transform.position * Time.deltaTime);
        changeState(STATE_WALKING);

    }

    void changeState(int state)
    {
        if (_currentAnimationState == state)
            return;
        switch(state){
            case STATE_IDLE:
                animador.SetInteger("state", STATE_IDLE);
                break;
            case STATE_COMPUTARING:
                animador.SetInteger("state", STATE_COMPUTARING);
                break;
            case STATE_WALKING:
                animador.SetInteger("state", STATE_WALKING);
                break;
            case STATE_SUHUECO:
                animador.SetInteger("state", STATE_SUHUECO);
                break;
            case STATE_SUVENTANA:
                animador.SetInteger("state", STATE_SUVENTANA);
                break;

             
        }
        _currentAnimationState = state;
    }
}
