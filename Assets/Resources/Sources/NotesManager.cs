using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour {
    public List<NoteData> Notes;
    public int ShowCursor;
    public int JudgeCursor;
    public float StartTime;
    public List<GameObject> CreatedNotes;
    public GameObject NotesGenerator;
    public NotesGenerator Generator;
    public float NoteSpeed;

	// Use this for initialization
	void Start () {
        NoteSpeed = 1;
        ShowCursor = 0;
        JudgeCursor = 0;
        Generator = NotesGenerator.GetComponent<NotesGenerator>();
        StartTime = Time.timeSinceLevelLoad;
        Notes = new List<NoteData>();
        Notes.Add(new NoteData(1f));
        Notes.Add(new NoteData(2f));
        Notes.Add(new NoteData(3f));
        Notes.Add(new NoteData(4f));
        CreatedNotes = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        var musicTime = Time.timeSinceLevelLoad - StartTime;
        ShowNote(musicTime);
	}

    public void ShowNote(float musicTime)
    {
        if (ShowCursor < Notes.Count && Notes[ShowCursor].Time - NoteSpeed <= musicTime)
        {
            CreatedNotes.Add(Generator.GenerateNote());
            ShowCursor++;
        }
    }
}
