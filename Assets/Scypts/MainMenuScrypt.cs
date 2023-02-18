using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScrypt : MonoBehaviour
{
    MenuManagerNextLevel mmnl;
    void Start()
    {
        gameObject.SetActive(true);
    }
    public void PlayGame()
    {
        gameObject.SetActive(false);
    }
    public void SetExit()
    {
        Debug.Log("Ceao");
        Application.Quit();
    }
}
