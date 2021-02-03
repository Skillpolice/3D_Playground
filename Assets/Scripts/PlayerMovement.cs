using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Header("Movement")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private int jumpForce = 10;

    [Header("Pushing Obj")]
    [SerializeField] GameObject objCenter;
    [SerializeField] private LayerMask objMask;
    [SerializeField] private float objRadius = 1f;
    [SerializeField] private float maxPushForce = 1f;
    [SerializeField] private float pushHeight = 15f;
    // [SerializeField] private float pushForceStep = 15f;

    float pushForce;
    bool isGoingUp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce); //Добавляем силу прыжка вверх
        }

        if (Input.GetMouseButtonDown(0))
        {
            pushForce = 0;
            isGoingUp = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (isGoingUp)
            {
                pushForce += maxPushForce * Time.deltaTime;
                if (pushForce >= maxPushForce)
                {
                    isGoingUp = false;
                }
            }
            else
            {
                pushForce -= maxPushForce * Time.deltaTime;
                if (pushForce <= 0)
                {
                    isGoingUp = true;
                }
            }

            print("pushForce: " + pushForce);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Collider[] colliders = Physics.OverlapSphere(objCenter.transform.position, objRadius, objMask); //Ищем обьекты в этом радиусе
            foreach (Collider col in colliders)
            {
                Rigidbody colRb = col.GetComponent<Rigidbody>();

                Vector3 forceBallDirection = transform.forward;
                forceBallDirection.y = pushHeight;
                colRb.AddForce(forceBallDirection.normalized * pushForce, ForceMode.Impulse);
            }
        }
    }


    void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        //rb.velocity = transform.forward * inputVertical * speed; 
        rb.AddForce(transform.forward * inputVertical * speed);

        transform.RotateAround(transform.position, Vector3.up, inputHorizontal * rotationSpeed); //нарасчивание скорости + вращение по игровой оси vector3.up
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(objCenter.transform.position, objRadius);
    }
}
