using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void Start()
    {
        Chrono.Instance.onChronoOverDel += OnChronoOver;
    }

    public void OnChronoOver()
    {
        // recupérer les donné des autre script
        Debug.Log("je doit recupéré les donnés");
    }
}
