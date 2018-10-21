using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
<<<<<<< HEAD
<<<<<<< HEAD
        Destroy(gameObject, 3);
    }
=======
	}
>>>>>>> Player Enemy Interaction
=======
        Destroy(gameObject, 3);
    }
>>>>>>> Shooting and DYing
}
