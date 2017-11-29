using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Boton_Day_Calendar : MonoBehaviour {

	public int DiaCurrent;

	public bool[] DiaDeLaSemana;

	Calendar datcalendar; 

	PlanillaDia PD_call;


	public GameObject[] PlanillasCitas;

	// Use this for initialization
	void Start () {
	
		datcalendar = FindObjectOfType<Calendar> ();
		PD_call = FindObjectOfType<PlanillaDia> ();
		PlanillasCitas = PD_call.PlanillaCitas;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Selec_Dia(){

		datcalendar.datetime = new DateTime (datcalendar.year, datcalendar.month, DiaCurrent);
		datcalendar.day = DiaCurrent;
		PD_call.PermitirInstancia = true;
		datcalendar.activar.SetActive (true);
		datcalendar.desactivar.SetActive (false);
	}
}
