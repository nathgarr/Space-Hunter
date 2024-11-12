using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chrono : MonoBehaviour
{
    [SerializeField]
    Image gaugeValue;
    float timeRate { get { return remainingTime / maxTime; } }
    public static Chrono Instance;
    [SerializeField] TextMeshProUGUI timerTexte;
    public float remainingTime = 60;
    public float maxTime =45;
    public delegate void OnChronoOver();
    public OnChronoOver onChronoOverDel;
    public void Awake()
    {
        Instance = this;
        
    }
    public void Start()
    {
        remainingTime = maxTime;
        StartCoroutine(ChronoCorout());
    }

    IEnumerator ChronoCorout()
    {
        while (remainingTime > 0)
        {
            ChronoWork();
            yield return null;
        }
        StartCoroutine(End());
    }
    public void ChronoWork()
    {
        remainingTime-= Time.deltaTime;
        timerTexte.text = remainingTime.ToString() + " S";
        gaugeValue.fillAmount = timeRate;
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
    /// <summary>
    /// value between 0-100
    /// </summary>
    /// <param name="maxTimePercentage"></param>
    public void AddTime(float maxTimePercentage)
    {
        float timeToAdd = (maxTimePercentage / 100f) * maxTime;
        remainingTime += timeToAdd;
        if (remainingTime > maxTime)
        {
            remainingTime = maxTime;
        }
    }
}
