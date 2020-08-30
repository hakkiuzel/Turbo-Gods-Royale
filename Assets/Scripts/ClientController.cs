using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ClientState
{
    Initial,                        // -> ConnectingToMaster
    ConnectingToMaster,             // if success -> ConnectedToMaster, if failure -> FailedToConnectToMaster
    ConnectedToMaster,              // -> LoggingIn
    FailedToConnectToMaster,        // Stop
    LoggingIn,                      // if success -> LoggedIn, if failure -> FailedToLogIn
    LoggedIn,                       // -> BetweenGames
    FailedToLogIn,                  // Stop
    BetweenGames,                   // RequestingGame
    RequestedGame,                  // if success -> ConnectingToGameServer, if failure -> FailedToGetGame
    AssignedGame,                   // -> ConnectingToGameServer
    FailedToGetGame,                // Stop
    ConnectingToGameServer,         // if success -> ConnectedToGameSever, if failure -> FailedToConnectToGameServer
    ConnectedToGameServer,          // if get GameStarted -> GameStarted
    FailedToConnectToGameServer,    // Stop
    GameStarted,                    // if get GameEnded -> GameEnded
    GameEnded,                      // -> DisconnectFromGameServer
    DisconnectedFromGameServer,     // -> BetweenGames
    Stop
};

public class ClientController : MonoBehaviour {

    public Button[] Buttons;

    public int GamesPlayed { get; set; }
    public int GamesAborted { get; set; }

    private ClientState _clientState;
    public ClientState ClientState
    {
        get { return _clientState; }
        set
        {
            _clientState = value;
            ShowClientState();
        }
    }

    private string _status;
    public string Status
    {
        set
        {
            _status = value;
        }
        get { return _status; }
    }

    ColorBlock highlightedColorBlock;

    private void ShowClientState()
    {
        if ((int)this.ClientState < Buttons.Length &&
            Buttons[(int)this.ClientState] != null)
        {
            Buttons[(int)this.ClientState].Select();
            Buttons[(int)this.ClientState].colors = highlightedColorBlock;
        }
    }

    void Start()
    {
        UnityEngine.Random.InitState((int)(System.DateTime.Now.Ticks % 10000));
        GamesPlayed = 0;
        GamesAborted = 0;
        ClientState = ClientState.Initial;

        highlightedColorBlock = ColorBlock.defaultColorBlock;
        highlightedColorBlock.highlightedColor = new Color(135 / 255f, 206 / 255f, 250 / 255f);
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(2, 2, Screen.width, style.fontSize);
        style.fontSize = 18;
        style.alignment = TextAnchor.UpperLeft;
        style.normal.textColor = Color.white;
        string text = string.Format("[played {0} | aborted {1} | {2}] {3}",
            GamesPlayed, GamesAborted, ClientState, Status);
        GUI.Label(rect, text, style);
    }


}
