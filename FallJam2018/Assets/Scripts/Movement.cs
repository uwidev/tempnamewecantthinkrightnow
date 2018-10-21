using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedMod;
    public GameManager gameManager;
    public GameObject enemyDeathParticle;
    public float dashSpeed;
    private float dashSpeedMod;
    public float dashTime;
    private bool dashing = false;
    private Vector3 moving;
    //public Rigidbody selfRB;
    public CharacterController controller;
    private float horiz;
    private float vert;

    // Use this for initialization
    void Start () {
        dashSpeedMod = dashSpeed;
        //selfRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
	}

    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(dashTime);
        dashing = false;
    }

    IEnumerator Dash()
    {
        moveSpeedMod = moveSpeed * dashSpeedMod;
        StartCoroutine(DashTimer());
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        while (dashing)
        {
            moving = new Vector3(horiz * moveSpeedMod, 0f, vert * moveSpeedMod);
            //moveSpeedMod /= 1.2f;
            yield return null;
        }
        yield return null;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Dash"))
        {
            dashing = true;
            StartCoroutine(Dash());
        }
        else if (!dashing)
        {
            moving = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
            //moving = Vector3.zero;
        }
        //selfRB.Move = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);

        
        controller.Move(moving * Time.deltaTime);    
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
