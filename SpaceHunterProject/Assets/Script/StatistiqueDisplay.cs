using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatistiqueDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI mineralCount, monsterKilled, elapsedTime;
    public void Start()
    {
        if (PersistentData.Instance == null) return;
        elapsedTime.text = PersistentData.Instance.time.ToString();
    }
}
