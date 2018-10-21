using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    gameObject.GetComponent<Light>().color = gameObject.transform.parent.GetComponent<Renderer>().material.color;

	}
}
