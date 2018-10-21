using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class hung_EnemyPathFind : MonoBehaviour {

    public GameObject follow;
    public NavMeshAgent agent;
    public GameObject[] patrols;
    public float patrolSpeed;
    public float patrolWait = 5f;

    private int i = 0;
    private Vector3 patrolTowards;
    private Bounds destinationTrigger;
    public bool isWaiting = false;

    // Use this for initialization
    void Start () {
        patrolTowards = patrols[i].transform.position;
        destinationTrigger = new Bounds(patrolTowards, Vector3.one);
	}

    void setWaiting()
    {
    }



    IEnumerator wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1);

        isWaiting = false;
        if (i >= patrols.Length - 1)
        {
            i = 0;
        }
        else
        {
            ++i;
        }
        patrolTowards = patrols[i].transform.position;
        destinationTrigger.center = patrolTowards;
    }

    // Update is called once per frame
    void Update () {  

        if (gameObject.GetComponent<FieldOfView>().chasing)
        {
            agent.SetDestination(follow.transform.position);
        }
        else
        {
            if (!destinationTrigger.Contains(transform.position) && !isWaiting)
            {
                agent.SetDestination(patrolTowards);
            }
            else if (destinationTrigger.Contains(transform.position) && !isWaiting)
            {

                StartCoroutine(wait());

            }
        }
 

        //Ray ray = new Ray(follow.transform.position, -follow.transform.up);
        //RaycastHit towards;

        //if (Physics.Raycast(ray, out towards))
        //{
        //    agent.SetDestination(towards.point);
        //}
	}
}
