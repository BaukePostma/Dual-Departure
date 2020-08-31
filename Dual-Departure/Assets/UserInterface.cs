using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    GameState state;
    //public PlayerController activePlayer;
    public Image PlayerImage;

    public Image  ActiveToolImage;
    public TextMeshProUGUI ActiveToolText;
    public TextMeshProUGUI ActiveToolUseButton;

    public GameObject PauseMenu;
    public static bool isPaused;
    void Start()
    {
        state = GameState.Instance;
        if (state.isCurrentPlayerHuman)
        {
            SetTools(true);
        }
        else
        {
            SetTools(false);
        }
       
    }
    void SetTools(bool isHuman)
    {
        ActiveTool activeTool;
        BaseTool[] toolList;

        if (isHuman)
        {
            activeTool = state.getHumanActiveTool();
            toolList = state.getHumanTools();
            PlayerImage.sprite = Resources.Load<Sprite>("Images/HumanFace");
         
        }
        else
        {
            activeTool = state.getRobotActiveTool();
            toolList = state.getRobotTools();
            PlayerImage.sprite = Resources.Load<Sprite>("Images/RobotFace");
        }

        if (activeTool == null)
        {
            ActiveToolText.text = "";
            ActiveToolImage.color = new Color(255,255,255,0);
        }
        else
        {
            // Set  active tool
            ActiveToolText.text = activeTool.name;
            ActiveToolImage.sprite = Resources.Load<Sprite>(activeTool.spritePath);
            ActiveToolImage.color = new Color(255, 255, 255, 1);
        }

        // Set  tool list
        // TODO because this takes a bit more time than imagined

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    void Pause()
    {
        isPaused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

}
