using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    GameManager gameManager;


    public int points;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void ResetPosition()
    {
        //TODO random position
        float randomX = Random.Range(-5, 10);
        float randomY = Random.Range(1, 10);
        float randomZ = Random.Range(-5, 10);

        transform.position = new Vector3(randomX, randomY, randomZ);
        rb.velocity = Vector3.zero;

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Target"))
        {
            //TODO add points
            gameManager.AddPoints(points);
            ResetPosition();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            //TODO remove points
            gameManager.AddPoints(-points);
            ResetPosition();
        }
    }




}
