using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject follow;
    public float dampening = 0.3f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.one;
    private Vector3 up = new Vector3(0f, 0f, 1f);

	// Use this for initialization
	void Start () {
        offset = transform.position - follow.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 finalPosition = follow.transform.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, finalPosition, ref velocity, dampening);
        transform.position = smoothedPosition;

        //transform.LookAt(follow.transform, up);
	}
}
