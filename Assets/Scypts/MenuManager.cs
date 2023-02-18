using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
   
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetExit()
    {
        Debug.Log("Ceao");
        Application.Quit();
    }
}
