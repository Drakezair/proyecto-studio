using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlanillaCita : MonoBehaviour {

	public int year;

	public int month;

	public int day;

	public int hora;

	public int minuto;

	public bool Pm;

	public Text HoraCita;

	public Text Paciente;

	public Text Tlf_Text;

	public GameObject Formulario;

	public PlanillaDia PD_Call;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
		if (gameObject.activeInHierarchy) {

			Paciente.text = "Paciente";
			Tlf_Text.text = "Telefono";

			for (int i = 0; i < PD_Call.Citas.Count; i++) {
				if (PD_Call.Citas [i].Año == year && PD_Call.Citas [i].Mes == month
				   && PD_Call.Citas [i].Dia == day && PD_Call.Citas [i].Hora == hora && PD_Call.Citas [i].Minuto == minuto
					&& PD_Call.Citas [i].PM == Pm) {
					
					Paciente.text = PD_Call.Citas [i].Nombre + " " + PD_Call.Citas[i].Apellido;
					
					if (PD_Call.Citas [i].tlf1 != "" && PD_Call.Citas [i].tlf1 != null) {
						Tlf_Text.text = PD_Call.Citas [i].tlf1;
					}			
				} 
				
			}
		}
	}

	public void  AbrirFormulario(){



		Formulario.GetComponent<FormularioCita> ().year = year;
		Formulario.GetComponent<FormularioCita> ().month = month ;
		Formulario.GetComponent<FormularioCita> ().day = day;
		Formulario.GetComponent<FormularioCita> ().hora = hora;
		Formulario.GetComponent<FormularioCita> ().minuto = minuto;
		Formulario.GetComponent<FormularioCita> ().PM = Pm;
		Formulario.GetComponent<FormularioCita> ().Nombre.text = null;
		Formulario.GetComponent<FormularioCita> ().Apellido.text = null;
		Formulario.GetComponent<FormularioCita> ().tlf1.text = null;
		Formulario.GetComponent<FormularioCita> ().Email.text = null;
		Formulario.GetComponent<FormularioCita> ().Motivo.text = null;
		Formulario.SetActive (true);

	}
}
