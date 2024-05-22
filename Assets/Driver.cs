using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (moveSpeed >= 4)
        {
            moveSpeed -= moveSpeed * 0.50f;
            Debug.Log("Speed Down!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp")
        {
            if (moveSpeed <= 5)
            {
                moveSpeed += moveSpeed * 0.75f;
                Debug.Log("Speed Up!");
            }
        }

        if (other.tag == "SlowDown")
        {
            if (moveSpeed >= 4)
            {
                moveSpeed -= moveSpeed * 0.50f;
                Debug.Log("Speed Down!");
            }
        }
    }
}
