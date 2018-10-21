using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChange : MonoBehaviour {

	//used to move form scene to scene, using a string of scene name as an argument
	public void newScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
