using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private GameState state;
    private void Start()
    {
        //  state = ScriptableObject.CreateInstance<GameState>();
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
        state.single = "LoadDemo";
        state.currentMode = GameState.GameMode.LocalMultiplayer;
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
