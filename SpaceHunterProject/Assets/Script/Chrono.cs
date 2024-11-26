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
    public float maxTime = 45;
    public float elapsedTime { get { return maxTime - remainingTime; } }
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
        timerTexte.text = SecondsToMinSec(remainingTime);
        gaugeValue.fillAmount = timeRate;
    }


    public IEnumerator End()
    {
        if (onChronoOverDel != null) 
        {
            onChronoOverDel();
        }
       yield return  new WaitForSeconds(3f);

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
    public static string SecondsToMinSec(float _secf)
    {
        int _sec = (int) _secf;
        int _min = (_sec / 60);

        int _secLeft = _sec - (_min * 60);
        string _secLeftStr = (_secLeft < 10) ? "0" + _secLeft.ToString() : _secLeft.ToString();

        if (_min > 0) return _min + " min " + _secLeftStr;
        else return _secLeftStr + " sec";
    }
}
