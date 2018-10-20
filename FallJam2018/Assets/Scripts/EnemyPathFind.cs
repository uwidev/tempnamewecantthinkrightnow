using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFind : MonoBehaviour {
    public GameObject follow;
    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(follow.transform.position, -follow.transform.up);
        RaycastHit towards;

        if (Physics.Raycast(ray, out towards))
        {
            agent.SetDestination(towards.point);
        }
	}
}
