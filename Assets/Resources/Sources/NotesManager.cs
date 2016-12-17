using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour {
    public GameObjectManager GameObjectManager;
    private PlayingSettings PlayingSettings;

    private List<NoteData> Notes;
    private int ShowCursor;
    private int JudgeCursor;
    private List<GameObject> CreatedNotes;

    private float StartTime;

    private NotesGenerator NotesGenerator;
    private KeyInputHandler KeyInputHandler;
    private EffectGenerator EffectGenerator;
    private AudioSource AnswerSound;
    private AudioSource MusicPlayer;

    private float NoteSpeed;
    private float JudgeRange;
    private bool IsUseAnswerSound;
    
    public bool IsBegin;

    // Use this for initialization
    void Start()
    {
        Initialize();
        SetNoteDatas();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBegin)
        {
            var musicTime = Time.timeSinceLevelLoad - StartTime;
            ShowNote(musicTime);
            JudgeNote(musicTime);
        }
    }

    private void Initialize()
    {
        PlayingSettings = GameObjectManager.PlayingSettings.GetComponent<PlayingSettings>();
        IsBegin = false;
        NoteSpeed = PlayingSettings.NoteSpeed;
        JudgeRange = PlayingSettings.JudgeRange;
        IsUseAnswerSound = PlayingSettings.IsUseAnswerSound;
        ShowCursor = 0;
        JudgeCursor = 0;
        NotesGenerator = GameObjectManager.NotesGenerator.GetComponent<NotesGenerator>();
        CreatedNotes = new List<GameObject>();
        KeyInputHandler = GameObjectManager.KeyInputHandler.GetComponent<KeyInputHandler>();
        EffectGenerator = GameObjectManager.EffectGenerator.GetComponent<EffectGenerator>();
        AnswerSound = GameObjectManager.AnswerSoundPlayer.GetComponent<AudioSource>();
        MusicPlayer = GameObjectManager.MusicPlayer.GetComponent<AudioSource>();
    }

    private void SetNoteDatas()
    {
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
            // DesktopPC
            //Notes[i].Time += 4.15f;
            //Notes[i].Time -= 4f;
            // NotePC
            //Notes[i].Time += 0;
            Notes[i].Time -= 0.135f; //曲の補正
            Notes[i].Time += 0.29f; // 機器の補正
        }
    }
	
    public void MusicStart()
    {
        if (IsBegin)
        {
            return;
        }
        IsBegin = true;
        StartTime = Time.timeSinceLevelLoad;
        Debug.Log("MusicStart");
        MusicPlayer.Play();
    }

    public void ShowNote(float musicTime)
    {
        if (ShowCursor < Notes.Count && Notes[ShowCursor].Time - NoteSpeed <= musicTime)
        {
            CreatedNotes.Add(NotesGenerator.GenerateNote());
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
            // アンサー音
            if (IsUseAnswerSound && musicTime - Notes[JudgeCursor].Time >= 0)
            {
                CreatedNotes[0].GetComponent<Note>().AnswerSound(AnswerSound);
            }
        }
    }
}
