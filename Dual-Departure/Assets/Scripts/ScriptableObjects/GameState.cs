using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : ScriptableObject
{

    //Singleton code
    private static GameState _instance;
    public static GameState Instance {
        get
        {
            if (!_instance)
                   _instance = FindObjectOfType<GameState>();
               // _instance = Resources.FindObjectsOfTypeAll<GameState>();
            if (!_instance)
                _instance = CreateInstance<GameState>();
            return _instance;
        } }
    private GameState() { }

    // Keep a reference to the levelloader in the current scene
    private  LevelLoader _loader;
    public LevelLoader Loader
    {
        get
        {
            if (!_loader)
                _loader = FindObjectOfType<LevelLoader>();
            if (!_loader)
                _loader = Instantiate(Resources.Load<LevelLoader>("LevelLoader")); 
            // _instance = Resources.FindObjectsOfTypeAll<GameState>();
            //if (!_loader)
            //    _loader = CreateInstance<LevelLoader>();
            return _loader;
        }
    }
    // Keep a reference to the user interface in the current scene.
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
        Follower,
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
