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
    public GameObject MusicPlayer;

    public bool Begin;

	// Use this for initialization
	void Start () {
        Begin = false;
        NoteSpeed = 0.8f;
        ShowCursor = 0;
        JudgeCursor = 0;
        Generator = NotesGenerator.GetComponent<NotesGenerator>();
        Notes = new List<NoteData>();
        Notes.Add(new NoteData(9.81818181818181f));
        Notes.Add(new NoteData(10.1818181818182f));
        Notes.Add(new NoteData(10.5454545454545f));
        Notes.Add(new NoteData(10.9090909090909f));
        Notes.Add(new NoteData(11.2727272727273f));
        Notes.Add(new NoteData(11.6363636363636f));
        Notes.Add(new NoteData(11.8181818181818f));
        Notes.Add(new NoteData(12f));
        Notes.Add(new NoteData(12.3636363636364f));
        Notes.Add(new NoteData(12.7272727272727f));
        Notes.Add(new NoteData(13.0909090909091f));
        Notes.Add(new NoteData(13.4545454545454f));
        Notes.Add(new NoteData(13.8181818181818f));
        Notes.Add(new NoteData(14f));
        Notes.Add(new NoteData(14.1818181818182f));
        Notes.Add(new NoteData(14.5454545454545f));
        Notes.Add(new NoteData(14.9090909090909f));
        Notes.Add(new NoteData(15.2727272727273f));
        Notes.Add(new NoteData(15.6363636363636f));
        Notes.Add(new NoteData(16f));
        Notes.Add(new NoteData(16.1818181818182f));
        Notes.Add(new NoteData(16.3636363636364f));
        Notes.Add(new NoteData(16.6363636363636f));
        Notes.Add(new NoteData(16.9090909090909f));
        Notes.Add(new NoteData(17.0909090909091f));
        Notes.Add(new NoteData(17.2727272727273f));
        Notes.Add(new NoteData(17.4545454545455f));
        Notes.Add(new NoteData(17.7272727272727f));
        Notes.Add(new NoteData(18f));
        Notes.Add(new NoteData(18.1818181818182f));
        Notes.Add(new NoteData(18.3636363636364f));
        Notes.Add(new NoteData(18.5454545454545f));
        for (var i = 0; i < Notes.Count; i++)
        {
            //DesktopPC
            //Notes[i].Time += 4.15f;
            //Notes[i].Time -= 4f;
            Notes[i].Time += 0;
        }
        CreatedNotes = new List<GameObject>();
        JudgeRange = 0.065f;
        KeyInputHandler = KeyInputHandlerObject.GetComponent<KeyInputHandler>();
        EffectGenerator = EffectGeneratorObject.GetComponent<EffectGenerator>();
	}
	
    public void MusicStart()
    {
        if (Begin)
        {
            return;
        }
        Begin = true;
        StartTime = Time.timeSinceLevelLoad;
        Debug.Log("MusicStart");
        var mp = MusicPlayer.GetComponent<AudioSource>();
        mp.Play();
    }

	// Update is called once per frame
	void Update () {
        if (Begin)
        {
            var musicTime = Time.timeSinceLevelLoad - StartTime;
            ShowNote(musicTime);
            JudgeNote(musicTime);
        }
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
            if (KeyInputHandler.IsPressed(KeyCode.Space) && Mathf.Abs(musicTime - Notes[JudgeCursor].Time) <= JudgeRange)
            {
                EffectGenerator.ShowEffect();
                Destroy(CreatedNotes[0]);
                CreatedNotes.RemoveAt(0);
                JudgeCursor++;
            } else if (musicTime - Notes[JudgeCursor].Time > 0 && Mathf.Abs(Notes[JudgeCursor].Time - musicTime) > JudgeRange) 
            {
                JudgeCursor++;
                CreatedNotes.RemoveAt(0);
            }
        }
    }
}
