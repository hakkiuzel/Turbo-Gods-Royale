using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ID_PREFIX = "Player";
    public Text text;
     
    public static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void RegisterPlayer(string _netID, Player _player)
    {

        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
    }

    public static void UnRegisterPlayer(string _playerId)
    {
        players.Remove(_playerId);
    }

     void Update()
    {
        show();
    }


    void show()
    {
        

        foreach (string _playerID in players.Keys)
        {
            text.text = (_playerID + " - " + players[_playerID].transform.name);
        }

         
    }

    public static Player GetPlayer(string _playerID)
    {
        return players[_playerID];
    }
}
