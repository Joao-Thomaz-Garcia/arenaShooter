using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRaycast : MonoBehaviour
{


    private void Awake()
    {

    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.transform.GetComponent<InteractableObject>())
            {
                InteractableObject _interactableObject = hit.transform.GetComponent<InteractableObject>();
                _interactableObject.DoInteraction();
            }
        }
    }





}








