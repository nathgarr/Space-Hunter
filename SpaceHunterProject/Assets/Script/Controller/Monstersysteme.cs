using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstersysteme : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        IMonster Monster = other.GetComponent<IMonster>();
        if (Monster == null) return;
        if (!Monster.IsMonster) return;

        Monster.OnCollide(this.gameObject);
    }
}
