using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject Line;
    public GameObject NotesGenerator;
    public GameObject KeyInputHandler;
    public GameObject NotesManager;
    public GameObject EffectGenerator;
    public GameObject MusicPlayer;
    public GameObject AnswerSoundPlayer;
    public GameObject PlayingSettings;
    public List<NotesManager> Lanes;
    public List<LaneBackEffected> EffectedLanes;
    public GameObject NotesDataManager;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update () {
		
	}
}
