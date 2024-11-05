using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollectable : MonoBehaviour, ICollectable
{

    public bool isCollectable { get { return true; } }

    public void OnCollected(GameObject collector)
    {
        LifeSystem lifeSystem = collector.GetComponent<LifeSystem>();
        if (LifeSystem.instance.currentLife == LifeSystem.instance.maxLife) 
        {
            lifeSystem.OnDmg(0);
            Destroy(gameObject);
        }
        else
        {
            lifeSystem.OnDmg(-1);
            Destroy(gameObject);
        }
    }
}
