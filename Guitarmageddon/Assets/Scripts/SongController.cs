using UnityEngine;
using System.Collections;

public class SongController : MonoBehaviour {

	public Transform noteA;
	public Transform noteS;
	public Transform noteD;
	public Transform noteF;
	public Transform noteJ;
	public Transform noteK;
	public Transform noteL;
	public Transform noteSEMI;

	//Determines what notes to be instantiated, where, and when
	public float songLength = 0;

	public KeyCode keyA;
	public KeyCode keyS;
	public KeyCode keyD;
	public KeyCode keyF;
	public KeyCode keyJ;
	public KeyCode keyK;
	public KeyCode keyL;
	public KeyCode keySEMI;

	public static string destroyA = "n";
	public static string destroyS = "n";
	public static string destroyD = "n";
	public static string destroyF = "n";
	public static string destroyJ = "n";
	public static string destroyK = "n";
	public static string destroyL = "n";
	public static string destroySEMI = "n";



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per physics step
	void FixedUpdate () {
		
		songLength += Time.deltaTime;

		//timeframe for A
		if (true){	//need to find through trial and error
			Instantiate(noteA, noteA.position, noteA.rotation);
		}	
		//more timeframes for all other keys

	}

	void OnTriggerStay2D (Collider2D other){
		if (Input.GetKeyDown(keyA) && other.gameObject.name == "noteA(Clone)"){
			destroyA = "y";
		}
		// other notes
	}
}
