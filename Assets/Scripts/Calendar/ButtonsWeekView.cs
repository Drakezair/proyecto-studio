using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class ButtonsWeekView : MonoBehaviour {

	public int year;
	public int month;
	public int day;
	public Color ColorActive;	
	public Calendar calendar_CALL;

	void Start ()
	{
	
	}
		
	void Update ()
	{
		if(gameObject.activeInHierarchy)
		{
			gameObject.GetComponentInChildren<Text>().text = day.ToString("D");

			if(calendar_CALL.day == day && calendar_CALL.month == month && calendar_CALL.year == year)
			{
				GetComponent<Image>().color = new Color(ColorActive.r,ColorActive.g,ColorActive.b);
			}
			else
			{
				GetComponent<Image>().color = Color.white;
			}
		}		
	}

	public void DayCHange()
	{
		calendar_CALL.datetime = new DateTime(year,month,day);
		calendar_CALL.day = day;
		calendar_CALL.month = month;
		calendar_CALL.year = year;
	}
}
