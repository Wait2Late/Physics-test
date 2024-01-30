using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingDemo : MonoBehaviour
{

    [SerializeField] private float rayDistance; 
    private GameObject lastObjectHit;
    private bool isLookingAtSomething;

    [SerializeField] private Transform anchorPoint;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void FixedUpdate()
    {
        Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.forward * rayDistance, out RaycastHit hitInfo))
        {
            if (lastObjectHit == hitInfo.transform.gameObject)
                return;

            if (lastObjectHit != null)
            {
                lastObjectHit.GetComponent<MeshRenderer>().material.color = Color.white;
            }
            
            isLookingAtSomething = true;
            lastObjectHit = hitInfo.transform.gameObject;
            
            Debug.Log(hitInfo.transform.gameObject.name);

            lastObjectHit.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            if (lastObjectHit != null)
            {
                lastObjectHit.GetComponent<MeshRenderer>().material.color = Color.white;
            }

            lastObjectHit = null;
            isLookingAtSomething = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool isHoldingItem;
    private GameObject heldItem;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isLookingAtSomething)
        {
            if (isHoldingItem == true)
            {
                heldItem = null;
                isHoldingItem = false;
                return;
            }
            else
            {
                heldItem = lastObjectHit;
                isHoldingItem = true;
            }
            lastObjectHit.transform.position = anchorPoint.position;
        }

        if (isHoldingItem == true)
        {
            heldItem.transform.position = anchorPoint.position;
        }
    }
}
