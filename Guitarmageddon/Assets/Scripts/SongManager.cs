/*
	Instantiates notes according to the song.
*/

using UnityEngine;
using System;
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

	public AudioSource music;
	public AudioSource metronome;	//need to adjust according to bpm

	//Determines what notes to be instantiated, where, and when
	public static float songLength, metroLength;
	private double[] noteInsts;
	private int bpm, sampleRate;
	private int timeSig = 4; //beats per measure, 4/4
	public int leadingTime;	//how long it takes for note to reach checker
	public float offset;


	public static bool spawnA = false;
	public static bool spawnS;
	public static bool spawnD;
	public static bool spawnF;
	public static bool spawnJ;
	public static bool spawnK;
	public static bool spawnL;
	public static bool spawnSEMI;

	//Thanks Adam!
	// EVENTS
	public delegate void BeatEvent();  // feel free to edit this delegate - it may be useful to send some arguments through each event? 
	public static event BeatEvent OnBeat;  // event fires on quarter notes
	public static event BeatEvent OnEighthBeat; // event fires on 8th notes
	public static event BeatEvent OnMeasure; // event fires on measures
	// add more events for any timing you need! 

	public int beatsPerSecond { get { return bpm / 60; } }
	public int samplesPerQuarterNote { get { return sampleRate / beatsPerSecond; } }
	public int samplesPerEighthNote { get { return samplesPerQuarterNote / 2; } }
	public int samplesPerMeasure { get { return samplesPerQuarterNote * timeSig; } }

	void Awake(){
		sampleRate = AudioSettings.outputSampleRate;
		//Debug.Log("sampleRate = " + sampleRate + " Hz.");
	}

	// plays metronome effect, then music
	// buggy
	IEnumerator metronomeAndMusic(){
		Debug.Log("Play it again, Sam! SongLength = " + songLength);
		metronome.Play();
		//send first note?
		yield return new WaitForSeconds(metronome.clip.length - (float)(metronome.clip.length*.42));	//dead air at end of metronome clip
		music.Play();
	}

	// Use this for initialization
	void Start () {
		// Hardcoded to 8bit Dungeon Boss sample music
		bpm = 134;

/*
		spawnA = false;
		spawnS = false; 
		spawnD = false;
		spawnF = false;
		spawnJ = false;
		spawnK = false;
		spawnL = false;
		spawnSEMI = false;
*/
		// Sample hardcoded samples for testing
		noteInsts = new double[]{0, 5120, 29696, 50176, 71680, 94208, 104448, 115712, 124928, 136192, 
		145408, 157696, 168960, 180224, 202752, 222208, 242688, 265216, 276480, 287744, 296960, 308224, 
		317440, 327680, 339968, 351232, 372736, 392192, 415744, 436224, 448512, 458752, 470016, 479232, 
		490496, 499712, 512000, 521216, 543744, 566272, 587776, 606208, 628736, 650240, 670720};
	
		//StartCoroutine(metronomeAndMusic());
		metronome.Play();
		Debug.Log("Metronome: " + metroLength);
		Debug.Log("Song: " + songLength);
		music.PlayDelayed(metronome.clip.length);
		Debug.Log("Metronome: " + metroLength);
		Debug.Log("Song: " + songLength);
		
	}
	
	void FixedUpdate () {
		songLength = music.timeSamples;
		metroLength = metronome.timeSamples;
		//Debug.Log("songLength = " + songLength);

		//timeframe for A
		for (int i = 0; i < noteInsts.Length; i++){
			if ((songLength >= noteInsts[i]-offset) || (songLength <= noteInsts[i]+offset)/*+((leadingTime+1)*1024)*/){
				spawnNote('A');
			}
		}
		//more timeframes for all other keys
	}

	//Sends a signal to ASDFController or JKL:Controller to deploy a note from its origin point
	public static void spawnNote(char whatNote){
		if (Char.ToUpper(whatNote) == 'A'){
			Debug.Log("SongManager: Spawning note A at " + songLength);
			spawnA = true;
		}
		//other notes

	}
}
