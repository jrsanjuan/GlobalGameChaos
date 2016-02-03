using UnityEngine;
using System.Collections;

public class EscapistaController : MonoBehaviour {

	/*
	 * Para hacerlo bien
	 * 
	 * public GameObject escapista
	 * 
	 * void TriggerEvent (string evento) {
	 * 	if (evento.equals('escapista') {
	 * 		Logica escapista
	 * 	}
	 * }
	 */ 

	//public string caracteristica;

	// Velocidad cuando se entra en el trigger
	public float speed;

	// Variable privada para empezar a moverse
	private Vector3 movement = Vector3.left * 0.1f;

	// Actualiza posicion de escapista
	void Update() {

		Debug.Log (Random.value);

		if (transform.position.x > 10)
			movement = Vector3.left * 0.1f;
		else if (transform.position.x < -10)
			movement = Vector3.right * 0.1f;

		transform.Translate(movement);
	}

	// Escapa del puntero cuando entramos en el object
	void OnMouseOver () {

		/*if (movement == Vector3.right * 0.1f)
			movement = Vector3.left * 0.1f * speed;
		else
			movement = Vector3.right * 0.1f * speed;*/
		float direction = Random.value;
		if (direction >= 0.50)
			movement = Vector3.right * 0.1f * speed;
		else 
			movement = Vector3.left * 0.1f * speed;
	}

	// Se para la ejecucion de escapista	
	void OnMouseDown () {
	   Debug.Log("escapista");
	}

}
