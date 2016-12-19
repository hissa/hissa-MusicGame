using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour {

    public GameObject Particle;
    public GameObject Line;
    public GameObjectManager GameObjectManager;
    public float LinePosition;
    //public float[] LanePosition = new float[5];

	// Use this for initialization
	void Start () {
        LinePosition = Line.transform.position.y;
        //for(var i = 0; i <= LanePosition.Length - 1; i++)
        //{
        //    LanePosition[i] = GameObjectManager.Lanes[i].transform.parent.position.x;
        //}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowEffect()
    {
        Instantiate(Particle, new Vector2(0, LinePosition), Quaternion.identity);
    }

    public void ShowEffect(float lanePosition)
    {
        Instantiate(Particle, new Vector2(lanePosition, LinePosition), Quaternion.identity);
    }
}
