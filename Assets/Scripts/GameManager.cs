using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float progreso, TiempoGameJam;
    private float maxProgreso = 1000;
    public int lanzadorEvento, evento, dibujos, contadorPapeles;
    public bool ventana;
    public GameObject papel, instanciadorPapeles, pesao, fumeta, ancla;
    private Player pF;
    public GameObject barra;
    public GameObject[] numeros;
    public Sprite[] numerosBase;
    string porcentajeString;

	
	void Start () {
		ventana = false;
		contadorPapeles = 0;
        progreso = 0;
        TiempoGameJam = 720;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (contadorPapeles >= 7)
		    StopAllCoroutines();
        ConstruimosStringMarcador();
        UpdateGameProgress(0);
        TiempoGameJam -= 1 * Time.deltaTime;
        lanzadorEvento += Random.Range(1, 10);
        if (lanzadorEvento >= 100)
        {
            lanzadorEvento = 0;
            evento = Random.Range(1, 4);
            switch(evento){
                case 1:
                    robarDibujante();
                    break;
                case 2:
                    enviarPesao();
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
        if (TiempoGameJam == 0)
        {
            StopAllCoroutines();
        }
	}

    void UpdateGameProgress(float aumento)
    {
        if (progreso < maxProgreso)
        progreso += aumento;
        numeros[0].GetComponent<SpriteRenderer>().sprite = numerosBase[int.Parse(porcentajeString[0]).ToString()];
        numeros[1].GetComponent<SpriteRenderer>().sprite = numerosBase[int.Parse(porcentajeString[1]).ToString()];
    }

    void AlargarBarra()
    {
        float alargamiento =  progreso / maxProgreso * 100;
        barra.transform.localScale = new Vector3(alargamiento / 2, 1, 1);
    }

    void ConstruimosStringMarcador()
    {
        int porcentaje = progreso / maxProgreso * 100;
        if (porcentaje < 10)
            porcentajeString = "0" + porcentaje.ToString();
        else
            porcentajeString = porcentaje.ToString();
    }

    void robarDibujante()
    {
        StartCoroutine("Esperar");
        
    }

    void enviarPesao()
    {
        if (!GameObject.FindGameObjectWithTag("pesao"))
        {
			Instantiate(pesao, ancla.transform.position, ancla.transform.rotation);
		}
	}

	IEnumerator Esperar(){
	int segundero;
	yield return new WaitForSeconds(2);
	contadorPapeles += 1;
	Instantiate(papel, instanciadorPapeles.transform.position, instanciadorPapeles.transform.rotation);
	instanciadorPapeles.transform.Translate(new Vector2());
	segundero = Random.Range(3, 10);
		
	yield return new WaitForSeconds(segundero);
	}
    
}
