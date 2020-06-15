using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   
    public void LoadSinglePlayerLevel()
    {
        SceneManager.LoadScene("testingEnviroment");
    }
    public void LoadMultiPlayerLevel()
    {
        SceneManager.LoadScene("testingEnviroment");
    }
    public void LoadDemoLevel()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
