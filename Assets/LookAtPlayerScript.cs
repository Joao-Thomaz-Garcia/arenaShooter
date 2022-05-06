using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LookAtPlayerScript : MonoBehaviour
{
    Transform player;
    Animator anim;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {

    }


    private void FixedUpdate()
    {
        transform.LookAt(player);
    }
}
