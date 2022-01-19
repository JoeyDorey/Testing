using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    public Rigidbody item;


    private void Update()
    {
        
    }


    void OnMouseDown()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            float distance = hit.distance;
            if (distance < 3f)
            {
                this.item.useGravity = false;
                this.item.freezeRotation = true;
                this.item.isKinematic = true;
                this.transform.position = theDest.position;
                this.transform.parent = GameObject.Find("Destination").transform;
            }
            
        }
        
    }

     void OnMouseUp()
    {
        this.transform.parent = null;
        this.item.useGravity = true;
        this.item.freezeRotation = false;
        this.item.isKinematic = false;
    }

     
}
