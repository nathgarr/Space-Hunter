using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;
    public float time;
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
        time = Chrono.Instance.elapsedTime;
        // recup�rer les donn� des autre script
        Debug.Log("je doit recup�r� les donn�s");
    }
}
