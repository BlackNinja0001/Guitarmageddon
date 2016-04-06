/*
	Instantiates notes according to SongManager.
*/

using UnityEngine;
using System.Collections;


public class ASDFController : MonoBehaviour {

	public int scrollSpeed;
	public float inputOffset;
	public Transform checker;
	private Transform inst;
	private int noteLimitOnOneTrack = 1;	//arbitrary for now
	private int howMany = 0;
	private bool withinRange = false;
	private bool allowSpawn = true;

	// Use this for initialization
	void Start () {
		//Moving the notes
		if (gameObject.name == "A Note(Clone)"){
			GetComponent<Rigidbody2D>().velocity = new Vector3(1.0f * scrollSpeed, 0, 0);	//right
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.name == "A Note"){	//No clones of clones anymore
			if (allowSpawn){	//going for a mutex semaphore / producer-consumer thing here
				allowSpawn = false;
				if (howMany < noteLimitOnOneTrack){	// So that infinite notes don't spawn on track
					
					Debug.Log("Spawning Note...");
					// Spawn note
					inst = Instantiate(transform, transform.position, Quaternion.identity) as Transform;

					//Move note to checker
					inst.position = Vector3.MoveTowards(inst.position, checker.position, scrollSpeed * Time.deltaTime);

					howMany++;
					Debug.Log(gameObject.name + ".howMany = " + howMany);

					StartCoroutine(Delay(1));
					
				}
				allowSpawn = true;
			}
		}
	}

	// Coroutine to delay something by "waitTime" seconds
	IEnumerator Delay(float waitTime) {
		yield return new WaitForSeconds(waitTime); //Test
	}
}
