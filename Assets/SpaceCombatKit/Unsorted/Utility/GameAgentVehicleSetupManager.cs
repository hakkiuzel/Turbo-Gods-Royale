using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat.Radar;
using UnityEngine.Events;

namespace VSX.UniversalVehicleCombat
{
    public class GameAgentVehicleSetupManager : MonoBehaviour
    {

        [SerializeField]
        protected Vehicle vehicle;

        public UnityEvent onPlayerEnteredVehicle;

        public UnityEvent onAIEnteredVehicle;

        public UnityEvent onVehicleExited;

        protected Trackable[] trackables;
        protected TargetSelector[] targetSelectors;

        protected Trackable rootTrackable;

        [SerializeField]
        protected bool overrideRootTrackableLabel = true;

        [SerializeField]
        protected string labelKey = "Label";

        protected Team originalTeam;


        protected void Awake()
        {
            trackables = transform.GetComponentsInChildren<Trackable>();
            if (trackables.Length > 0)
            {
                originalTeam = trackables[0].Team;
            }

            rootTrackable = GetComponent<Trackable>();
            
            targetSelectors = transform.GetComponentsInChildren<TargetSelector>();

            vehicle.onEntered.AddListener(OnVehicleEntered);
            vehicle.onExited.AddListener(OnVehicleExited);
        }

        protected void Reset()
        {
            vehicle = transform.GetComponent<Vehicle>();
        }

        protected virtual void UpdateTrackables(GameAgent gameAgent)
        {
            // Update the vehicle's team
            Team team = gameAgent == null ? originalTeam : gameAgent.Team;

            // Update the Team for all the trackables on this vehicle
            for (int i = 0; i < trackables.Length; ++i)
            {
                trackables[i].Team = team;
            }

            // Update the label on the root trackable
            if (overrideRootTrackableLabel && rootTrackable != null)
            {
                if (rootTrackable.variablesDictionary.ContainsKey(labelKey))
                {
                    LinkableVariable labelVariable = rootTrackable.variablesDictionary[labelKey];
                    if (labelVariable != null)
                    {
                        labelVariable.StringValue = gameAgent.Label;
                    }
                }
            }
        }

        protected virtual void UpdateTargetSelectors(GameAgent gameAgent)
        {
            // Update the vehicle's team
            Team team = gameAgent == null ? originalTeam : gameAgent.Team;
          
            if (team != null)
            {
                for (int i = 0; i < targetSelectors.Length; ++i)
                {
                    targetSelectors[i].SelectableTeams = team.HostileTeams;
                }
            }
        }

        protected virtual void OnVehicleEntered(GameAgent gameAgent)
        {
          
            UpdateTrackables(gameAgent);
            UpdateTargetSelectors(gameAgent);

            // Call the event
            if (gameAgent != null)
            {
                if (gameAgent.IsPlayer)
                {
                    onPlayerEnteredVehicle.Invoke();
                }
                else
                {
                    onAIEnteredVehicle.Invoke();
                }
            }
        }

        protected virtual void OnVehicleExited(GameAgent gameAgent)
        {
            onVehicleExited.Invoke();
        }
    }
}

