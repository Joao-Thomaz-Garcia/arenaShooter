using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRaycast : MonoBehaviour
{
    InteractableObject atualHitedObject = null;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.transform.GetComponent<InteractableObject>())
            {
                InteractableObject _interactableObject = hit.transform.GetComponent<InteractableObject>();

                if (atualHitedObject == _interactableObject)
                {
                    ProjectileType _projecType = GetComponent<Automatic_Shoot>().GetProjectileSelected();
                    _interactableObject.StartTweeningInteraction(_projecType);
                }
                else
                {
                    if(atualHitedObject != null)
                        atualHitedObject.StopTweeningInteraction();
                    
                    atualHitedObject = _interactableObject;
                }
            }
            else
            {
                if (atualHitedObject != null)
                    atualHitedObject.StopTweeningInteraction();

                atualHitedObject = null;
            }
        }
    }


}








