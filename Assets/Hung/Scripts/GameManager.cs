using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Vector3 playerStartPoint;
    public hung_Movement player;
    public GameObject deathParticle;

	// Use this for initialization
	void Start () {
        playerStartPoint = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        Instantiate(deathParticle, player.gameObject.transform.position, player.gameObject.transform.rotation);
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(4);
        player.transform.position = playerStartPoint;
        player.gameObject.SetActive(true);
    }
}
