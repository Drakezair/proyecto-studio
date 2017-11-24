using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class TimeLine : MonoBehaviour {

	public Scrollbar Scroll;

	public GridLayoutGroup Ajutar_Grid_Botones_mes;

	public Vector2 Mouseposicion;

	bool Deslizar,Deslizar1,desplegar;

	private Anim_Funtion Funciones_animar;

	Control_Botones_BarraDeplegable CBBD_Call;


	// Use this for initialization
	void Start () {
	
		CBBD_Call = FindObjectOfType<Control_Botones_BarraDeplegable> ();
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
			Ajutar_Grid_Botones_mes.cellSize = new Vector2 (92.23f, Ajutar_Grid_Botones_mes.cellSize.y);
			Funciones_animar.MoveTo (Scroll, 1f, 0.825f, 1.5f, true);

				

			//Debug.Log ("DESLIZO");
			desplegar = true;
			if (Scroll.size < 0.8262) {
				Deslizar = false;
			}
		}

		if (desplegar) {
			Ajutar_Grid_Botones_mes.cellSize = new Vector2 (92.23f, Ajutar_Grid_Botones_mes.cellSize.y);
			Funciones_animar.MoveTo (Scroll, 1f, 0.825f, 1.5f, true);

				

		}

		// OCULTAR

		if (Mouseposicion.x >= 90f && Input.GetKeyDown (KeyCode.Mouse0) && desplegar) {

			Deslizar1 = true;


		}

		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			Deslizar1 = false;
		}

		if (Mouseposicion.x <= 89f && Deslizar1) {
			if (CBBD_Call.B1_Anim.isActiveAndEnabled) {
				
				CBBD_Call.Boton_1_Boolean = false;
				CBBD_Call.B1_Anim.SetBool ("Cerrar", true);
			}
			Ajutar_Grid_Botones_mes.cellSize = new Vector2 (112.5f, Ajutar_Grid_Botones_mes.cellSize.y);
			Funciones_animar.MoveTo (Scroll, 0.825f,1f, 1.5f, true);



			//Debug.Log ("DESLIZO");
			desplegar = false;
			if (Scroll.size >= 1) {
				Deslizar1 = false;
			}
		}

		if (!desplegar && !Deslizar1) {
			if (CBBD_Call.B1_Anim.isActiveAndEnabled) {
				
				CBBD_Call.Boton_1_Boolean = false;
				CBBD_Call.B1_Anim.SetBool ("Cerrar", true);
			}
			
			Ajutar_Grid_Botones_mes.cellSize = new Vector2 (112.5f, Ajutar_Grid_Botones_mes.cellSize.y);
			Funciones_animar.MoveTo (Scroll, 0.825f,1f, 1.5f, true);



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
