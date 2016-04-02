using UnityEngine;
using System.Collections;

public class ASDFController : MonoBehaviour {

	public Transform burst;

	// Use this for initialization
	void Start () {
		if (gameObject.name == "noteA(Clone)"){
			GetComponent<Rigidbody2D>().velocity = new Vector3(-.21f, -1, 0);	//fiddle around with settings
		}
		//other notes
	}
	
	// Update is called once per frame
	void Update () {
		if (SongController.destroyA.Equals('y') && gameObject.name.Equals("noteA(Clone)") && transform.position.y <= -3.5){	//fiddle around
			Destroy(gameObject);
			Instantiate(burst, transform.position, burst.rotation);
		}
		//other notes
	}
}
