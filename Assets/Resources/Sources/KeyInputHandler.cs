using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputHandler : MonoBehaviour {

    NotesManager NotesManager;
	// Use this for initialization
	void Start () {
        NotesManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NotesManager.MusicStart();
        }
	}

    public bool IsPressed(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }

    public bool IsPressing(KeyCode key)
    {
        return Input.GetKey(key);
    }
}
