/*
	 Checks if appropriate key is pressed and checker is colliding with returns "destroyable" message to SongManager
*/

using UnityEngine;
using System.Collections;

public class CheckerController : MonoBehaviour {

	
	public KeyCode keyLeft;
	public KeyCode keyRight;

	private bool correctNoteCollision = false;
	public Transform correctNoteLeft;
	public Transform correctNoteRight;
	public Transform correctBurst;

	public static char destroyA = 'n';
	public static char destroyS = 'n';
	public static char destroyD = 'n';
	public static char destroyF = 'n';
	public static char destroyJ = 'n';
	public static char destroyK = 'n';
	public static char destroyL = 'n';
	public static char destroySEMI = 'n';


	// Use this for initialization
	void Start () {
		//Initialize note instantiations
	}
	
	// Update is called once per physics step
	void Update () {
		if (Input.GetKeyDown(keyLeft)) {
			Debug.Log("Key " + keyLeft + " for " + gameObject.name + " pressed.");
			if (correctNoteCollision){
				destroyA = 'y';
				Debug.Log("Note " + keyLeft + " destroyable.");
			}
		} else if (Input.GetKeyDown(keyRight)) {
			Debug.Log("Key " + keyRight + " for " + gameObject.name + " pressed.");
			if (correctNoteCollision){
				destroyJ = 'y';
				Debug.Log("Note " + keyRight + " destroyable.");
			}
		} else if (Input.GetKeyUp(keyLeft)) {
			Debug.Log("Key " + keyLeft + " for " + gameObject.name + " released.");
			destroyA = 'n';
		} else if (Input.GetKeyDown(keyRight)) {
			Debug.Log("Key " + keyRight + " for " + gameObject.name + " released.");
			destroyJ = 'n';
		}

		// Bug: player can hold down all buttons for the entire song and win
	}

	// Note press accepted
	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.name == (correctNoteLeft.name + "(Clone)") || 
			other.gameObject.name == (correctNoteRight.name + "(Clone)"))
		{
			//Debug.Log("destroyA: " + destroyA);
			Debug.Log(other.name + " within range of " + gameObject.name);
			correctNoteCollision = true;
			if (destroyA.Equals('y') //appropriate key is pressed
				&& 
				other.name.Equals("A Note(Clone)")){	//right note to destroy
				Debug.Log("Destroying " + other.name);
				Destroy(other.gameObject);
				Instantiate(correctBurst, other.transform.position, correctBurst.rotation);
				destroyA.Equals('n');
			}
		}

	}

	// Waited too long, missed note
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.name == (correctNoteLeft.name + "(Clone)") || 
			other.gameObject.name == (correctNoteRight.name + "(Clone)"))
		{
			//Debug.Log("destroyA: " + destroyA);
			Debug.Log(other.name + " out of range of " + gameObject.name);
			correctNoteCollision = false;
			if (gameObject.name.Equals("A Note(Clone)")){
				//maybe play a failure sound effect
				Destroy(other.gameObject);
				destroyA.Equals('n');
			}
		}
	}
}
