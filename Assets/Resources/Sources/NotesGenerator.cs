using System.Collections;
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

    // NoteDataを引数で受け取って、召喚した後NoteDataをオブジェクトに入れるように変更する
    public GameObject GenerateNote(GameObject calledObject)
    {
        GameObject createdObject = Instantiate(Note, new Vector2(0, 5000), Quaternion.identity);
        createdObject.transform.parent = calledObject.transform;
        return createdObject;
    }
}
