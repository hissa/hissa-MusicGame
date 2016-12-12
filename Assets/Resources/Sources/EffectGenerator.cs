using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour {

    public GameObject Particle;
    public GameObject Line;
    public float LinePosition;

	// Use this for initialization
	void Start () {
        LinePosition = Line.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowEffect()
    {
        Instantiate(Particle, new Vector2(0, LinePosition), Quaternion.identity);
    }
}
