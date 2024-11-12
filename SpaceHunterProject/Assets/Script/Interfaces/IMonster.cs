using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster 
{
    public bool IsMonster { get; }

    public void OnCollide(GameObject player);
}
