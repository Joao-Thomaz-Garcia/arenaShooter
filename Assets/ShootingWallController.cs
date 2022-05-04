using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWallController : MonoBehaviour
{
    [SerializeField] Material[] wallMaterials = new Material[4];

    [SerializeField] float timeToChance;
    float time;

    ProjectileType acceptedType = ProjectileType.Nulo;

    Transform[] wallTransforms = new Transform[4];

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            wallTransforms[i] = transform.GetChild(i);
        }
    }


    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= timeToChance)
        {
            int _wallIndex = Random.Range(0, wallTransforms.Length);
            int _materialIndex = Random.Range(0, wallMaterials.Length);
            print(_wallIndex + "   :   " + _materialIndex);
            time = 0;


            for (int i = 0; i < wallTransforms.Length; i++)
            {
                //wallTransforms[i].GetComponent<ShootingWallDamageTaker>().DeactivateWall();
                wallTransforms[i].gameObject.SetActive(false);

                if (wallTransforms[i].gameObject == wallTransforms[_wallIndex].gameObject)
                {
                    wallTransforms[i].gameObject.SetActive(true);
                    wallTransforms[_wallIndex].GetComponent<MeshRenderer>().material = wallMaterials[_materialIndex];

                    if (_materialIndex == 0) // FIRE
                    {
                        acceptedType = ProjectileType.FireStandard;
                    }
                    else if (_materialIndex == 1) // CORRUPTION
                    {
                        acceptedType = ProjectileType.CorruptionStandard;
                    }
                    else if (_materialIndex == 2) // GALAXY
                    {
                        acceptedType = ProjectileType.GalaxyStandard;
                    }
                    else if (_materialIndex == 3) // CARMESIM
                    {
                        acceptedType = ProjectileType.CarmesimStandard;
                    }
                }
            }

            








        }
    }






}
