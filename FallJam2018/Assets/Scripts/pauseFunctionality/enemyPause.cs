using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPause : MonoBehaviour {

	public GameObject[] enemies; //array of enemies
	public int enemyNum; //number of enemies in array

	/*
	Stops movement of Enemy GameObjects
	disabling and re-enabling scripts */
	public void pauseEnemies()
	{
		for(int i = 0; i < enemyNum; i++)
		{
		}
	}
}
