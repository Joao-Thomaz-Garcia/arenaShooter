using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_EasyGet : MonoBehaviour
{
    [Header("Element Materials")]
    [SerializeField] Material greyElement;
    [SerializeField] Material redElement;
    [SerializeField] Material greenElement;

    [Header("Element Materials")]
    [SerializeField] Material fireCombo;
    [SerializeField] Material corruptionCombo;
    [SerializeField] Material galaxyCombo;
    [SerializeField] Material carmesimCombo;




    public Material GetElementMaterial(float _elementIndex)
    {
        Material _matToReturn = null;

        switch (_elementIndex)
        {
            case 0:
                _matToReturn = greyElement;
                break;

            case 1:
                _matToReturn = redElement;
                break;

            case 2:
                _matToReturn = greenElement;
                break;
        }

        return _matToReturn;
    }
    public Material GetComboMaterial(float _comboIndex)
    {
        Material _matToReturn = null;

        switch (_comboIndex)
        {
            case 1:
                _matToReturn = fireCombo;
                break;

            case 2:
                _matToReturn = corruptionCombo;
                break;

            case 3:
                _matToReturn = galaxyCombo;
                break;

            case 4:
                _matToReturn = carmesimCombo;
                break;
        }

        return _matToReturn;
    }

}
