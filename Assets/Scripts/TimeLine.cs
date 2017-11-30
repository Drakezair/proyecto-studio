using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class TimeLine : MonoBehaviour {

	public Scrollbar Scroll;

	public Vector2 Mouseposicion;

	bool Deslizar,Deslizar1,desplegar;

	private Anim_Funtion Funciones_animar;



	// Use this for initialization
	void Start () {
	
		Funciones_animar = GetComponent<Anim_Funtion> ();

		 
	}
	
	// Update is called once per frame
	void Update () {

		//DESPLEGAR Y DESLIZAR BARRA LATERAL

		// MOSTRAR
		Mouseposicion = new Vector2(Input.mousePosition.x,Input.mousePosition.y); 

		if (Mouseposicion.x <= 130f && Input.GetKeyDown (KeyCode.Mouse0) && !desplegar) {

			Deslizar = true;


		}

		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			Deslizar = false;
		}

		if (Mouseposicion.x >= 380f && Deslizar) {
			Funciones_animar.MoveTo (Scroll, 1f, 0.189f, 1.5f, true);

				

			//Debug.Log ("DESLIZO");
			desplegar = true;
			if (Scroll.size < 0.8262) {
				Deslizar = false;
			}
		}

		if (desplegar) {
			Funciones_animar.MoveTo (Scroll, 1f, 0.189f, 1.5f, true);

				

		}

		// OCULTAR

		if (Mouseposicion.x >= 90f && Input.GetKeyDown (KeyCode.Mouse0) && desplegar) {

			Deslizar1 = true;


		}

		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			Deslizar1 = false;
		}

		if (Mouseposicion.x <= 89f && Deslizar1) {
			
			Funciones_animar.MoveTo (Scroll, 0.189f,1f, 1.5f, true);



			//Debug.Log ("DESLIZO");
			desplegar = false;
			if (Scroll.size >= 1) {
				Deslizar1 = false;
			}
		}

		if (!desplegar && !Deslizar1) {
									
			Funciones_animar.MoveTo (Scroll, 0.189f,1f, 1.5f, true);



		}
	}

	public void Desplegar(){

		if(desplegar){

			desplegar = false;

		}else

		if (desplegar == false) {

			desplegar = true;

		}
	}
}
