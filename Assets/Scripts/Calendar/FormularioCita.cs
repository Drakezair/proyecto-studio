using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FormularioCita : MonoBehaviour {

	public int year;

	public int month;

	public int day;

	public int hora;

	public int minuto;

	public bool PM;

	public InputField Nombre;

	public InputField Apellido;

	public InputField tlf1;

	public InputField Email;

	public InputField Motivo;

	public Text DatosFormulario;

	public PlanillaDia PD_Call;

	public GameObject Boton_NuevaCita;

	public GameObject Boton_EditarCita;
	public GameObject Boton_EditarCitaTask;
	bool Editando;

	public GameObject Boton_BorrarCita;


	public GameObject Pop_up_EditarCita;


	public GameObject Pop_up_BorrarCita;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeInHierarchy) {
			if (CitaExist ()) {

				Boton_BorrarCita.SetActive (true);
				Boton_NuevaCita.SetActive (false);

				if (!Editando) {

					Boton_EditarCita.SetActive (true);
					Boton_EditarCitaTask.SetActive (false);


					Nombre.GetComponent<Image> ().fillCenter = false;
					Nombre.interactable = false;

					Apellido.GetComponent<Image> ().fillCenter = false;
					Apellido.interactable = false;

					tlf1.GetComponent<Image> ().fillCenter = false;
					tlf1.interactable = false;
					
					Email.GetComponent<Image> ().fillCenter = false;
					Email.interactable = false;

					Motivo.GetComponent<Image>().fillCenter = false;
					Motivo.interactable = false;
				


					for (int i = 0; i < PD_Call.Citas.Count; i++) {

						if (PD_Call.Citas [i].Año == year && PD_Call.Citas [i].Mes == month
						    && PD_Call.Citas [i].Dia == day && PD_Call.Citas [i].Hora == hora && PD_Call.Citas [i].Minuto == minuto
						    && PD_Call.Citas [i].PM == PM) {

							Nombre.text = PD_Call.Citas [i].Nombre;
							Apellido.text = PD_Call.Citas [i].Apellido;

							if (PD_Call.Citas [i].tlf1 != "" && PD_Call.Citas [i].tlf1 != null) {
								tlf1.text = PD_Call.Citas [i].tlf1;
							}

							if (PD_Call.Citas [i].email != "" && PD_Call.Citas [i].email != null) {
								Email.text = PD_Call.Citas [i].email;
							}

							if(PD_Call.Citas[i].Motivo != "" && PD_Call.Citas[i].Motivo != null){
								Motivo.text = PD_Call.Citas[i].Motivo;
							}

							if (minuto != 0) {
								if (PM) {
									DatosFormulario.text = hora.ToString ("D") + ":" + minuto.ToString ("D") + "pm" + " - " + Nombre.text + " " + Apellido.text;
								} else {

									DatosFormulario.text = hora.ToString ("D") + ":" + minuto.ToString ("D") + "am" + " - " + Nombre.text + " " + Apellido.text;
								}
							} else {
								if (PM) {
									DatosFormulario.text = hora.ToString ("D") + ":00pm" + " - " + Nombre.text + " " + Apellido.text;
								} else {
									DatosFormulario.text = hora.ToString ("D") + ":00am" + " - " + Nombre.text + " " + Apellido.text;
								}
							}
						} 
					}
				} else {


					Boton_EditarCita.SetActive (false);
					Boton_EditarCitaTask.SetActive (true);


					Nombre.GetComponent<Image> ().fillCenter = true;
					Nombre.interactable = true;

					Apellido.GetComponent<Image> ().fillCenter = true;
					Apellido.interactable = true;

					tlf1.GetComponent<Image> ().fillCenter = true;
					tlf1.interactable = true;

					Email.GetComponent<Image> ().fillCenter = true;
					Email.interactable = true;

					Motivo.GetComponent<Image>().fillCenter = true;
					Motivo.interactable = true;

				}
			} else {

				Boton_BorrarCita.SetActive (false);
				Boton_EditarCita.SetActive (false);
				Boton_NuevaCita.SetActive (true);

				Nombre.GetComponent<Image> ().fillCenter = true;
				Nombre.interactable = true;

				Apellido.GetComponent<Image> ().fillCenter = true;
				Apellido.interactable = true;

				tlf1.GetComponent<Image> ().fillCenter = true;
				tlf1.interactable = true;

				Email.GetComponent<Image> ().fillCenter = true;
				Email.interactable = true;

				Motivo.GetComponent<Image>().fillCenter = true;
					Motivo.interactable = true;

				if (minuto != 0) {
					if (PM) {
						DatosFormulario.text = hora.ToString ("D") + ":" + minuto.ToString ("D") + "pm" + " - " + "Libre";
					} else {

						DatosFormulario.text = hora.ToString ("D") + ":" + minuto.ToString ("D") + "am" + " - " + "Libre";
					}
				} else {
					if (PM) {
						DatosFormulario.text = hora.ToString ("D") + ":00pm" + " - " + "Libre";
					} else {
						DatosFormulario.text = hora.ToString ("D") + ":00am" + " - " + "Libre";
					}
				} 

			}
		}
	}
	public void HacerCita(){													//HACER CITA

		if (Nombre.text != null && Nombre.text != "" && Apellido.text != "" && Apellido.text != null) {
			if (!CitaExist ()) {
				
				Citas NuevaCita = new Citas ();
				NuevaCita.Año = year;
				NuevaCita.Mes = month;
				NuevaCita.Dia = day;
				NuevaCita.Hora = hora;
				NuevaCita.Minuto = minuto;
				NuevaCita.Nombre = Nombre.text;
				NuevaCita.Apellido = Apellido.text;
				NuevaCita.PM = PM;

				if (tlf1.text != null && tlf1.text != "") {
					NuevaCita.tlf1 = tlf1.text;
				}

				if (Email.text != null && Email.text != "") {
					NuevaCita.email = Email.text;
				}
				if(Motivo.text != null && Motivo.text != ""){
					NuevaCita.Motivo = Motivo.text;
				}


				PD_Call.Citas.Add (NuevaCita);

				gameObject.SetActive(false);
				Nombre.placeholder.color = Color.gray;
				Apellido.placeholder.color = Color.gray;
			}
		} else {
			Nombre.placeholder.color = Color.red;
			Apellido.placeholder.color = Color.red;
		}
	}

	public void EditarCita(){													//EDITAR CITA EXISTENTE
							
		Editando = true;

	}

	void ConfirmarEditarCita(){
		for (int i = 0; i < PD_Call.Citas.Count; i++) {

			if (PD_Call.Citas [i].Año == year && PD_Call.Citas [i].Mes == month
			    && PD_Call.Citas [i].Dia == day && PD_Call.Citas [i].Hora == hora && PD_Call.Citas [i].Minuto == minuto 
				&& PD_Call.Citas[i].PM ==  PM) {

				if (PD_Call.Citas [i].Nombre != Nombre.text || PD_Call.Citas[i].Apellido != Apellido.text 
				|| PD_Call.Citas [i].tlf1 != tlf1.text || PD_Call.Citas [i].email != Email.text
				|| PD_Call.Citas[i].Motivo != Motivo.text) {

					
					PD_Call.Citas [i].Nombre = Nombre.text;
					PD_Call.Citas [i].Apellido = Apellido.text;
					PD_Call.Citas [i].tlf1 = tlf1.text;
					PD_Call.Citas [i].email = Email.text;
					PD_Call.Citas [i].Motivo = Motivo.text;
					break;					
				}
			}
		}
	}

	public void Pop_Confirmar_EditarCita(){
		if(Nombre.text != null && Nombre.text != "" && Apellido.text != "" &&Apellido.text != null){
		Pop_up_EditarCita.SetActive (true);
		}else{
			Nombre.placeholder.color = Color.red;
			Apellido.placeholder.color = Color.red;
		}

	}

	public void FC_EditarCita(){

		Editando = false;
		ConfirmarEditarCita ();
		Pop_up_EditarCita.SetActive (false);

	}

	public void CancelarEditarCita(){

		for (int i = 0; i < PD_Call.Citas.Count; i++) {

			if (PD_Call.Citas [i].Año == year && PD_Call.Citas [i].Mes == month
			    && PD_Call.Citas [i].Dia == day && PD_Call.Citas [i].Hora == hora && PD_Call.Citas [i].Minuto == minuto
				&& PD_Call.Citas[i].PM ==  PM) {

				Nombre.text = PD_Call.Citas [i].Nombre;
				Apellido.text = PD_Call.Citas [i].Apellido;
				tlf1.text = PD_Call.Citas [i].tlf1;
				Email.text = PD_Call.Citas [i].email;
				Motivo.text = PD_Call.Citas [i].Motivo;

			}
		}
		Editando = false;

		Pop_up_EditarCita.SetActive (false);
	}



	public void Borra_Cita(){													//BORRAR CITA

		if(CitaExist()){

			for (int i = 0; i < PD_Call.Citas.Count; i++) {
				
				if (PD_Call.Citas [i].Año == year && PD_Call.Citas [i].Mes == month
				    && PD_Call.Citas [i].Dia == day && PD_Call.Citas [i].Hora == hora && PD_Call.Citas [i].Minuto == minuto
					&& PD_Call.Citas[i].PM ==  PM) {

					Nombre.text = null;
					Apellido.text = null;
					tlf1.text = null;
					Email.text = null;
					Motivo.text = null;


					PD_Call.Citas.Remove (PD_Call.Citas [i]);
					break;
				}
			}
		}
		Pop_up_BorrarCita.SetActive (false);
	}

	public void Pop_BorrarCita(){

		Pop_up_BorrarCita.SetActive (true);

	}

	public void CancelBorrar(){

		Pop_up_BorrarCita.SetActive (false);

	}

	public void CerrarFormulario(){

		gameObject.SetActive (false);
		Nombre.placeholder.color = Color.gray;
		Apellido.placeholder.color = Color.gray;

	}

	bool CitaExist(){

		bool exist = false;

		for (int i = 0; i < PD_Call.Citas.Count; i++) {
			exist = false;
			if (PD_Call.Citas [i].Año == year && PD_Call.Citas [i].Mes == month
			   && PD_Call.Citas [i].Dia == day && PD_Call.Citas [i].Hora == hora && PD_Call.Citas [i].Minuto == minuto
				&& PD_Call.Citas[i].PM ==  PM) {
				exist = true;
				break;
			}
		}

		return exist;
	}
}
