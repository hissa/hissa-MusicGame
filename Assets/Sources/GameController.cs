using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject MainCamera;
    public GameObject NotePrefab;
    
    // Use this for initialization
	void Start () {
        CreateNote();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateNote()
    {
        var camera = MainCamera.GetComponent<Camera>();
        var point = camera.ScreenToWorldPoint(new Vector2(0, camera.pixelHeight));
        float topLine = point.y;
        Instantiate(NotePrefab, new Vector2(0, topLine), Quaternion.identity);
    }
}
