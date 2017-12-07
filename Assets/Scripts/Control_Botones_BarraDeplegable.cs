using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control_Botones_BarraDeplegable : MonoBehaviour {

	//Home
	public Button Boton_Home;

	//Primer menu desplegable
	public GameObject Botones_1;		//Botones deplegables de Boton_1
	public bool Boton_1_Boolean;		//Bool ParaNimacion
	public float Boton_1_TimeAnim;		//Tiempo para la animacion
	public Animator B1_Anim;			//Animartor de boton 1

	//Objetos que activa o desactiva boton 1 1
	public GameObject[] ObjetosBoton1_1;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Delpliega primer menu
		if (!Boton_1_Boolean) {
			Boton_1_TimeAnim -= 1 * Time.deltaTime;
			if (Boton_1_TimeAnim <= 0.9f) {
				Botones_1.SetActive (false);
			}
		}


	}

	public void Desplegar_B1(){							//Despliega el sub menu del boton 1


		if (Boton_1_Boolean) {

			Boton_1_Boolean = false;
			B1_Anim.SetBool ("Cerrar", true);
		} else {			
			Boton_1_Boolean = true;
			Botones_1.SetActive (true);
			Boton_1_TimeAnim = 1.5f;
		}
	}

	public void B1_1(){

		ObjetosBoton1_1 [0].SetActive (true);
		ObjetosBoton1_1 [1].SetActive (false);
		ObjetosBoton1_1 [2].SetActive (false);
	}

	public void B1_2(){

		ObjetosBoton1_1 [0].SetActive (false);
		ObjetosBoton1_1 [1].SetActive (true);
		ObjetosBoton1_1 [2].SetActive (false);
	}

	public void B1_3(){

		ObjetosBoton1_1 [0].SetActive (false);
		ObjetosBoton1_1 [1].SetActive (false);
		ObjetosBoton1_1 [2].SetActive (true);
	}
}
