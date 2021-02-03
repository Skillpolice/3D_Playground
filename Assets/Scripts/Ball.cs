using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    GameManager gameManager;


    public int Points;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void ResetPosition()
    {
        //TODO random position
        transform.position = new Vector3(0, 10, 0);
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Target"))
        {
            //TODO add points
            ResetPosition();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            //TODO remove points
            ResetPosition();
        }
    }




}
