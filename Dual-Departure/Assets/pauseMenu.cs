using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    private GameState state;

    private void Start()
    {
        state = GameState.Instance;
    }


    public void ResetLevel()
    {
        state.Loader.ResetLevel(2f);
    }
    public void ReturntoMainMenu()
    {

    }
    public void ResumeGame()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
