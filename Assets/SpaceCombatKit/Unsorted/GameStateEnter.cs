using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSX.UniversalVehicleCombat
{
    public class GameStateEnter : MonoBehaviour
    {
        [SerializeField]
        protected GameState gameState;


        public void EnterGameState()
        {
            GameStateManager.Instance.EnterGameState(gameState);
        }

        public void EnterGameState(GameState newGameState)
        {
            GameStateManager.Instance.EnterGameState(newGameState);
        }
    }
}
