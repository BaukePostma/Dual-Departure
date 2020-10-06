using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private GameState state;
    public LevelLoader levelLoader;

    private void Start()
    {
        state = GameState.Instance;
    }
    
    public void LoadSinglePlayerLevel()
    {
        state.currentMode = GameState.GameMode.Singleplayer;
        SceneManager.LoadScene("testingEnviroment");
    }
    public void LoadMultiPlayerLevel()
    {
        state.currentMode = GameState.GameMode.LocalMultiplayer;
        SceneManager.LoadScene("testingEnviroment");
    }
    public void LoadDemoLevel()
    {
        state.currentMode = GameState.GameMode.LocalMultiplayer;
        levelLoader.LoadLevel("1_RescueRobot");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
