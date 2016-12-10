using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public float NoteSpeed = 1f;
    public float LinePosition;
    public GameObject Effect;
    public GameObject MainCamera;

    public NoteData NoteData = new NoteData(16f);
    public float StartTime;
    public float EndTime;
    public Vector3 StartPosition;
    public Vector3 EndPosition;

	// Use this for initialization
	void Start () {
        MainCamera = GameObject.Find("Main Camera");
        //var line = GameObject.Find("Line");
        //var lineTransform = line.GetComponent<Transform>();
        //LinePosition = lineTransform.position.y;
        StartTime = Time.timeSinceLevelLoad;
        EndTime = StartTime + NoteSpeed; // 後々ミス許容を足すこと。
        var camera = MainCamera.GetComponent<Camera>();
        StartPosition = camera.ScreenToWorldPoint(new Vector3(0, camera.pixelHeight));
        StartPosition.z = 0;
        StartPosition.x = 0;
        EndPosition = camera.ScreenToWorldPoint(Vector3.zero);
        EndPosition.x = 0;
        EndPosition.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //var transform = GetComponent<Transform>();
        //Vector2 now = transform.position;
        //var movedPosition = new Vector2(now.x, now.y - 0.2f);
        //transform.position = movedPosition;
        //if(movedPosition.y <= LinePosition)
        //{
        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        Debug.Log("Good");
        //        Instantiate(Effect, GetComponent<Transform>().position, Quaternion.identity);
        //    }
        //    Destroy(gameObject);
        //    var controller = GameObject.Find("GameController").GetComponent<GameController>();
        //    controller.CreateNote();
        //}
        var diff = Time.timeSinceLevelLoad - StartTime;
        var rate = diff / EndTime;
        transform.position = Vector3.Lerp(StartPosition, EndPosition, rate);
    }
}

// 一つのノートのデータを扱うクラス
public enum NoteTypes { normal};
public class NoteData
{
    public float Time;
    public NoteTypes Type = NoteTypes.normal;

    public NoteData(float time)
    {
        Time = time;
    }
}
