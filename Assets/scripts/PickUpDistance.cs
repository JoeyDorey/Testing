using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDistance : MonoBehaviour
{
    

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            
        }
    }


}
