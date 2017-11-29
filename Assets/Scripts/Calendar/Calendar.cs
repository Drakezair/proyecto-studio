using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Calendar : MonoBehaviour {
	// Tiempo
	public DateTime datetime;

	[Range(2010,3000)]
	public int year;

	[Range(1,12)]
	public int month;

	[Range(1,31)]
	public int day;

	// GUI
	public Text Date_Text_Month;

	public Text Date_Text_Year;

	public Button[] Dias;
	public Color Color_Dias_Antes;

	//Hacer MES

	DateTime Contar_Mes;

	//PLANILLA DIA

	public GameObject desactivar;

	public GameObject activar;
	
	//Ajustes Dias

	public Toggle[] Dias_Seleccionados;

	// Use this for initialization
	void Start () {
		
		year = DateTime.Now.Year;
		month = DateTime.Now.Month;
		day = DateTime.Now.Day;
		datetime = DateTime.Now;		
	
	}
	
	// Update is called once per frame
	void Update () {


		Contar_Mes = new DateTime (year, month, 1);
		int MaxDias = DateTime.DaysInMonth (year, month);
		if (MaxDias <= day) {			
			datetime = new DateTime (year, month, MaxDias);
		} else {
			datetime = new DateTime (year, month, day);
		}



		switch (datetime.Month) {
		case 1:
			Date_Text_Month.text = "Enero";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 2:
			Date_Text_Month.text = "Febrero";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 3:
			Date_Text_Month.text = "Marzo";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 4:
			Date_Text_Month.text = "Abril" ;
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 5:
			Date_Text_Month.text = "Mayo";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 6:
			Date_Text_Month.text = "Junio";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 7:
			Date_Text_Month.text = "Julio";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 8:
			Date_Text_Month.text = "Agosto";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 9:
			Date_Text_Month.text = "Septiembre";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 10:
			Date_Text_Month.text = "Octubre";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 11:
			Date_Text_Month.text = "Noviembre" ;
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;
		case 12:
			Date_Text_Month.text = "Diciembre";
			Date_Text_Year.text = datetime.Year.ToString ("D");
			break;

		}

		switch (Contar_Mes.DayOfWeek) {

		case DayOfWeek.Monday:
			int Lunes_Uno = 1;

			for (int i = 1; i < Dias.Length+1; i++) {

				int Ult_dia = System.DateTime.DaysInMonth (year, month);

				if (i <= Ult_dia) {
					DateTime dt = new DateTime (year, month, i);
					Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaCurrent = i;
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = true;
					if (Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [0] && Dias_Seleccionados[0].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [1] && Dias_Seleccionados[1].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [2] && Dias_Seleccionados[2].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [3] && Dias_Seleccionados[3].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [4] && Dias_Seleccionados[4].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [5] && Dias_Seleccionados[5].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [6] && Dias_Seleccionados[6].isOn == false){

						Dias [i - 1].interactable = false;
					}
					Dias [i - 1].GetComponentInChildren<Text> ().text = i.ToString ("D");
				}

				//DIAS DESPUES

				else {
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = false;
					Dias [i - 1].GetComponent<Image> ().enabled = false;
					Dias [i -1].GetComponentInChildren<Text> ().enabled = false;
					Lunes_Uno += 1;
				}

			}
			break;


		case DayOfWeek.Tuesday:
									
			int Martes_Uno = 1;

			int DiasEnMes_M = 0;

			if (month == 1) {

				DiasEnMes_M = DateTime.DaysInMonth (year - 1, 12);
			} else {

				DiasEnMes_M = DateTime.DaysInMonth (year, month-1);

			}
			

			for (int a = 0; a > -1; a--) {
				Dias [a].gameObject.SetActive (true);
				Dias [a].GetComponentInChildren<Text> ().text = DiasEnMes_M.ToString ("D");
				Dias [a].interactable = false;
				Dias [a].GetComponent<Image> ().enabled = false;
				Dias [a].GetComponentInChildren<Text> ().enabled = false;
				DiasEnMes_M -= 1;
			}			

			for (int i = 2; i < Dias.Length+1; i++) {

				int Ult_dia = System.DateTime.DaysInMonth (year, month);

				if (i - 1 <= Ult_dia) {
					DateTime dt = new DateTime (year, month, i - 1);
					int t = i - 1;
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = true;
					if (Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [0] && Dias_Seleccionados[0].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [1] && Dias_Seleccionados[1].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [2] && Dias_Seleccionados[2].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [3] && Dias_Seleccionados[3].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [4] && Dias_Seleccionados[4].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [5] && Dias_Seleccionados[5].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [6] && Dias_Seleccionados[6].isOn == false){

						Dias [i - 1].interactable = false;
					}
					Dias [i - 1].GetComponentInChildren<Text> ().text = t.ToString ("D");
					Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaCurrent = t;
				}

				//DIAS DESPUES

				else {
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = false;
					Dias [i -1].GetComponent<Image> ().enabled = false;
					Dias [i -1].GetComponentInChildren<Text> ().enabled = false;
					Martes_Uno += 1;
				}
			}
			break;


		case DayOfWeek.Wednesday:
			
			int Miercoles_Uno = 1;
			int DiasEnMes_MI = 0;

			if (month == 1) {

				DiasEnMes_MI = DateTime.DaysInMonth (year - 1, 12);
			} else {

				DiasEnMes_MI = DateTime.DaysInMonth (year, month-1);

			}

			for (int a = 1; a > -1; a--) {
				Dias [a].gameObject.SetActive (true);
				Dias [a].GetComponent<Image> ().enabled = false;
				Dias [a].GetComponentInChildren<Text> ().enabled = false;
				Dias [a].interactable = false;
				DiasEnMes_MI -= 1;
			}			

			for (int i = 3; i < Dias.Length+1; i++) {

				int Ult_dia = System.DateTime.DaysInMonth (year, month);

				if (i - 2 <= Ult_dia) {
					DateTime dt = new DateTime (year, month, i - 2);
					int t = i - 2;
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = true;
					if (Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [0] && Dias_Seleccionados[0].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [1] && Dias_Seleccionados[1].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [2] && Dias_Seleccionados[2].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [3] && Dias_Seleccionados[3].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [4] && Dias_Seleccionados[4].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [5] && Dias_Seleccionados[5].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [6] && Dias_Seleccionados[6].isOn == false){

						Dias [i - 1].interactable = false;
					}
					Dias [i - 1].GetComponentInChildren<Text> ().text = t.ToString ("D");
					Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaCurrent = t;
				}

				//DIAS DESPUES

				else {
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = false;
					Dias [i - 1].GetComponent<Image> ().enabled = false;
					Dias [i -1].GetComponentInChildren<Text> ().enabled = false;
					Miercoles_Uno += 1;					
				}
			}
			break;


		case DayOfWeek.Thursday:
			
			int Jueves_Uno = 1;
			int DiasEnMes_J = 0;

			if (month == 1) {

				DiasEnMes_J = DateTime.DaysInMonth (year - 1, 12);
			} else {

				DiasEnMes_J = DateTime.DaysInMonth (year, month-1);

			}
			for (int a = 2; a > -1; a--) {
				Dias [a].gameObject.SetActive (true);
				Dias [a].GetComponentInChildren<Text> ().text = DiasEnMes_J.ToString ("D");
				Dias [a].interactable = false;
				Dias [a].GetComponent<Image> ().enabled = false;
				Dias [a].GetComponentInChildren<Text> ().enabled = false;
				DiasEnMes_J -= 1;
			}			

			for (int i = 4; i < Dias.Length+1; i++) {
				int Ult_dia = System.DateTime.DaysInMonth (year, month);

				if (i - 3 <= Ult_dia) {
					DateTime dt = new DateTime (year, month, i - 3);
					int t = i - 3;
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = true;
					if (Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [0] && Dias_Seleccionados[0].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [1] && Dias_Seleccionados[1].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [2] && Dias_Seleccionados[2].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [3] && Dias_Seleccionados[3].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [4] && Dias_Seleccionados[4].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [5] && Dias_Seleccionados[5].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [6] && Dias_Seleccionados[6].isOn == false){

						Dias [i - 1].interactable = false;
					}
					Dias [i - 1].GetComponentInChildren<Text> ().text = t.ToString ("D");
					Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaCurrent = t;
				}

				//DIAS DESPUES

				else {
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = false;
					Dias [i - 1].GetComponent<Image> ().enabled = false;
					Dias [i - 1].GetComponentInChildren<Text> ().enabled = false;
					Jueves_Uno += 1;
				}
				}
			break;


		case DayOfWeek.Friday:
			
			int Viernes_Uno = 1;
			int DiasEnMes_V = 0;

			if (month == 1) {

				DiasEnMes_V = DateTime.DaysInMonth (year - 1, 12);
			} else {

				DiasEnMes_V = DateTime.DaysInMonth (year, month-1);

			}
			for (int a = 3; a > -1; a--) {
				Dias [a].gameObject.SetActive (true);
				Dias [a].GetComponentInChildren<Text> ().text = DiasEnMes_V.ToString ("D");
				Dias [a].interactable = false;
				Dias [a].GetComponent<Image> ().enabled = false;
				Dias [a].GetComponentInChildren<Text> ().enabled = false;

				DiasEnMes_V -= 1;
			}			

			for (int i = 5; i < Dias.Length+1; i++) {
				int Ult_dia = System.DateTime.DaysInMonth (year, month);

				if (i - 4<= Ult_dia) {
					DateTime dt = new DateTime (year, month, i - 4);
					int t = i - 4;
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = true;
					if (Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [0] && Dias_Seleccionados[0].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [1] && Dias_Seleccionados[1].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [2] && Dias_Seleccionados[2].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [3] && Dias_Seleccionados[3].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [4] && Dias_Seleccionados[4].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [5] && Dias_Seleccionados[5].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [6] && Dias_Seleccionados[6].isOn == false){

						Dias [i - 1].interactable = false;
					}
					Dias [i - 1].GetComponentInChildren<Text> ().text = t.ToString ("D");
					Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaCurrent = t;
				}

				//DIAS DESPUES

				else {
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = false;
					Dias [i - 1].GetComponent<Image> ().enabled = false;
					Dias [i - 1].GetComponentInChildren<Text> ().enabled = false;
					Viernes_Uno += 1;
				}
				}
			break;
		case DayOfWeek.Saturday:

			int Sabado_Uno = 1;
			int DiasEnMes_S = 0;

			if (month == 1) {

				DiasEnMes_S = DateTime.DaysInMonth (year - 1, 12);
			} else {

				DiasEnMes_S = DateTime.DaysInMonth (year, month-1);

			}
			// DIAS ANTES

			for (int a = 4; a > -1; a--) {
				Dias [a].gameObject.SetActive (true);
				Dias [a].GetComponentInChildren<Text> ().text = DiasEnMes_S.ToString ("D");
				Dias [a].interactable = false;
				Dias [a].GetComponent<Image> ().enabled = false;
				Dias [a].GetComponentInChildren<Text> ().enabled = false;
				DiasEnMes_S -= 1;
			}			

			// DIAS MES
			for (int i = 6; i < Dias.Length +1; i++) { 
				
				int Ult_dia = System.DateTime.DaysInMonth (year, month);

				if (i - 5 <= Ult_dia) {
					DateTime dt = new DateTime (year, month, i - 5);
					int t = i - 5;
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = true;
					if (Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [0] && Dias_Seleccionados[0].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [1] && Dias_Seleccionados[1].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [2] && Dias_Seleccionados[2].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [3] && Dias_Seleccionados[3].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [4] && Dias_Seleccionados[4].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [5] && Dias_Seleccionados[5].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [6] && Dias_Seleccionados[6].isOn == false){

						Dias [i - 1].interactable = false;
					}
					Dias [i - 1].GetComponentInChildren<Text> ().text = t.ToString ("D");
					Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaCurrent = t;
				}

				//DIAS DESPUES

				else {
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = false;
					Dias [i -1].GetComponent<Image> ().enabled = false;
					Dias [i -1].GetComponentInChildren<Text> ().enabled = false;
					Sabado_Uno += 1; 
				}
				}
			break;


		case DayOfWeek.Sunday:
			
			// DIAS_ANTERIORES

			int Domingo_uno = 1;
			int DiasEnMes_D = 0;

			if (month == 1) {

				DiasEnMes_D = DateTime.DaysInMonth (year - 1, 12);
			} else {

				DiasEnMes_D = DateTime.DaysInMonth (year, month-1);

			}
			for (int a = 5; a > -1; a--) {
				Dias [a].gameObject.SetActive (true);
				Dias [a].GetComponentInChildren<Text> ().text = DiasEnMes_D.ToString ("D");
				Dias [a].interactable = false;
				Dias [a].GetComponent<Image> ().enabled = false;
				Dias [a].GetComponentInChildren<Text> ().enabled = false;
				DiasEnMes_D -= 1;
			}			


			//DIAS DEL MES
			for (int i = 7; i < Dias.Length +1; i++) {
				int Ult_dia = System.DateTime.DaysInMonth (year, month);

				if (i - 6 <= Ult_dia) {
				
					DateTime dt = new DateTime (year, month, i - 6);
					int t = i - 6;
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = true;
					if (Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [0] && Dias_Seleccionados[0].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [1] && Dias_Seleccionados[1].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [2] && Dias_Seleccionados[2].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [3] && Dias_Seleccionados[3].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [4] && Dias_Seleccionados[4].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [5] && Dias_Seleccionados[5].isOn == false ||
						Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaDeLaSemana [6] && Dias_Seleccionados[6].isOn == false){

						Dias [i - 1].interactable = false;
					}
					Dias [i - 1].GetComponentInChildren<Text> ().text = t.ToString ("D");
					Dias [i - 1].GetComponent<Boton_Day_Calendar> ().DiaCurrent = t;
				} 

				//DIAS DESPUES

				else {
					Dias [i - 1].gameObject.SetActive (true);
					Dias [i - 1].interactable = false;
					Dias [i - 1].GetComponent<Image> ().enabled = false;
					Dias [i - 1].GetComponentInChildren<Text> ().enabled = false; 
					Domingo_uno += 1;
				}
			}
			break;
		}
	}

	public void Siguiente_Mes(){


		for (int i = 0; i < Dias.Length; i++) {
			Dias [i].GetComponent<Image> ().enabled = true;
			Dias[i].GetComponentInChildren<Text>().enabled = true;
			Dias [i].GetComponentInChildren<Text> ().color = Color.white;
			Dias [i].gameObject.SetActive (false);

		}

		month += 1;

		if (month == 13) {

			year += 1;
			month = 1;

		}
	}

	public void Anterior_Mes(){

		for (int i = 0; i < Dias.Length; i++) {

			Dias [i].gameObject.SetActive (false);
			Dias[i].GetComponentInChildren<Text>().enabled = true;
			Dias [i].GetComponent<Image> ().enabled = true;
			Dias [i].GetComponentInChildren<Text> ().color = Color.white; 
		}

		month -= 1;

		if (month == 0) {

			year -= 1;
			month = 12;

		}
	}
}