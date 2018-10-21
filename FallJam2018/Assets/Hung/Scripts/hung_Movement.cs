using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hung_Movement : MonoBehaviour {

    public float moveSpeed;
    public GameManager gameManager;
    public GameObject enemyDeathParticle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            gameManager.RestartGame();
        }
        if (other.gameObject.tag == "Enemy")
        {
            KillEnemey(other.transform.parent.gameObject);
        }
    }

    private void KillEnemey(GameObject enemy)
    {
        Instantiate(enemyDeathParticle, enemy.transform.position, enemy.transform.rotation);
        Destroy(enemy);
    }
}
