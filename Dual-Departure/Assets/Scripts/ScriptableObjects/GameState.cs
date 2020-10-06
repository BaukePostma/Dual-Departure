using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class that handles functionaliteit that needs to be kept between levels,such as collected tools.
/// Also keeps track of other singleton object such as the levelloader and the user interface
/// </summary>
public class GameState : ScriptableObject
{

    //Singleton code
    private static GameState _instance;
    public static GameState Instance {
        get
        {
            if (!_instance)
                   _instance = FindObjectOfType<GameState>();
            if (!_instance)
                _instance = CreateInstance<GameState>();
            return _instance;
        } }
    private GameState() { }

    // Store a reference to the levelloader in the current scene
    private  LevelLoader _loader;
    public LevelLoader Loader
    {
        get
        {
            if (!_loader)
                _loader = FindObjectOfType<LevelLoader>();
            if (!_loader)
                _loader = Instantiate(Resources.Load<LevelLoader>("LevelLoader")); 
            return _loader;
        }
    }
    // Store a reference to the user interface in the current scene.
    private UserInterface _ui;
    public UserInterface UI
    {
        get
        {
            if (!_ui)
                _ui = FindObjectOfType<UserInterface>();
            if (!_loader)
                _ui = Instantiate(Resources.Load<UserInterface>("UserInterface"));
            return _ui;
        }
    }
    // Gamestate logic to keep track of across screens
    public enum GameMode
    {
        Singleplayer,
        LocalMultiplayer,
        OnlineMultiplayer
    }
    public enum AIType
    {
        Partner,
        Solver,
        ToMBuddy
    }
    public AIType currentAi;// = AIType.Solver;
    public GameMode currentMode = GameMode.LocalMultiplayer;

    // For multiplayer, keep track of the current players character for UI purposes
    public bool isCurrentPlayerHuman = true;

    // Keep track of tools during level swittches
    private BaseTool[] humanToolList;
    private ActiveTool humanActiveTool;
    private BaseTool[] robotToolList;
    private ActiveTool robotActiveTool;

    // Save collected tools to the gamestate at the end of the level
    public void SaveToolLists(BaseTool[] humanTools, BaseTool[] robotTools)
    {
        this.humanToolList = humanTools;
        this.robotToolList = robotTools;
    }
    public void SaveHumanActiveTool(ActiveTool humanActiveTool)
    {
        this.humanActiveTool = humanActiveTool;
    }
    public void SaveRobotActiveTool(ActiveTool robotActiveTool)
    {
        this.robotActiveTool = robotActiveTool;
    }

    // Load collected tools at the start of the level
    public BaseTool[] getHumanTools()
    {
        return this.humanToolList;
    }
    public ActiveTool getHumanActiveTool()
    {
        return this.humanActiveTool;
    }
    public BaseTool[] getRobotTools()
    {
        return this.robotToolList;
    }
    public ActiveTool getRobotActiveTool()
    {
        return this.robotActiveTool;
    }
}
