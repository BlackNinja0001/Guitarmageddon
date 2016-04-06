/*
	Instantiates notes according to the song.
*/

using UnityEngine;
using System.Collections;

public class SongManager : MonoBehaviour {

	/*
	private static Transform noteA;
	private static Transform noteS;
	private static Transform noteD;
	private static Transform noteF;
	private static Transform noteJ;
	private static Transform noteK;
	private static Transform noteL;
	private static Transform noteSEMI;
	*/

	private Transform note;

	//Determines what notes to be instantiated, where, and when
	public float songLength = 0;
	private double[] noteInsts;	//need to find through trial and error


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		songLength += Time.deltaTime;

		//timeframe for A
		for (int i = 0; i < noteInsts.Length; i++){
			if (songLength == noteInsts[i]){	
				Instantiate(note, note.position, note.rotation);
			}	
		}
		//more timeframes for all other keys
	}
}
