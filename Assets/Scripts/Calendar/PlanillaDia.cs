using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class PlanillaDia : MonoBehaviour {

	public List<Citas> Citas = new List<Citas> (); 

	public InputField[] InputHoraAm; 			// Recibe la hora de la mañana de todos los dias

	public InputField[] InputHoraPm;			// Recibe la hora de la tarde de todos los dias

	public InputField[] InputMinAm;				// Recibe los minutos de la mañana de todos los dias

	public InputField[] InputMinPm;				// Recibe los minutos de la tarde de todos los dias

	public Dropdown[] Intervalos;				//Seleciona los intervalos

	public Calendar Calendar_call;				//LLamadas para poder obtener la fecha actual

	public GameObject[] PlanillaCitas;			//OBjeto a instanciar

	public RectTransform Contenido;				//Padre de la instancia

	public bool PermitirInstancia;				// Permite la instancia



	// Use this for initialization
	void Start () {

		IntanciarPlantillas ();

	}
	
	// Update is called once per frame
	void Update () {

		/*int LunesAm = (int.Parse (InputHoraAm [0].text) * 60) + int.Parse (InputMinAm [0].text);
		int LunesAmH = (int.Parse (InputHoraAm [1].text) * 60) + int.Parse (InputMinAm [1].text);
		int LunesPm = (int.Parse (InputHoraPm [0].text) * 60) + int.Parse (InputMinPm [0].text);
		int LunesPmH = (int.Parse (InputHoraPm [1].text) * 60) + int.Parse (InputMinPm [1].text);

		int MartesAm = (int.Parse (InputHoraAm [2].text) * 60) + int.Parse (InputMinAm [2].text);
		int MartesAmH = (int.Parse (InputHoraAm [3].text) * 60) + int.Parse (InputMinAm [3].text);
		int MartesPm = (int.Parse (InputHoraPm [2].text) * 60) + int.Parse (InputMinPm [2].text);
		int MartesPmH = (int.Parse (InputHoraPm [3].text) * 60) + int.Parse (InputMinPm [3].text);


		int MiercolesAm = (int.Parse (InputHoraAm [4].text) * 60) + int.Parse (InputMinAm [4].text);
		int MiercolesAmH = (int.Parse (InputHoraAm [5].text) * 60) + int.Parse (InputMinAm [5].text);
		int MiercolesPm = (int.Parse (InputHoraPm [4].text) * 60) + int.Parse (InputMinPm [4].text);
		int MiercolesPmH = (int.Parse (InputHoraPm [5].text) * 60) + int.Parse (InputMinPm [5].text);


		int JuevesAm = (int.Parse (InputHoraAm [6].text) * 60) + int.Parse (InputMinAm [6].text);
		int JuevesAmH = (int.Parse (InputHoraAm [7].text) * 60) + int.Parse (InputMinAm [7].text);
		int JuevesPm = (int.Parse (InputHoraPm [6].text) * 60) + int.Parse (InputMinPm [6].text);
		int JuevesPmH = (int.Parse (InputHoraPm [7].text) * 60) + int.Parse (InputMinPm [7].text);


		int VieresAm = (int.Parse (InputHoraAm [8].text) * 60) + int.Parse (InputMinAm [8].text);
		int ViernesAmH = (int.Parse (InputHoraAm [9].text) * 60) + int.Parse (InputMinAm [9].text);
		int ViernesPm = (int.Parse (InputHoraPm [8].text) * 60) + int.Parse (InputMinPm [8].text);
		int ViernesPmH = (int.Parse (InputHoraPm [9].text) * 60) + int.Parse (InputMinPm [9].text);


		int SabadoAm = (int.Parse (InputHoraAm [10].text) * 60) + int.Parse (InputMinAm [10].text);
		int SabadoAmH = (int.Parse (InputHoraAm [11].text) * 60) + int.Parse (InputMinAm [11].text);
		int SabadoPm = (int.Parse (InputHoraPm [10].text) * 60) + int.Parse (InputMinPm [10].text);
		int SabadoPmH = (int.Parse (InputHoraPm [11].text) * 60) + int.Parse (InputMinPm [11].text);


		int DomingoAm = (int.Parse (InputHoraAm [12].text) * 60) + int.Parse (InputMinAm [12].text);
		int DomingoAmH = (int.Parse (InputHoraAm [13].text) * 60) + int.Parse (InputMinAm [13].text);
		int DomigoPm = (int.Parse (InputHoraPm [12].text) * 60) + int.Parse (InputMinPm [12].text);
		int DomingoPmH = (int.Parse (InputHoraPm [13].text) * 60) + int.Parse (InputMinPm [13].text);
		*/
	}


	public void IntanciarPlantillas(){


		switch (Calendar_call.datetime.DayOfWeek) {
		case DayOfWeek.Monday:
			int tL = 0;
			int horaL = int.Parse (InputHoraAm [0].text);
			int minutosL = 0;
			int mL = 0;
			for (int i = 0; i <= obtenerNumeroInstancias (0, 0); i++) {
				PlanillaCitas [i].SetActive (true);
				if (minutosL >= 60) {

					horaL += 1;
					minutosL = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horaL;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosL;
				if (minutosL == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horaL.ToString ("D") + ":" + minutosL.ToString ("D") + "0" + "Am";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horaL.ToString ("D") + ":" + minutosL.ToString ("D") + "Am";
				}

				if (int.Parse (InputHoraAm [1].text) == PlanillaCitas [i].GetComponent<PlanillaCita> ().hora) {
					PlanillaCitas [i].SetActive (false);
				}
				minutosL += intervaloR (0);
				mL += 1;
				tL += 1;
			}

			horaL = int.Parse (InputHoraPm [0].text);
			minutosL = 0;

			for (int i = tL; i <= tL + Pm (1, 0); i++) {

				PlanillaCitas [i].SetActive (true);
				if (minutosL >= 60) {

					horaL += 1;
					minutosL = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horaL;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosL;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().Pm = true;

				if (minutosL == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horaL.ToString ("D") + ":" + minutosL.ToString ("D") + "0" + "Pm";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horaL.ToString ("D") + ":" + minutosL.ToString ("D") + "Pm";
				}
				minutosL += intervaloR (1);
				mL += 1;
			}

			Contenido.sizeDelta = new Vector2 (Contenido.sizeDelta.x, Contenido.sizeDelta.y * (mL));
			break;

		case DayOfWeek.Tuesday:
			int tm = 0;
			int horam = int.Parse (InputHoraAm [2].text);
			int minutosm = 0;
			int mM = 0;
			for (int i = 0; i <= obtenerNumeroInstancias (2, 2); i++) {
				PlanillaCitas [i].SetActive (true);
				if (minutosm >= 60) { 

					horam += 1;
					minutosm = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horam;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosm;
				if (minutosm == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horam.ToString ("D") + ":" + minutosm.ToString ("D") + "0" + "Am";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horam.ToString ("D") + ":" + minutosm.ToString ("D") + "Am";
				}

				if (int.Parse (InputHoraAm [1].text) == PlanillaCitas [i].GetComponent<PlanillaCita> ().hora) {
					PlanillaCitas [i].SetActive (false);
				}
				minutosm += intervaloR (2);
				mM += 1;
				tm += 1;
			}

			horam = int.Parse (InputHoraPm [2].text);
			minutosm = 0;

			for (int i = tm; i <= tm + obtenerNumeroInstancias (3, 2); i++) {
				
				PlanillaCitas [i].SetActive (true);
				if (minutosm >= 60) {

					horam += 1;
					minutosm = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horam;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosm; 
				PlanillaCitas [i].GetComponent<PlanillaCita> ().Pm = true;
				if (minutosm == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horam.ToString ("D") + ":" + minutosm.ToString ("D") + "0" + "Pm";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horam.ToString ("D") + ":" + minutosm.ToString ("D") + "Pm";
				}
				minutosm += intervaloR (3); 
				mM += 1;
			}

			Contenido.sizeDelta = new Vector2 (Contenido.sizeDelta.x, Contenido.sizeDelta.y * (mM));

			break;	

		case DayOfWeek.Wednesday:
			int tmi = 0;
			int horami = int.Parse (InputHoraAm [4].text);
			int minutosmi = 0;
			int mMI = 0;
			for (int i = 0; i <= obtenerNumeroInstancias (4, 4); i++) {
				PlanillaCitas [i].SetActive (true);
				if (minutosmi >= 60) {

					horami += 1;
					minutosmi = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horami;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosmi;
				if (minutosmi == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horami.ToString ("D") + ":" + minutosmi.ToString ("D") + "0" + "Am";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horami.ToString ("D") + ":" + minutosmi.ToString ("D") + "Am";
				}

				if (int.Parse (InputHoraAm [1].text) == PlanillaCitas [i].GetComponent<PlanillaCita> ().hora) {
					PlanillaCitas [i].SetActive (false);
				}
				minutosmi += intervaloR (4);
				mMI += 1;
				tmi += 1;
			}

			horami = int.Parse (InputHoraPm [4].text);
			minutosmi = 0;

			for (int i = tmi; i <= tmi + obtenerNumeroInstancias (5, 4); i++) {

				PlanillaCitas [i].SetActive (true);
				if (minutosmi >= 60) {

					horami += 1;
					minutosmi = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horami;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosmi;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().Pm = true;
				if (minutosmi == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horami.ToString ("D") + ":" + minutosmi.ToString ("D") + "0" + "Pm";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horami.ToString ("D") + ":" + minutosmi.ToString ("D") + "Pm";
				}
				minutosmi += intervaloR (5);
				mMI += 1;
			}

			Contenido.sizeDelta = new Vector2 (Contenido.sizeDelta.x, Contenido.sizeDelta.y * (mMI));

			break;	

		case DayOfWeek.Thursday:
			int tj = 0;
			int horaj = int.Parse (InputHoraAm [6].text);
			int minutosj = 0;
			int mJ = 0;
			for (int i = 0; i <= obtenerNumeroInstancias (6, 6); i++) {
				PlanillaCitas [i].SetActive (true);
				if (minutosj >= 60) {

					horaj += 1;
					minutosj = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horaj;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosj;
				if (minutosj == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horaj.ToString ("D") + ":" + minutosj.ToString ("D") + "0" + "Am";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horaj.ToString ("D") + ":" + minutosj.ToString ("D") + "Am";
				}

				if (int.Parse (InputHoraAm [1].text) == PlanillaCitas [i].GetComponent<PlanillaCita> ().hora) {
					PlanillaCitas [i].SetActive (false);
				}
				minutosj += intervaloR (5);
				mJ += 1;
				tj += 1;
			}

			horaj = int.Parse (InputHoraPm [6].text);
			minutosj = 0;

			for (int i = tj; i <= tj + obtenerNumeroInstancias (7, 6); i++) {

				PlanillaCitas [i].SetActive (true);
				if (minutosj >= 60) {

					horaj += 1;
					minutosj = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horaj;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosj;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().Pm = true;
				if (minutosj == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horaj.ToString ("D") + ":" + minutosj.ToString ("D") + "0" + "Pm";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horaj.ToString ("D") + ":" + minutosj.ToString ("D") + "Pm";
				}
				minutosj += intervaloR (6);
				mJ += 1;
			}

			Contenido.sizeDelta = new Vector2 (Contenido.sizeDelta.x, Contenido.sizeDelta.y * (mJ));

			break;	

		case DayOfWeek.Friday: 
			int tv = 0;
			int horav = int.Parse (InputHoraAm [8].text);
			int minutosv = 0;
			int mV = 0;
			for (int i = 0; i <= obtenerNumeroInstancias (8, 8); i++) {
				PlanillaCitas [i].SetActive (true);
				if (minutosv >= 60) {

					horav += 1;
					minutosv = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horav;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosv;
				if (minutosv == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horav.ToString ("D") + ":" + minutosv.ToString ("D") + "0" + "Am";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horav.ToString ("D") + ":" + minutosv.ToString ("D") + "Am";
				}

				if (int.Parse (InputHoraAm [1].text) == PlanillaCitas [i].GetComponent<PlanillaCita> ().hora) {
					PlanillaCitas [i].SetActive (false);
				}
				minutosv += intervaloR (7);
				mV += 1;
				tv += 1;
			}

			horav = int.Parse (InputHoraPm [8].text);
			minutosv = 0;

			for (int i = tv; i <= tv + obtenerNumeroInstancias (9, 8); i++) {

				PlanillaCitas [i].SetActive (true);
				if (minutosv >= 60) {

					horav += 1;
					minutosv = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horav;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosv;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().Pm = true;
				if (minutosv == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horav.ToString ("D") + ":" + minutosv.ToString ("D") + "0" + "Pm";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horav.ToString ("D") + ":" + minutosv.ToString ("D") + "Pm";
				}
				minutosv += intervaloR (8);
				mV += 1;
			}

			Contenido.sizeDelta = new Vector2 (Contenido.sizeDelta.x, Contenido.sizeDelta.y * (mV));

			break;	

		case DayOfWeek.Saturday: 
			int ts = 0;
			int horas = int.Parse (InputHoraAm [10].text);
			int minutoss = 0;
			int mS = 0;
			for (int i = 0; i <= obtenerNumeroInstancias (10, 10); i++) {
				PlanillaCitas [i].SetActive (true);
				if (minutoss >= 60) {

					horas += 1;
					minutoss = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horas;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutoss;
				if (minutoss == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horas.ToString ("D") + ":" + minutoss.ToString ("D") + "0" + "Am";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horas.ToString ("D") + ":" + minutoss.ToString ("D") + "Am";
				}

				if (int.Parse (InputHoraAm [1].text) == PlanillaCitas [i].GetComponent<PlanillaCita> ().hora) {
					PlanillaCitas [i].SetActive (false);
				}
				minutoss += intervaloR (9);
				mS += 1;
				ts += 1;
			}

			horas = int.Parse (InputHoraPm [10].text);
			minutoss = 0;

			for (int i = ts; i <= ts + obtenerNumeroInstancias (11, 10); i++) {

				PlanillaCitas [i].SetActive (true);
				if (minutoss >= 60) {

					horas += 1;
					minutoss = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horas;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutoss;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().Pm = true;
				if (minutoss == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horas.ToString ("D") + ":" + minutoss.ToString ("D") + "0" + "Pm";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horas.ToString ("D") + ":" + minutoss.ToString ("D") + "Pm";
				}
				minutoss += intervaloR (10);
				mS += 1;
			}

			Contenido.sizeDelta = new Vector2 (Contenido.sizeDelta.x, Contenido.sizeDelta.y * (mS));

			break;	

		case DayOfWeek.Sunday: 
			int td = 0;
			int horad = int.Parse (InputHoraAm [12].text);
			int minutosd = 0;
			int mD = 0;
			for (int i = 0; i <= obtenerNumeroInstancias (12, 12); i++) {
				PlanillaCitas [i].SetActive (true);
				if (minutosd >= 60) {

					horad += 1;
					minutosd = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horad;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosd;
				if (minutosd == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horad.ToString ("D") + ":" + minutosd.ToString ("D") + "0" + "Am";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horad.ToString ("D") + ":" + minutosd.ToString ("D") + "Am";
				}

				if (int.Parse (InputHoraAm [1].text) == PlanillaCitas [i].GetComponent<PlanillaCita> ().hora) {
					PlanillaCitas [i].SetActive (false);
				}
				minutosd += intervaloR (9);
				mD += 1;
				td += 1;
			}

			horad = int.Parse (InputHoraPm [12].text);
			minutosd = 0;

			for (int i = td; i <= td + obtenerNumeroInstancias (13, 12); i++) {

				PlanillaCitas [i].SetActive (true);
				if (minutosd >= 60) {

					horad += 1;
					minutosd = 0;

				}
				PlanillaCitas [i].GetComponent<PlanillaCita> ().year = Calendar_call.year;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().month = Calendar_call.month;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().day = Calendar_call.day;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().hora = horad;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().minuto = minutosd;
				PlanillaCitas [i].GetComponent<PlanillaCita> ().Pm = true;
				if (minutosd == 0) {
					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horad.ToString ("D") + ":" + minutosd.ToString ("D") + "0" + "Pm";
				} else {

					PlanillaCitas [i].GetComponent<PlanillaCita> ().HoraCita.text = horad.ToString ("D") + ":" + minutosd.ToString ("D") + "Pm";
				}
				minutosd += intervaloR (10);
				mD += 1;
			}

			Contenido.sizeDelta = new Vector2 (Contenido.sizeDelta.x, Contenido.sizeDelta.y * (mD));

			break;	
		}

	}

	int obtenerNumeroInstancias(int SelecDropDown, int Selectinput){
		int Resultado = 0;
		switch (Intervalos [SelecDropDown].value) {
		case 0:
			
			Resultado = (int.Parse (InputHoraAm [Selectinput+1].text) * 60 + int.Parse (InputMinAm [Selectinput+1].text) ) - (int.Parse (InputHoraAm [Selectinput].text) * 60 + int.Parse (InputMinAm [Selectinput].text)) ;
			Resultado /= 15;
			break;

		case 1:

			Resultado = (int.Parse (InputHoraAm [Selectinput+1].text) * 60 + int.Parse (InputMinAm [Selectinput+1].text) )  - (int.Parse (InputHoraAm [Selectinput].text) * 60 + int.Parse (InputMinAm [Selectinput].text)) ;
			Resultado /= 30;
			break;
		case 2:

			Resultado = (int.Parse (InputHoraAm [Selectinput+1].text) * 60 + int.Parse (InputMinAm [Selectinput+1].text) )  - (int.Parse (InputHoraAm [Selectinput].text) * 60 + int.Parse (InputMinAm [Selectinput].text)) ;
			Resultado /= 45;
			break;

		case 3:

			Resultado = (int.Parse (InputHoraAm [Selectinput+1].text) * 60 + int.Parse (InputMinAm [Selectinput+1].text) )  - (int.Parse (InputHoraAm [Selectinput].text) * 60 + int.Parse (InputMinAm [Selectinput].text)) ;
			Resultado /= 60;
			break;

		case 4:

			Resultado = (int.Parse (InputHoraAm [Selectinput+1].text) * 60 + int.Parse (InputMinAm [Selectinput+1].text) )  - (int.Parse (InputHoraAm [Selectinput].text) * 60 + int.Parse (InputMinAm [Selectinput].text)) ;
			Resultado /= 75;
			break;

		case 5:

			Resultado = (int.Parse (InputHoraAm [Selectinput+1].text) * 60 + int.Parse (InputMinAm [Selectinput+1].text) )  - (int.Parse (InputHoraAm [Selectinput].text) * 60 + int.Parse (InputMinAm [Selectinput].text)) ;
			Resultado /= 90;
			break;

		}
		return Resultado; 
	}

	int Pm(int SelecDropDown, int Selectinput){
		int Resultado = 0;
		switch (Intervalos [SelecDropDown].value) {
		case 0:

			Resultado = (int.Parse (InputHoraPm [Selectinput+1].text) * 60 + int.Parse (InputMinPm [Selectinput+1].text) ) - (int.Parse (InputHoraPm [Selectinput].text) * 60 + int.Parse (InputMinPm [Selectinput].text)) ;
			Resultado /= 15;
			break;

		case 1:

			Resultado = (int.Parse (InputHoraPm [Selectinput+1].text) * 60 + int.Parse (InputMinPm [Selectinput+1].text) )  - (int.Parse (InputHoraPm [Selectinput].text) * 60 + int.Parse (InputMinPm [Selectinput].text)) ;
			Resultado /= 30;
			break;
		case 2:

			Resultado = (int.Parse (InputHoraPm [Selectinput+1].text) * 60 + int.Parse (InputMinPm [Selectinput+1].text) )  - (int.Parse (InputHoraPm [Selectinput].text) * 60 + int.Parse (InputMinPm [Selectinput].text)) ;
			Resultado /= 45;
			break;

		case 3:

			Resultado = (int.Parse (InputHoraPm [Selectinput+1].text) * 60 + int.Parse (InputMinPm [Selectinput+1].text) )  - (int.Parse (InputHoraPm[Selectinput].text) * 60 + int.Parse (InputMinPm [Selectinput].text)) ;
			Resultado /= 60;
			break;

		case 4:

			Resultado = (int.Parse (InputHoraPm [Selectinput+1].text) * 60 + int.Parse (InputMinPm [Selectinput+1].text) )  - (int.Parse (InputHoraPm [Selectinput].text) * 60 + int.Parse (InputMinPm [Selectinput].text)) ;
			Resultado /= 75;
			break;

		case 5:

			Resultado = (int.Parse (InputHoraPm [Selectinput+1].text) * 60 + int.Parse (InputMinPm [Selectinput+1].text) )  - (int.Parse (InputHoraPm [Selectinput].text) * 60 + int.Parse (InputMinPm [Selectinput].text)) ;
			Resultado /= 90;
			break;

		}
		return Resultado; 
	}

	int intervaloR(int selecarray){
		int result = 0;

		switch (Intervalos [selecarray].value) {
		case 0:
			result = 15;
			break;
		case 1:
			result = 30;
			break;

		case 2:
			result = 45;
			break;

		case 3:
			result = 60;
			break;

		case 4:
			result = 75;
			break;

		case 5:
			result = 90;
			break;
		}

		return result;
	}

	public void LimpiarPlanilla(){
		Contenido.sizeDelta = new Vector2 (Contenido.sizeDelta.x, 97.9f);

		for (int i = 0; i < PlanillaCitas.Length; i++) {

			PlanillaCitas [i].SetActive (false);
			PlanillaCitas [i].GetComponent<PlanillaCita> ().Pm = false;

		}
	}
}

[System.Serializable]
public class Citas{

	public int Año;
	public int Mes;
	public int Dia;
	public int Hora;
	public int Minuto;
	public bool PM;
	public string Nombre;
	public string Cedula;
	public string tlf1;
	public string tlf2;
	public string email;

}
