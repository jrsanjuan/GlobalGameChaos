using UnityEngine;
using System.Collections;

public class MovimientoPesao : MonoBehaviour {

    public GameObject fumeta, anclaje;
    public int contador;
    private bool controlador;
	private Player pF;
	public GameObject gameManager;
	private GameManager gm;
	void Start () {
		gm = gameManager.GetComponent<GameManager>();
		pF = fumeta.GetComponent<Player>();
        contador = 0;
	}
	
	void FixedUpdate () {
        if (contador < 12)
            transform.Translate(fumeta.transform.position);
        else
            transform.Translate(anclaje.transform.position);
		if (gm.ventana)
			pF.tiredness += -2;
		else
			pF.productivity = 0;
	}
	
	void OnMouseDown()
	{
		if (controlador)
        {
            contador++;
            controlador = false;
        }
    }

    void OnMouseUp()
    {
        controlador = true;
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.name.Equals("Limite"))
        Destroy(this.gameObject);
    }
}
