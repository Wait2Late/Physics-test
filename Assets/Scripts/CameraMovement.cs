using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float CameraTurnSpeed;
    [SerializeField] private Transform playerTransform;
    
    
    
    // Update is called once per frame
    void Update()
    {
        float rightMove = Input.GetAxisRaw("Mouse X");
        float upAndDown = Input.GetAxisRaw("Mouse Y");

        transform.eulerAngles += new Vector3(upAndDown, 0);
        
        

    }
}
