using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
