using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GuardarLocal : MonoBehaviour {
	
	PlanillaDia PD_Call;

	float t;

	// Use this for initialization
	void Start () {
	
		PD_Call = FindObjectOfType<PlanillaDia> ();
		LoadLocal ();

	}
	
	// Update is called once per frame
	void Update () {
		t -= Time.deltaTime;
		if (t <= 0) {

			saveLocal ();
			t = 15f;

		}
	}

	public void saveLocal(){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create ("C:/Users/Drakezair/Desktop/BaseDeDatos.DB");  


		DataBase db = new DataBase ();
		db.CitasGuardadas = PD_Call.Citas; 

		bf.Serialize (file,db);
		file.Close();

	}

	public void LoadLocal (){
		if (File.Exists ("C:/Users/Drakezair/Desktop/BaseDeDatos.DB")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open ("C:/Users/Drakezair/Desktop/BaseDeDatos.DB",FileMode.Open); 

			DataBase db = (DataBase)bf.Deserialize(file);
			PD_Call.Citas = db.CitasGuardadas;
				
			file.Close();

		}
	}
}

[System.Serializable]
public class DataBase{
				

	public List<Citas> CitasGuardadas = new List<Citas>();

}
