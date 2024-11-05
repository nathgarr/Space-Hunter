using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chrono : MonoBehaviour
{
    public static Chrono Instance;
    [SerializeField] TextMeshProUGUI timerTexte;
    public float chrono = 60;
    public delegate void OnChronoOver();
    public OnChronoOver onChronoOverDel;
    public void Awake()
    {
        Instance = this;
        
    }
    public void Start()
    {
        StartCoroutine(ChronoCorout());
    }

    IEnumerator ChronoCorout()
    {
        while (chrono > 0)
        {
            ChronoWork();
            yield return null;
        }
        StartCoroutine(End());
    }
    public void ChronoWork()
    {
        chrono-= Time.deltaTime;
        timerTexte.text = chrono.ToString() + " S";
    }


    public IEnumerator End()
    {
        if (onChronoOverDel != null) 
        {
            onChronoOverDel();
        }
       yield return  new WaitForSeconds(3f);
        SceneManager.LoadScene(2);

    }
    //suprimer
}
