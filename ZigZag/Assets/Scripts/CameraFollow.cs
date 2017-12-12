using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 targetPos;
    public float followSpeed = 3f;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }
}
