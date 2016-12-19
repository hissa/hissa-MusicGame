using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBackEffected : MonoBehaviour {
    float TimeForHide;
    MeshRenderer MeshRenderer;

    void Awake()
    {
        TimeForHide = 0;
        MeshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

	// Use this for initialization
	void Start () {
        Hide();
    }
	
	// Update is called once per frame
	void Update () {
        TimeForHide -= Time.deltaTime;
        if(TimeForHide <= 0)
        {
            Hide();
        }
	}

    public void Show(float time)
    {
        TimeForHide = time;
        Show();
    }

    private void Show()
    {
        var nowPosition = transform.position;
        nowPosition.z = 0;
        transform.position = nowPosition;
    }

    private void Hide()
    {
        var nowPosition = transform.position;
        nowPosition.z = 5;
        transform.position = nowPosition;
    }
}
