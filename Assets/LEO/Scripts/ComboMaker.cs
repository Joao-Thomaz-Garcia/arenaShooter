using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMaker : MonoBehaviour
{
    [SerializeField] Transform elementSlot1;
    [SerializeField] Transform elementSlot2;
    [SerializeField] Transform elementSlot3;

    [SerializeField] Vector3 atualComboVector = new Vector3();

    [Header("Combo Recipes")]
    [SerializeField] Vector3 fireRecipe; // 1
    [SerializeField] Vector3 corruptionRecipe; // 2
    [SerializeField] Vector3 galaxyRecipe; // 3
    [SerializeField] Vector3 carmesimRecipe; // 4


    ProjectileType atualProjectile = ProjectileType.Nulo;
    Transform fireSpot;


    private void Awake()
    {
        fireSpot = transform.Find("Camera").Find("GUN").Find("FireSpot");
    }
    private void Update()
    {
        ComboBlend();

        if (Input.GetMouseButtonDown(2)) // MEIO
        {
            CreateCombo();
        }
    }


    void ComboBlend()
    {
        int elementIndex = 0;

        if (Input.GetMouseButtonDown(0)) // ESQUERDO
        {
            elementIndex = 1;
        }
        if (Input.GetMouseButtonDown(1)) // DIREITO
        {
            elementIndex = 2;
        }

        if (elementIndex <= 0 || elementIndex >= 3)
            return;

        atualComboVector = new Vector3(atualComboVector.y, atualComboVector.z, elementIndex);

        elementSlot1.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetElementMaterial(atualComboVector.x);
        elementSlot2.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetElementMaterial(atualComboVector.y);
        elementSlot3.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetElementMaterial(atualComboVector.z);
    }
    void CreateCombo()
    {
        if (atualComboVector == fireRecipe) // FIRE
        {
            fireSpot.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetComboMaterial(1);
            atualProjectile = ProjectileType.FireStandard;
        }
        else if (atualComboVector == corruptionRecipe) // CORRUPTION
        {
            fireSpot.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetComboMaterial(2);
            atualProjectile = ProjectileType.CorruptionStandard;
        }
        else if (atualComboVector == galaxyRecipe) // GALAXIA
        {
            fireSpot.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetComboMaterial(3);
            atualProjectile = ProjectileType.GalaxyStandard;
        }
        else if (atualComboVector == carmesimRecipe) // CARMESIM
        {
            fireSpot.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetComboMaterial(4);
            atualProjectile = ProjectileType.CarmesimStandard;
        }

        ResetCombo();
    }
    void ResetCombo()
    {
        atualComboVector = Vector3.zero;

        elementSlot1.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetElementMaterial(0);
        elementSlot2.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetElementMaterial(0);
        elementSlot3.GetComponent<MeshRenderer>().material = Globals.Instance.easyGet.GetElementMaterial(0);
    }



    public ProjectileType GetProjectile()
    {
        return atualProjectile;
    }

}