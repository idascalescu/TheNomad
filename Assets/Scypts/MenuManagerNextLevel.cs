using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerNextLevel : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void NextSceneLoader()
    {
        int cURscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cURscene + 1);
    }
    public void SetExit()
    {
        Debug.Log("Ceao");
        Application.Quit();
    }
    public void PreviousSceneLoader()
    {
        int previousScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(previousScene - 1);
    }
}
