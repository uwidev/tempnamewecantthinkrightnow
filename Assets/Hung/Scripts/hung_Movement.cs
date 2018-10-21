using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hung_Movement : MonoBehaviour {

    public float moveSpeed;

    public float dashCoolDown = 3f;
    public float currentDashCD = 3f;
    public float dashDuration = 0.3f;
    public bool dashable = true;

    public GameManager gameManager;
    public GameObject enemyDeathParticle;

    
    public void dashCountDown()
    {
        if(currentDashCD > 0)
        {
            dashable = false;
            currentDashCD -= 1 * Time.deltaTime;
        }
        else
        {
            dashable = true;
        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        dashCountDown();
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        if (Input.GetKeyDown("space"))
        {
            if (dashable)
            {
                StartCoroutine("Dash");
                currentDashCD = dashCoolDown;
            }
        }
    }

    public IEnumerator Dash()
    {
        moveSpeed = moveSpeed * 5;
        yield return new WaitForSeconds(dashDuration);
        moveSpeed = moveSpeed / 5;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet" || other.gameObject.tag == "Enemy")
        {
            gameManager.RestartGame();
        }
        else if (other.gameObject.tag == "Target")
        {
            KillEnemey(other.transform.gameObject);
        }
    }

    private void KillEnemey(GameObject enemy)
    {
        Instantiate(enemyDeathParticle, enemy.transform.position, enemy.transform.rotation);
        Destroy(enemy);
    }
}
