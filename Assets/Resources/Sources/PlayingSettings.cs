using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 主に曲ごとに変わる設定を保存
public class PlayingSettings : MonoBehaviour {

    // 出現から判定線まで到達するまでの時間
    public float NoteSpeed;
    // 判定の幅
    public float JudgeRange;
    // アンサー音を使用する
    public bool IsUseAnswerSound;

	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Initialize()
    {
        NoteSpeed = 0.8f;
        JudgeRange = 0.065f;
        IsUseAnswerSound = false;
    }
}
