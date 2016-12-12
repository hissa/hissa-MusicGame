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
	}
	
	// Update is called once per frame
	void Update () { 
	}

    public GameObject GenerateNote()
    {
        GameObject createdObject = Instantiate(Note, new Vector2(0, 1000), Quaternion.identity);
        return createdObject;
    }
}
