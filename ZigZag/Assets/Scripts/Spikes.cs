using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public GameObject[] spikes;
    public float invokeRate;
    public GameObject currentSpike;
    public Animator anim;


	void Start ()
    {
        spikes = GameObject.FindGameObjectsWithTag("Spike");

        Color color = FindObjectOfType<GameScene>().backgroundColorDarken;
        foreach(GameObject spike in spikes)
        {
            spike.GetComponent<SpriteRenderer>().color = color;
        }
        InvokeRepeating("PickSpikeToPulse", 1.0f, invokeRate);
	}
	

	void Update () {
		
	}

    void PickSpikeToPulse()
    {
        int index;
        index = Random.Range(0, spikes.Length);
        currentSpike = spikes[index];
        anim = currentSpike.GetComponent<Animator>();
        anim.SetTrigger("Pulse");
    }
}
