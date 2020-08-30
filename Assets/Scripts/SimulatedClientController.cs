using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedClientController : MonoBehaviour
{
    public ClientController controller;

    // timeouts and waits
    private float ConnectToMasterTimeout = 5f;
    private float LogInTimeout = 5f;
    private float RequestedGameTimeout = 5f;
    private float ConnectToGameServerTimeout = 5f;
    private float WaitingToConnectToMaster = 3f;
    private float WaitingBetweenGames = 3f;

    // simulate failures
    private float ConnectToMasterSuccess = .66f;
    private float LogInSuccess = .66f;
    private float RequestedGameSuccess = .66f;
    private float ConnectToGameServerSuccess = .66f;


    void Start()
    {
        UnityEngine.Random.InitState((int)(System.DateTime.Now.Ticks % 10000));

        GoToState_Initial();
    }

    public void GoToState_Initial()
    {
        controller.ClientState = ClientState.Initial;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(WaitingToConnectToMaster,
            () => { GoToState_ConnectingToMaster(); },
            1f,
            (time) => { controller.Status = string.Format("Waiting {0}s", time); }, false));
    }

    private IEnumerator backgroundEnumerator;

    private void StopBackgroundEnumerator()
    {
        if (backgroundEnumerator != null)
        {
            StopCoroutine(backgroundEnumerator);
            backgroundEnumerator = null;
        }
    }
    //private IEnumerator connectingToMasterCoroutine;

    private void GoToState_ConnectingToMaster()
    {
        controller.ClientState = ClientState.ConnectingToMaster;
        Debug.Log("connectingtomaster");
        backgroundEnumerator = CoroutineUtils.StartWaiting(ConnectToMasterTimeout,
            () => { GoToState_FailedToConnectToMaster(); },
            1f,
            (time) => { controller.Status = string.Format("Trying to connect {0}s", time); });
        StartCoroutine(backgroundEnumerator);

        // simulate change of success/failure
        if (UnityEngine.Random.Range(0f, 1f) <= ConnectToMasterSuccess) StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_ConnectedToMaster(); }));
    }

    private void GoToState_FailedToConnectToMaster()
    {
        controller.ClientState = ClientState.FailedToConnectToMaster;
        controller.Status = "Timed out";
        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_Initial(); }));
    }

    private void GoToState_ConnectedToMaster()
    {
        StopBackgroundEnumerator();

        controller.ClientState = ClientState.ConnectedToMaster;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_LoggingIn(); }));
    }

    private void GoToState_LoggingIn()
    {
        controller.ClientState = ClientState.LoggingIn;
        controller.Status = string.Empty;

        backgroundEnumerator = CoroutineUtils.StartWaiting(LogInTimeout,
            () => { GoToState_FailedToLogIn(); },
            1f,
            (time) => { controller.Status = string.Format("Trying to log in {0}s", time); });
        StartCoroutine(backgroundEnumerator);
        if (UnityEngine.Random.Range(0f, 1f) <= LogInSuccess) StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_LoggedIn(); }));
    }

    private void GoToState_LoggedIn()
    {
        StopBackgroundEnumerator();

        controller.ClientState = ClientState.LoggedIn;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_BetweenGames(); }));
    }

    private void GoToState_FailedToLogIn()
    {
        controller.ClientState = ClientState.FailedToLogIn;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_LoggingIn(); }));
    }

    private void GoToState_BetweenGames()
    {
        controller.ClientState = ClientState.BetweenGames;

        backgroundEnumerator = CoroutineUtils.StartWaiting(WaitingBetweenGames,
            () => { GoToState_RequestedGame(); },
            1f,
            (time) => { controller.Status = string.Format("Waiting {0}s", time); }, false);
        StartCoroutine(backgroundEnumerator);
    }

    private void GoToState_RequestedGame()
    {
        controller.ClientState = ClientState.RequestedGame;
        controller.Status = string.Empty;

        backgroundEnumerator = CoroutineUtils.StartWaiting(RequestedGameTimeout,
            () => { GoToState_FailedToGetGame(); },
            1f,
            (time) => { controller.Status = string.Format("Waiting for game {0}s", time); });
        StartCoroutine(backgroundEnumerator);
        if (UnityEngine.Random.Range(0f, 1f) <= RequestedGameSuccess) StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_AssignedGame(); }));
    }

    private void GoToState_AssignedGame()
    {
        StopBackgroundEnumerator();

        controller.ClientState = ClientState.AssignedGame;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_ConnectingToGameServer(); }));
    }

    private void GoToState_ConnectingToGameServer()
    {
        controller.ClientState = ClientState.ConnectingToGameServer;
        controller.Status = string.Empty;

        backgroundEnumerator = CoroutineUtils.StartWaiting(ConnectToGameServerTimeout,
            () => { GoToState_FailedToConnectToGameServer(); },
            1f,
            (time) => { controller.Status = string.Format("Waiting for game {0}s", time); });
        StartCoroutine(backgroundEnumerator);
        if (UnityEngine.Random.Range(0f, 1f) <= ConnectToGameServerSuccess) StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_ConnectedToGameServer(); }));
    }

    private void GoToState_ConnectedToGameServer()
    {
        StopBackgroundEnumerator();

        controller.ClientState = ClientState.ConnectedToGameServer;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_GameStarted(); }));
    }

    private void GoToState_GameStarted()
    {
        controller.ClientState = ClientState.GameStarted;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_GameEnded(); }));
    }

    private void GoToState_GameEnded()
    {
        controller.ClientState = ClientState.GameEnded;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_DisconnectedFromGameServer(); }));
    }

    private void GoToState_DisconnectedFromGameServer()
    {
        controller.ClientState = ClientState.DisconnectedFromGameServer;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_BetweenGames(); }));
    }

    private void GoToState_FailedToConnectToGameServer()
    {
        controller.ClientState = ClientState.FailedToConnectToGameServer;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_BetweenGames(); }));
    }

    private void GoToState_FailedToGetGame()
    {
        controller.ClientState = ClientState.FailedToGetGame;
        controller.Status = string.Empty;

        StartCoroutine(CoroutineUtils.StartWaiting(3f, () => { GoToState_BetweenGames(); }));
    }

}
