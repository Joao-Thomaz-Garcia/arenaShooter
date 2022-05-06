using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] UpgradeTyoe upgradeType;
    [SerializeField] float timeToInteract = 1;

    bool b_canInteract = true;
    bool b_isTweening = false;

    TextMeshPro text;
    Animator anim;


    private void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
        anim = GetComponentInParent<Animator>();
    }
    private IEnumerator Start()
    {
        PopulateText();

        float _randomStartTime = Random.Range(0f, 2f);
        yield return new WaitForSeconds(_randomStartTime);
        anim.Play("UpgradeObject_Anim");
    }

    public void StartTweeningInteraction(ProjectileType _projectileType)
    {
        if (!b_isTweening)
        {
            b_isTweening = true;

            transform.DOShakeScale(timeToInteract, 0.2f, 10, 90, false).OnComplete(() => 
            {
                if (b_isTweening)
                {
                    StartCoroutine(Interact(_projectileType));
                    StopTweeningInteraction();
                }
            });
        }
    }
    public void StopTweeningInteraction()
    {
        b_isTweening = false;
        transform.DOComplete();
    }
    public IEnumerator Interact (ProjectileType _projecType)
    {
        if (!b_canInteract)
            yield return null;

        StopTweeningInteraction();
        b_canInteract = false;
        AddPlayerUpgrade(_projecType);

        yield return new WaitForEndOfFrame();
        Destroy(transform.parent.gameObject);
    }


    void AddPlayerUpgrade(ProjectileType _projecType)
    {
        switch (upgradeType)
        {
            case UpgradeTyoe.Damage:
                Globals.Instance.projectileModifiers.AddDamageUpgrades(_projecType, 5f);
                break;
            case UpgradeTyoe.MoveSpeed:
                Globals.Instance.projectileModifiers.AddMoveSpeedUpgrades(_projecType, 5f);
                break;
            case UpgradeTyoe.FireRate:
                Globals.Instance.projectileModifiers.AddFireRateUpgrades(_projecType, 0.2f);
                break;


            case UpgradeTyoe.FireExplosion:
                Globals.Instance.projectileModifiers.GetFireModifiers().AddExplosionDamage(2f);
                break;
            case UpgradeTyoe.CorruptionSphereRadious:
                Globals.Instance.projectileModifiers.GetCorruptionModifiers().AddSphereRadious(2);
                break;
            case UpgradeTyoe.GalaxyJumps:
                Globals.Instance.projectileModifiers.GetGalaxyModifiers().AddJumps(2);
                break;
            case UpgradeTyoe.CarmesimWeakness:
                Globals.Instance.projectileModifiers.GetCarmesimModifiers().AddWeakness(5f);
                break;
            default:
                break;
        }
    }



    void PopulateText()
    {
        string _adicionalString = "";
        switch (upgradeType)
        {
            case UpgradeTyoe.Damage:
                _adicionalString = 5.ToString();
                break;
            case UpgradeTyoe.MoveSpeed:
                _adicionalString = 5.ToString();
                break;
            case UpgradeTyoe.FireRate:
                _adicionalString = 0.2f.ToString();
                break;


            case UpgradeTyoe.FireExplosion:
                _adicionalString = 2.ToString();
                break;
            case UpgradeTyoe.CorruptionSphereRadious:
                _adicionalString = 2.ToString();
                break;
            case UpgradeTyoe.GalaxyJumps:
                _adicionalString = 2.ToString();
                break;
            case UpgradeTyoe.CarmesimWeakness:
                _adicionalString = 5.ToString();
                break;

            default:
                break;
        }

        text.text += ": " + "<color=green>" + _adicionalString + "</color>";
    }

    public bool GetIsTweening()
    {
        return b_isTweening;
    }
}
