using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    
    
    // Update is called once per frame
    void Update()
    {
        float rightMove = Input.GetAxisRaw("Horizontal");
        float forwardMove = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.forward * forwardMove;
        moveDirection += transform.right * rightMove;
        
        moveDirection.Normalize();
        
        moveDirection *= movementSpeed;

        transform.position += (moveDirection * Time.deltaTime);

    }
}
