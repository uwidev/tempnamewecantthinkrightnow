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
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Player Enemy Interaction
=======
>>>>>>> 08639421c7fbe6345df2aba31c2178bd978b9739
        Destroy(gameObject, 3);
    }
=======
	}
>>>>>>> Player Enemy Interaction
<<<<<<< HEAD
<<<<<<< HEAD
=======
        Destroy(gameObject, 3);
    }
>>>>>>> Shooting and DYing
=======
>>>>>>> Player Enemy Interaction
=======
=======
        Destroy(gameObject, 3);
    }
>>>>>>> 3a212a7dce3d6edde9bdd79514aedafd6620b427
>>>>>>> 08639421c7fbe6345df2aba31c2178bd978b9739
}
