using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    bool IsDamageable{ get; }
    void OnDmg(int damage);
}
