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
    public GameMode currentMode;// = GameMode.Singleplayer;

    public string single = "Default";

     //* Possible game states: 
     //* Singleplayer
     //*      --CurrentAIType
     //*      --
     //* Multiplayer

    public string GetControls(bool isHuman)
    {
        if (isHuman)
        {
            return "WASD";
        }
        else
        {
            if (currentMode == GameMode.LocalMultiplayer)
            {
                return "IJKL";
            }
            else if (currentMode == GameMode.OnlineMultiplayer)
            {
               
            }
        }
        Debug.Log("STATE: " + currentMode);
        return "Something";
    }
}
