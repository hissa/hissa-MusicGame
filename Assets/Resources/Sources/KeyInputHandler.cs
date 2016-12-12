using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputHandler : MonoBehaviour {
    private KeyCode HandleKey;
    //private bool WaitReleased = false;
	// Use this for initialization
	void Start () {
        HandleKey = KeyCode.Space;
	}
	
	// Update is called once per frame
	void Update () {
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
