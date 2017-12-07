using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Weekview : MonoBehaviour {

	public  Button l,m,x,j,v,s,d;
	public Text mm_yyyy;
	public Calendar calendar_call;
	DateTime weekfirstday;
	DateTime DiaCurrent;

	// DATEPIKER DE CADA DIA
	DateTime Domingo;
	DateTime Lunes;
	DateTime Martes;
	DateTime Miercoles;
	DateTime Jueves;
	DateTime Viernes;
	DateTime Sabado;

	void Start ()
	{
	
	}
		
	void Update ()
	{		
		DiaCurrent = new DateTime(calendar_call.year,calendar_call.month,calendar_call.day);
		weekfirstday = DiaCurrent.AddDays(DayOfWeek.Sunday - DiaCurrent.DayOfWeek);
		mm_yyyy.text = calendar_call.datetime.ToString("MMMM/yyyy");

		//Obtener el Datetime de de cada dia
		Domingo = weekfirstday;
		Lunes = weekfirstday.AddDays(1);
		Martes = weekfirstday.AddDays(2);
		Miercoles = weekfirstday.AddDays(3);
		Jueves = weekfirstday.AddDays(4);
		Viernes = weekfirstday.AddDays(5);
		Sabado = weekfirstday.AddDays(6);

		//Enviar El Datetime a cada boton

		//Dias
		d.GetComponent<ButtonsWeekView>().day = Domingo.Day;
		l.GetComponent<ButtonsWeekView>().day = Lunes.Day;
		m.GetComponent<ButtonsWeekView>().day = Martes.Day;
		x.GetComponent<ButtonsWeekView>().day = Miercoles.Day;
		j.GetComponent<ButtonsWeekView>().day = Jueves.Day;
		v.GetComponent<ButtonsWeekView>().day = Viernes.Day;
		s.GetComponent<ButtonsWeekView>().day = Sabado.Day;

		//Meses
		d.GetComponent<ButtonsWeekView>().month = Domingo.Month;
		l.GetComponent<ButtonsWeekView>().month = Lunes.Month;
		m.GetComponent<ButtonsWeekView>().month = Martes.Month;
		x.GetComponent<ButtonsWeekView>().month = Miercoles.Month;
		j.GetComponent<ButtonsWeekView>().month = Jueves.Month;
		v.GetComponent<ButtonsWeekView>().month = Viernes.Month;
		s.GetComponent<ButtonsWeekView>().month = Sabado.Month;

		//AÑOS
		d.GetComponent<ButtonsWeekView>().year = Domingo.Year;
		l.GetComponent<ButtonsWeekView>().year = Lunes.Year;
		m.GetComponent<ButtonsWeekView>().year = Martes.Year;
		x.GetComponent<ButtonsWeekView>().year = Miercoles.Year;
		j.GetComponent<ButtonsWeekView>().year = Jueves.Year;
		v.GetComponent<ButtonsWeekView>().year = Viernes.Year;
		s.GetComponent<ButtonsWeekView>().year = Sabado.Year;
	}

	public void NextWeek()
	{
		DateTime NuevaFecha = DiaCurrent.AddDays(7);
		calendar_call.day = NuevaFecha.Day;
		calendar_call.month = NuevaFecha.Month;
		calendar_call.year = NuevaFecha.Year;
		calendar_call.datetime = NuevaFecha;
	}

		public void BackWeek()
	{
		DateTime NuevaFecha = DiaCurrent.AddDays(-7);
		calendar_call.day = NuevaFecha.Day;
		calendar_call.month = NuevaFecha.Month;
		calendar_call.year = NuevaFecha.Year;
		calendar_call.datetime = NuevaFecha;
	}
}
