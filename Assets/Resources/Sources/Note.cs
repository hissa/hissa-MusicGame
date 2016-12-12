using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public float NoteSpeed;
    public static float LinePosition;
    static public GameObject Effect;
    static public GameObject MainCamera;
    private static Camera Camera;

    public NoteData NoteData = new NoteData(16f);
    public float StartTime;
    public float EndTime;
    public float JudgeTime;
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float MovingTime; // 移動に要する時間

    public float JudgeRange;
    public static NotesManager NotesManager;

	// Use this for initialization
	void Start () {
        if(NotesManager == null)
        {
            NotesManager = transform.root.gameObject.GetComponent<NotesManager>();
        }
        if (MainCamera == null)
        {
            MainCamera = GameObject.Find("Main Camera");
            Camera = MainCamera.GetComponent<Camera>();
        }
        if(LinePosition == 0)
        {
            LinePosition = GameObject.Find("Line").GetComponent<Transform>().position.y;
        }
        if(Effect == null)
        {
            Effect = Resources.Load("Prefabs/Particle") as GameObject;
        }
        NoteSpeed = NotesManager.NoteSpeed;
        StartTime = Time.timeSinceLevelLoad;
        StartPosition = GetStartPosition();
        EndPosition = GetEndPosition();
        MovingTime = GetMovingTime();
        EndTime = StartTime + MovingTime;
        JudgeTime = StartTime + NoteSpeed;

        JudgeRange = 0.05f;
    }

    private Vector3 GetStartPosition()
    {
        Vector3 startPosition = Camera.ScreenToWorldPoint(new Vector3(0, Camera.pixelHeight));
        startPosition.z = 0;
        startPosition.x = 0;
        return startPosition;
    }

    private Vector3 GetEndPosition()
    {
        Vector3 endPosition = Camera.ScreenToWorldPoint(Vector3.zero);
        endPosition.x = 0;
        endPosition.z = 0;
        return endPosition;
    }

    private float GetMovingTime()
    {
        float lengthOfOverLine = LinePosition - Camera.ScreenToWorldPoint(Vector3.zero).y;
        float percentageOfOverLine = lengthOfOverLine / (StartPosition.y - EndPosition.y);
        float timeOfOverLine = NoteSpeed * percentageOfOverLine;
        float movingTime = NoteSpeed + timeOfOverLine;
        return movingTime;
    }
	
	// Update is called once per frame
	void Update () {
        var diff = Time.timeSinceLevelLoad - StartTime;
        var rate = diff / MovingTime;
        transform.position = Vector3.Lerp(StartPosition, EndPosition, rate);
        if(transform.position.y == EndPosition.y)
        {
            Destroy(gameObject);
            //Instantiate(gameObject, Vector2.zero, Quaternion.identity);
        }
        Debug.Log(rate);
    }

    public void PressBtton()
    {
        //float nowTime = Time.timeSinceLevelLoad;
        //float diff = nowTime - JudgeTime;
        //if (Mathf.Abs(diff) <= JudgeRange)
        //{
        //    Instantiate(Effect, new Vector2(0, LinePosition), Quaternion.identity);
        //    Destroy(gameObject);
        //}
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
