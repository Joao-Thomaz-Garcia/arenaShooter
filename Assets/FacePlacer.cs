using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlacer : MonoBehaviour
{
    [SerializeField] Material[] faces;

    [SerializeField] MeshRenderer cube;


    private void Start()
    {
        PopulateFaces();
    }

    void PopulateFaces()
    {
        int _RNG = Random.Range(0, faces.Length);
        cube.material = faces[_RNG];
    }

}
