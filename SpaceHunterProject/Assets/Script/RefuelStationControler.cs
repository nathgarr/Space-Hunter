using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelStationControler : MonoBehaviour
{
    [SerializeField]
    float refuelAmount = 20f;
    [SerializeField]
    Collider trigger;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Chrono.Instance.AddTime(refuelAmount);
        trigger.enabled = false;
    }
}
