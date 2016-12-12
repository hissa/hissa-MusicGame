using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
    public float StartTime;
    public float DestroyTime;
    public float KeepTime;
	// Use this for initialization
	void Start () {
        KeepTime = 5;
        StartTime = Time.timeSinceLevelLoad;
        DestroyTime = StartTime + 5;
	}
	
	// Update is called once per frame
	void Update () {
        float nowTime = Time.timeSinceLevelLoad;
        if(DestroyTime < nowTime)
        {
            Destroy(gameObject);
        }
	}
}
