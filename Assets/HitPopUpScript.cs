using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitPopUpScript : MonoBehaviour
{
    TextMeshPro damage_Text;
    Transform player;
    Animator anim;

    private void Awake()
    {
        damage_Text = GetComponentInChildren<TextMeshPro>();
        player = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }


    private void FixedUpdate()
    {
        transform.LookAt(player);
    }

    public void SetDamageText(float _damage)
    {
        _damage = (int)_damage;
        damage_Text.text = _damage.ToString();

        int _rng = Random.Range(1, 6);
        anim.SetInteger("RNG", _rng);
    }

    public void AnimationEnd()
    {
        Destroy(gameObject);
    }


}
