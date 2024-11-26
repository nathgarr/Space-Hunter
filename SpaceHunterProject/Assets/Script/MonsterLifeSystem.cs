using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterLifeSystem : MonoBehaviour , IMonster
{
    public static MonsterLifeSystem instance;
    [SerializeField]
    TextMeshProUGUI m_TextMeshPro;
    public GameObject MonsterHead;
    public float monsterKilled;
    public int monsterMaxLife = 1;
    public int monsterCurrentLife;
    public float monsterValue=1;

   public void Awake()
    {
        instance = this;
    }

    public bool IsMonster {  get { return true; } }
    public void Start()
    {
        MonsterLife();
    }
    public void MonsterLife()
    {
        monsterCurrentLife = monsterMaxLife;
    }
    public void OnCollide(GameObject player)
    {
        monsterCurrentLife--;
        if (monsterCurrentLife < monsterMaxLife)
        {
            Destroy(gameObject);
            SoundController.instance.MonsterKillSound();
        }
        AddMonsterKill();
    }

    public void AddMonsterKill()
    {
        monsterKilled += monsterValue;
        m_TextMeshPro.text = " Monster Killed : "  + monsterKilled.ToString();
    }
}
