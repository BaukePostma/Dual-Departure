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
        state.Loader.LoadLevel(0);
    }

    public void ResumeGame()
    {
        this.GetComponent<UserInterface>().Resume();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
