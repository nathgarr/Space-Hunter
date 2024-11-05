using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgWork : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        LifeSystem lifeSystem = other.GetComponent<LifeSystem>();
        if (lifeSystem == null) return;
        if (!lifeSystem.IsDamageable) return;

        lifeSystem.OnDmg(1);
    }
}
