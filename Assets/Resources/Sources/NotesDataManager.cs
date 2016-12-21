using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesDataManager : MonoBehaviour {
    public List<NoteData> Notes { get; set; }
    public List<NoteData>[] LaneNotes = new List<NoteData>[5];
    public GameObjectManager GameObjectManager; 
	// Use this for initialization
	void Start () {
	}

    private void Awake()
    {
        SetNotes();
    }

    public void SetNotes()
    {
        Notes = new List<NoteData>();
        //Notes.Add(new NoteData(9.81818181818181f, Lanes.Lane0));
        //Notes.Add(new NoteData(10.1818181818182f, Lanes.Lane1));
        //Notes.Add(new NoteData(10.5454545454545f, Lanes.Lane2));
        //Notes.Add(new NoteData(10.9090909090909f, Lanes.Lane3));
        //Notes.Add(new NoteData(11.2727272727273f, Lanes.Lane5));
        //Notes.Add(new NoteData(11.6363636363636f));
        //Notes.Add(new NoteData(11.8181818181818f));
        //Notes.Add(new NoteData(12f));
        //Notes.Add(new NoteData(12.3636363636364f));
        //Notes.Add(new NoteData(12.7272727272727f));
        //Notes.Add(new NoteData(13.0909090909091f));
        //Notes.Add(new NoteData(13.4545454545454f));
        //Notes.Add(new NoteData(13.8181818181818f));
        //Notes.Add(new NoteData(14f));
        //Notes.Add(new NoteData(14.1818181818182f));
        //Notes.Add(new NoteData(14.5454545454545f));
        //Notes.Add(new NoteData(14.9090909090909f));
        //Notes.Add(new NoteData(15.2727272727273f));
        //Notes.Add(new NoteData(15.6363636363636f));
        //Notes.Add(new NoteData(16f));
        //Notes.Add(new NoteData(16.1818181818182f));
        //Notes.Add(new NoteData(16.3636363636364f));
        //Notes.Add(new NoteData(16.6363636363636f));
        //Notes.Add(new NoteData(16.9090909090909f));
        //Notes.Add(new NoteData(17.0909090909091f));
        //Notes.Add(new NoteData(17.2727272727273f));
        //Notes.Add(new NoteData(17.4545454545455f));
        //Notes.Add(new NoteData(17.7272727272727f));
        //Notes.Add(new NoteData(18f));
        //Notes.Add(new NoteData(18.1818181818182f));
        //Notes.Add(new NoteData(18.3636363636364f));
        //Notes.Add(new NoteData(18.5454545454545f));
        //Notes.Add(new NoteData(9.81818181818181f, Lanes.Lane0));
        //Notes.Add(new NoteData(10.1818181818182f, Lanes.Lane1));
        //Notes.Add(new NoteData(10.5454545454545f, Lanes.Lane2));
        //Notes.Add(new NoteData(10.9090909090909f, Lanes.Lane3));
        //Notes.Add(new NoteData(11.2727272727273f, Lanes.Lane4));
        //Notes.Add(new NoteData(11.6363636363636f, Lanes.Lane0));
        //Notes.Add(new NoteData(11.8181818181818f, Lanes.Lane1));
        //Notes.Add(new NoteData(12f, Lanes.Lane2));
        //Notes.Add(new NoteData(12.3636363636364f, Lanes.Lane3));
        //Notes.Add(new NoteData(12.7272727272727f, Lanes.Lane4));
        //Notes.Add(new NoteData(13.0909090909091f, Lanes.Lane0));
        //Notes.Add(new NoteData(13.4545454545454f, Lanes.Lane1));
        //Notes.Add(new NoteData(13.8181818181818f, Lanes.Lane2));
        //Notes.Add(new NoteData(14f, Lanes.Lane3));
        //Notes.Add(new NoteData(14.1818181818182f, Lanes.Lane4));
        //Notes.Add(new NoteData(14.5454545454545f, Lanes.Lane0));
        //Notes.Add(new NoteData(14.9090909090909f, Lanes.Lane1));
        //Notes.Add(new NoteData(15.2727272727273f, Lanes.Lane2));
        //Notes.Add(new NoteData(15.6363636363636f, Lanes.Lane3));
        //Notes.Add(new NoteData(16f, Lanes.Lane4));
        //Notes.Add(new NoteData(16.1818181818182f, Lanes.Lane0));
        //Notes.Add(new NoteData(16.3636363636364f, Lanes.Lane1));
        //Notes.Add(new NoteData(16.6363636363636f, Lanes.Lane2));
        //Notes.Add(new NoteData(16.9090909090909f, Lanes.Lane3));
        //Notes.Add(new NoteData(17.0909090909091f, Lanes.Lane4));
        //Notes.Add(new NoteData(17.2727272727273f, Lanes.Lane0));
        //Notes.Add(new NoteData(17.4545454545455f, Lanes.Lane1));
        //Notes.Add(new NoteData(17.7272727272727f, Lanes.Lane2));
        //Notes.Add(new NoteData(18f, Lanes.Lane3));
        //Notes.Add(new NoteData(18.1818181818182f, Lanes.Lane4));
        //Notes.Add(new NoteData(18.3636363636364f, Lanes.Lane0));
        //Notes.Add(new NoteData(18.5454545454545f, Lanes.Lane1));

        Notes.Add(new NoteData(1.25f, Lanes.Lane3));
        Notes.Add(new NoteData(2.5f, Lanes.Lane3));
        Notes.Add(new NoteData(3.125f, Lanes.Lane2));
        Notes.Add(new NoteData(3.4375f, Lanes.Lane3));
        Notes.Add(new NoteData(3.75f, Lanes.Lane4));
        Notes.Add(new NoteData(4.375f, Lanes.Lane3));
        Notes.Add(new NoteData(5f, Lanes.Lane2));
        Notes.Add(new NoteData(5.625f, Lanes.Lane3));
        Notes.Add(new NoteData(6.25f, Lanes.Lane0));
        Notes.Add(new NoteData(6.71875f, Lanes.Lane3));
        Notes.Add(new NoteData(6.875f, Lanes.Lane3));
        Notes.Add(new NoteData(7.5f, Lanes.Lane0));
        Notes.Add(new NoteData(7.96875f, Lanes.Lane4));
        Notes.Add(new NoteData(8.125f, Lanes.Lane4));
        Notes.Add(new NoteData(8.75f, Lanes.Lane0));
        Notes.Add(new NoteData(10f, Lanes.Lane2));
        Notes.Add(new NoteData(11.25f, Lanes.Lane4));
        Notes.Add(new NoteData(13.4375f, Lanes.Lane4));
        Notes.Add(new NoteData(13.515625f, Lanes.Lane3));
        Notes.Add(new NoteData(13.59375f, Lanes.Lane2));
        Notes.Add(new NoteData(13.671875f, Lanes.Lane1));
        Notes.Add(new NoteData(13.75f, Lanes.Lane0));

        for (var i = 0; i <= LaneNotes.Length - 1; i++)
        {
            LaneNotes[i] = new List<NoteData>();
        }
        foreach (var item in Notes)
        {
            LaneNotes[(int)item.Lane].Add(item);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // 譜面情報をファイルから読み込み
    public void ReadNotes()
    {
        
    }
}

// 一つのノートのデータを扱うクラス
public enum NoteTypes { normal };
public enum Lanes { Lane2, Lane1, Lane3, Lane4, Lane0};
public class NoteData
{
    public float Time;
    public NoteTypes Type = NoteTypes.normal;
    public Lanes Lane;

    public NoteData(float time)
    {
        Time = time;
    }

    public NoteData(float time, Lanes lane)
    {
        Time = time;
        Lane = lane;
    }
}
