using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject point;
    public GameObject currentPoint;

	void Start ()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Points");
        SpawnPoint();
    }
	

	void Update ()
    {
		
	}

    public void SpawnPoint()
    {
        int index;
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];

        Instantiate(point, currentPoint.transform.position, currentPoint.transform.rotation);
    }
}
