using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterLifeSystem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_TextMeshPro;
    public float monsterKilled;
    public int monsterMaxLife = 1;
    public int monsterCurrentLife;
    public float monsterValue=1;

    public void Start()
    {
        MonsterLife();
    }
    public void MonsterLife()
    {
        monsterCurrentLife = monsterMaxLife;

    }
    private void OnTriggerEnter(Collider other)
    {
        monsterKilled++;
        monsterCurrentLife--;
        if (monsterCurrentLife < monsterMaxLife)
        {
            Destroy(gameObject);
        }
        AddMonsterKill(monsterValue);
    }
    public void AddMonsterKill(float monsterValue)
    {
        monsterKilled += monsterValue;
        m_TextMeshPro.text = " Monster Killed : "  + monsterKilled.ToString();
    }
}
