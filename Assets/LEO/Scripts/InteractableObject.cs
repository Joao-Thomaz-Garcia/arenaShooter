using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] InteractableObjectsType interactableObjectsType = InteractableObjectsType.Nulo;



    private void Awake()
    {
        if (GetComponent<UpgradeMachineScript>())
        {
            interactableObjectsType = InteractableObjectsType.UpgradeMachine;
        }
    }

    public void DoInteraction()
    {
        switch (interactableObjectsType)
        {
            case InteractableObjectsType.UpgradeMachine:
                UpgradeMachineScript upgradeMachineScript = GetComponent<UpgradeMachineScript>();
                upgradeMachineScript.DoUpgrade();
                break;

            default:
                break;
        }
    }



}
