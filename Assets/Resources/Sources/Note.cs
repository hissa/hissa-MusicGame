using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    public static GameObjectManager GameObjectManager;
    private static PlayingSettings PlayingSettings;

    public NoteData NoteData { get; set; }

    private static EffectGenerator EffectGenerator;
    private static Camera MainCamera;

    private float StartTime;

    private static float LinePosition;
    private float LanePosition;
    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private float MovingTime; // 移動し続ける時間

    private float JudgeRange;
    private float NoteSpeed;

    private bool IsDoneAnswerSound;

    private void Initialize()
    {
        // 変数がnullだった場合に、他のオブジェクトから取得する。
        GameObjectManager = GameObjectManager ?? GameObject.Find("GameObjectManager").GetComponent<GameObjectManager>();
        PlayingSettings = PlayingSettings ?? GameObjectManager.PlayingSettings.GetComponent<PlayingSettings>();
        MainCamera = MainCamera ?? GameObjectManager.MainCamera.GetComponent<Camera>();
        EffectGenerator = EffectGenerator ?? GameObjectManager.EffectGenerator.GetComponent<EffectGenerator>();
        LinePosition = LinePosition == 0 ? GameObjectManager.Line.transform.position.y : LinePosition;

        NoteSpeed = PlayingSettings.NoteSpeed;

        IsDoneAnswerSound = false;
        SetPosition();
    }

    private void SetPosition()
    {
        LanePosition = transform.parent.parent.position.x;
        StartTime = Time.timeSinceLevelLoad;
        StartPosition = GetStartPosition();
        EndPosition = GetEndPosition();
        MovingTime = GetMovingTime();
    }

    public static void StaticValueDestroy()
    {
        // static変数を初期化
    }

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    private Vector3 GetStartPosition()
    {
        Vector3 startPosition = MainCamera.ScreenToWorldPoint(new Vector3(0, MainCamera.pixelHeight));
        startPosition.z = -1;
        startPosition.x = LanePosition;
        return startPosition;
    }

    private Vector3 GetEndPosition()
    {
        Vector3 endPosition = MainCamera.ScreenToWorldPoint(Vector3.zero);
        endPosition.x = LanePosition;
        endPosition.z = -1;
        return endPosition;
    }

    private float GetMovingTime()
    {
        float lengthOfOverLine = LinePosition - MainCamera.ScreenToWorldPoint(Vector3.zero).y;
        float percentageOfOverLine = lengthOfOverLine / (StartPosition.y - EndPosition.y);
        float timeOfOverLine = NoteSpeed * percentageOfOverLine;
        float movingTime = NoteSpeed + timeOfOverLine;
        return movingTime;
    }

    // Update is called once per frame
    void Update()
    {
        var diff = Time.timeSinceLevelLoad - StartTime;
        var rate = diff / MovingTime;
        transform.position = Vector3.Lerp(StartPosition, EndPosition, rate);
        if (transform.position.y == EndPosition.y)
        {
            Destroy(gameObject);
        }
    }

    public void AnswerSound(AudioSource answerSound)
    {
        if (!IsDoneAnswerSound)
        {
            answerSound.Play();
            IsDoneAnswerSound = true;
        }
    }
}
