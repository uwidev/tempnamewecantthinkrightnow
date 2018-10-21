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

    public float dashCooldown;
    private bool dashOnCooldown = false;

    public float bobStrength;
    public float bobRate;
    private float yMove;

    private Vector3 moving;
    public CharacterController controller;
    private float horiz;
    private float vert;
    private bool isMoving;

    private float moveGravity;
    public float gravity;

    //public Rigidbody selfRB;

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

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        dashOnCooldown = false;
    }

    IEnumerator Dash()
    {
        StartCoroutine(Cooldown());
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
        moveGravity = -gravity * Time.deltaTime * Time.deltaTime;
        if (Input.GetButtonDown("Dash") && !dashOnCooldown)
        {
            dashing = true;
            dashOnCooldown = true;
            StartCoroutine("Dash");
        }
        else if (!dashing && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            isMoving = true;
            //yMove = Mathf.Sin(Time.time * bobRate) * bobStrength;
            moving = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        }
        else if (!dashing)
        {
            moving = Vector3.zero;
        }

        //print(moving.y);
        //moving.y -= moveGravity;
        //print(moving.y);
        moving.y -= gravity * Time.deltaTime;
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
