using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem instance;
    public int maxLife;
    public int currentLife;

    IDamageable iDamageable;

    public System.Action OnDamageEvent;

    public bool IsAlive { get { return currentLife > 0; } }

    private void Awake()
    {
        instance = this;
        currentLife = maxLife;
        iDamageable = GetComponent<IDamageable>();
        if (iDamageable == null) { Debug.LogError("L'interface idamageable n'a pas été trouvé sur le gameobject " + gameObject.name); }
    }
    public bool IsDamageable { get { return iDamageable.IsDamageable; } }

    public void OnDmg(int damage)
    {
        currentLife -= damage;
        if (currentLife < 0)
        {currentLife = 0; }
        if (!IsAlive)
        {
            Debug.Log("je sui mort");
        } 
        else 
        {
            iDamageable.OnDmg(damage);
        }
        if (currentLife == 0) 
        { 

            Chrono.Instance.StartCoroutine(Chrono.Instance.End()); 
        }
        Debug.Log(OnDamageEvent);
        if (OnDamageEvent != null) { OnDamageEvent(); }
        
    }
  
}
