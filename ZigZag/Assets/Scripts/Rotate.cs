using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float speed = 2f;

    public Transform leftCircle, rightCircle;
    private Transform target;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    public bool counterClockwise = true;

    private void Start()
    {
        target = leftCircle;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            counterClockwise = !counterClockwise;
        }
        transform.RotateAround(target.position, zAxis, speed);

        if (counterClockwise)
        {
            target = leftCircle;
            speed = 2f;
        }
        else
        {
            target = rightCircle;
            speed = -2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            gameObject.SetActive(false);
            GameManager.Instance.gameOver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            gameObject.SetActive(false);
            GameManager.Instance.gameOver = true;
        }
    }
}
