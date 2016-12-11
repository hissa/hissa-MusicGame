using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour {
    private float timeLeft;
    public GameObject Note;
    public List<float> Notes;
    public float StartTime;

	// Use this for initialization
	void Start () {
        Notes = new List<float>();
        Notes.Add(1f);
        Notes.Add(2f);
        Notes.Add(3f);
        Notes.Add(4f);
        Notes.Add(5f);
        Notes.Add(5.5f);
        Notes.Add(6f);
        Notes.Add(6.5f);
        Notes.Add(7f);
        Notes.Add(7.5f);
        Notes.Add(8f);
        Notes.Add(8.5f);

        //for(var i = 0; i < Notes.Count; i++)
        //{
        //    Notes[i] += 10f;
        //}

        StartTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
        var musicTime = Time.timeSinceLevelLoad - StartTime;
        Debug.Log(musicTime);
        if (Notes.Count > 0 && Notes[0] <= musicTime)
        {
            Instantiate(Note, new Vector2(0, 10000), Quaternion.identity);
            Notes.RemoveAt(0);
        }
	}
}
