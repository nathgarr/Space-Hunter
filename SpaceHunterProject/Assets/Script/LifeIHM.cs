using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIHM : MonoBehaviour
{
    [SerializeField] LifeSystem lifeSystem;
    [SerializeField] GameObject heartPrefab;
    List<GameObject> lifeList = new List<GameObject>();

    public void Awake()
    {
        lifeSystem.OnDamageEvent = UpdateLife;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateLife();
    }
    public void UpdateLife() 
    {
        // Vérifi que nous avaon bien tous les coeur pour lancer la partie
        if (lifeList.Count < lifeSystem.maxLife) 
        { 
            int missingLife = lifeSystem.maxLife - lifeList.Count;
            for (int i = 0; i < missingLife; i++) 
            {
                lifeList.Add(Instantiate(heartPrefab, this.transform));  
            }
        }

        foreach (GameObject life in lifeList) { life.SetActive(false); }
        for (int i = 0; i < lifeSystem.currentLife; i++) { lifeList[i].SetActive(true); }

    }
}
