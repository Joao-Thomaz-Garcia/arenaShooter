using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    #region Singleton
    public static Globals Instance { get; private set; }

    void Awake()
    {
        Populate();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    public G_PrefabGetter prefabGetter { get; private set; }
    public G_EasyGet easyGet { get; private set; }
    public G_ProjectileModifiers projectileModifiers { get; private set; }

    void Populate()
    {
        prefabGetter = GetComponentInChildren<G_PrefabGetter>();
        easyGet = GetComponentInChildren<G_EasyGet>();
        projectileModifiers = GetComponentInChildren<G_ProjectileModifiers>();
    }




    private static bool applicationIsQuitting = false;
    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
