using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;
    public float time;
    public float mineral;
    public float kill;
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
        mineral = MineralGain.Instance.totalMineralGet;
        kill = MonsterLifeSystem.instance.monsterKilled;
        // recupérer les donné des autre script
        Debug.Log("je doit recupéré les donnés");
    }
}
