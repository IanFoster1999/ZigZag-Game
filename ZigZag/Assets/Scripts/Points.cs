using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    public SpawnPoints sp;
	
	void Start ()
    {
        sp = FindObjectOfType<SpawnPoints>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sp.SpawnPoint();
            Destroy(gameObject);
        }
    }
}
