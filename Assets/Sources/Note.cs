using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public float NoteSpeed = 1;
    public float LinePosition;
    public GameObject Effect;

	// Use this for initialization
	void Start () {
        var line = GameObject.Find("Line");
        var lineTransform = line.GetComponent<Transform>();
        LinePosition = lineTransform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        var transform = GetComponent<Transform>();
        Vector2 now = transform.position;
        var movedPosition = new Vector2(now.x, now.y - 0.2f);
        transform.position = movedPosition;
        if(movedPosition.y <= LinePosition)
        {
            Debug.Log("Good");
            Instantiate(Effect, GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);
            var controller = GameObject.Find("GameController").GetComponent<GameController>();
            controller.CreateNote();
        }
	}
}
