using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualShoot : MonoBehaviour
{
    [SerializeField] GameObject atualProjectile;

    [SerializeField] Transform fireSpot;



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(atualProjectile, fireSpot.position, fireSpot.rotation);
        }
    }



}
