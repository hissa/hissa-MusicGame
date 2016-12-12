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
    public float JudgeRange;
    public GameObject KeyInputHandlerObject;
    public KeyInputHandler KeyInputHandler;
    public GameObject EffectGeneratorObject;
    public EffectGenerator EffectGenerator;

	// Use this for initialization
	void Start () {
        NoteSpeed = 1f;
        ShowCursor = 0;
        JudgeCursor = 0;
        Generator = NotesGenerator.GetComponent<NotesGenerator>();
        StartTime = Time.timeSinceLevelLoad;
        Notes = new List<NoteData>();
        Notes.Add(new NoteData(3f));
        Notes.Add(new NoteData(3.3636f));
        Notes.Add(new NoteData(3.5454f));
        Notes.Add(new NoteData(3.7272f));
        //Notes.Add(new NoteData(5f));
        CreatedNotes = new List<GameObject>();
        JudgeRange = 0.05f;
        KeyInputHandler = KeyInputHandlerObject.GetComponent<KeyInputHandler>();
        EffectGenerator = EffectGeneratorObject.GetComponent<EffectGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
        var musicTime = Time.timeSinceLevelLoad - StartTime;
        ShowNote(musicTime);
        JudgeNote(musicTime);
	}

    public void ShowNote(float musicTime)
    {
        if (ShowCursor < Notes.Count && Notes[ShowCursor].Time - NoteSpeed <= musicTime)
        {
            CreatedNotes.Add(Generator.GenerateNote());
            ShowCursor++;
        }
    }

    public void JudgeNote(float musicTime)
    {
        if(JudgeCursor < Notes.Count)
        {
            Debug.Log(CreatedNotes.Count);
            if (KeyInputHandler.IsPressed(KeyCode.Space) && Mathf.Abs(musicTime - Notes[JudgeCursor].Time) <= JudgeRange)
            {
                EffectGenerator.ShowEffect();
                Destroy(CreatedNotes[0]);
                CreatedNotes.RemoveAt(0);
                JudgeCursor++;
            } else if (musicTime - Notes[JudgeCursor].Time > 0 && Mathf.Abs(Notes[JudgeCursor].Time - musicTime) > JudgeRange) 
            {
                Debug.Log("miss");
                JudgeCursor++;
                CreatedNotes.RemoveAt(0);
            }
        }
    }
}
