using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputHandler : MonoBehaviour {

    public GameObjectManager GameObjectManager;
    NotesManager NotesManager;
	// Use this for initialization
	void Start () {
        NotesManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int laneCount = GameObjectManager.Lanes.Count;
            for (var i = 0; i <= laneCount - 1; i++)
            {
                GameObjectManager.Lanes[i].MusicStart();
            }
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
