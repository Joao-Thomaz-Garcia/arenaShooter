using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField] float dashForce;
    Rigidbody rb;

    Camera cam;
    bool b_canDash = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(b_canDash)
                StartCoroutine(Dash());
        }
    }


    IEnumerator Dash()
    {
        b_canDash = false;
        rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        yield return new WaitForSeconds(2);
        b_canDash = true;
    }

}
