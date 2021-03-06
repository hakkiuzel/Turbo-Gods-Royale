﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSX.UniversalVehicleCombat
{
    /// <summary>
    /// Open the power management menu.
    /// </summary>
    public class TriggerGroupsMenuOpenInput : GeneralInput
    {
        [Tooltip("The input for opening the trigger groups menu.")]
        [SerializeField]
        protected CustomInput openMenuInput;

        [Tooltip("The game state to transition to when the input is pressed.")]
        [SerializeField]
        protected GameState targetGameState;


        // Called every frame if the conditions for the General Input class are satisfied.
        protected override void InputUpdate()
        {
            base.InputUpdate();
            if (openMenuInput.Down())
            {
                // Check the focused game agent exists
                if (GameAgentManager.Instance.FocusedGameAgent != null)
                {
                    // Check the focused game agent is in a vehicle
                    if (GameAgentManager.Instance.FocusedGameAgent.IsInVehicle)
                    {
                        // Check the focused game agent is in a vehicle with a Power component
                        if (GameAgentManager.Instance.FocusedGameAgent.Vehicle.GetComponent<TriggerablesManager>() != null)
                        {
                            // Enter the game state
                            GameStateManager.Instance.EnterGameState(targetGameState);
                        }
                    }
                }
            }
        }
    }

}
