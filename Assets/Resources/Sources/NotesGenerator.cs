﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour {
    private float timeLeft;
    public GameObject Note;
    public List<float> Notes;
    public float StartTime;
    public GameObject NotesManager;

	// Use this for initialization
	void Start () {
        NotesManager = GameObject.Find("NotesManager");
	}
	
	// Update is called once per frame
	void Update () { 
	}

    public GameObject GenerateNote()
    {
        GameObject createdObject = Instantiate(Note, new Vector2(0, 5000), Quaternion.identity);
        createdObject.transform.parent = NotesManager.transform;
        return createdObject;
    }
}
