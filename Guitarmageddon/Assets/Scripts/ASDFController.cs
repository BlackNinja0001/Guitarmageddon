/*
	Instantiates notes according to SongManager.
*/

using UnityEngine;
using System.Collections;


public class ASDFController : MonoBehaviour {

	public float scrollSpeed;
	public float inputOffset;
	public Transform checker;
	private Transform inst;
	private int noteLimitOnOneTrack = 1;	//arbitrary for now
	private int howMany = 0;
	private bool withinRange = false;
	private char[] firstNotesBeforeSong;
	private float[] firstDelaysBeforeSong;

	void Awake () {
		//spawn first note (before music plays)
		//for now
		firstNotesBeforeSong = new char[]{'a', 'a'};
		firstDelaysBeforeSong = new float[]{1f, 1f};

		for (int i = 0; i < firstNotesBeforeSong.Length; i++){
			char firstNote = firstNotesBeforeSong[i];
			if (firstNote == 'a' && gameObject.name == "A Note"){
				//StartCoroutine(Delay(firstDelaysBeforeSong[i]));
				Instantiate(transform, transform.position, Quaternion.identity);
				Invoke("moveNoteRight", firstDelaysBeforeSong[i]);
			}
		}
		
	}

	void Start(){

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameObject.name == "A Note" && SongManager.spawnA == true){	//No clones of clones anymore
			Debug.Log("ASDFController: Spawning note A at " + SongManager.songLength);
			SongManager.spawnA = false;
			if (howMany < noteLimitOnOneTrack){	// So that infinite notes don't spawn on track
				howMany++;
				// Spawn note
				//inst = Instantiate(transform, transform.position, Quaternion.identity) as Transform;

				//Move note to checker
				//inst.position = Vector3.MoveTowards(inst.position, checker.position, scrollSpeed * Time.deltaTime);

				howMany--;
			}
		}

		//Moving the notes
		moveNoteRight();

	}

	void moveNoteRight(){
		if (gameObject.name == "A Note(Clone)"){
			GetComponent<Rigidbody2D>().velocity = new Vector3(1.0f * scrollSpeed, 0, 0);	//right
		}
	}

	// Coroutine to delay something by "waitTime" seconds
	// Use StartCoroutine(Delay(**seconds**)) to implement
	IEnumerator Delay(float waitTime) {
		Debug.Log("Delaying the inevitable.");
		//Debug.Log("Metronome: " + SongManager.metroLength);
		//Debug.Log("Song: " + SongManager.songLength);
		yield return new WaitForSeconds(waitTime); //Test
	}
}
