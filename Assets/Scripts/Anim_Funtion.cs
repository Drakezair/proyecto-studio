using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Anim_Funtion : MonoBehaviour {



	public void MoveTo (Scrollbar objeto, float pos, float to, float speed,bool rezice)
	{
		

		if (!rezice) {
			if (pos < to) {
				objeto.value += speed * Time.deltaTime; 

				if (objeto.value >= to) {
					objeto.value = to;
				}
			}

			if (pos > to) {

				objeto.value -= speed * Time.deltaTime; 

				if (objeto.value <= to) {
					objeto.value = to;
				}
			}
		} else {

			if (pos < to) {
				objeto.size += speed * Time.deltaTime; 

				if (objeto.size >= to) {
					objeto.size = to;
				}
			}

			if (pos > to) {

				objeto.size -= speed * Time.deltaTime; 

				if (objeto.size <= to) {
					objeto.size = to;
				}
			}

		}
	}
}
