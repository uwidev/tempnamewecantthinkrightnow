using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float maxAngle = 70;
    public float rotationSpeed = 0.3f;
    public float angleOffset = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameObject.GetComponent<FieldOfView>().chasing && gameObject.GetComponent<hung_EnemyPathFind>().isWaiting)
        {
            float angle = (Mathf.Sin(Time.time * rotationSpeed) * maxAngle) + angleOffset; //tweak this to change frequency
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
    }
}
