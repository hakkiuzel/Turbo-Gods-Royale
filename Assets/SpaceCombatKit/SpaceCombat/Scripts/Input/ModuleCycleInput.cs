using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSX.UniversalVehicleCombat
{
    public class ModuleCycleInput : VehicleInput
    {
        [Tooltip("The ID of the module mount to cycle modules at.")]
        [SerializeField]
        protected string moduleMountID;

        [Tooltip("The input that cycles forward through the modules.")]
        [SerializeField]
        protected CustomInput cycleForwardInput;

        [Tooltip("The input that cycles backward through the modules.")]
        [SerializeField]
        protected CustomInput cycleBackwardInput;

        protected Vehicle vehicle;


        protected override bool Initialize(Vehicle vehicle)
        {
            if (!base.Initialize(vehicle)) return false;

            // Get a reference to the vehicle
            this.vehicle = vehicle;

            return true;
        }

        protected void Cycle(bool isForward)
        {
            // Go through all the module mounts
            for (int i = 0; i < vehicle.ModuleMounts.Count; ++i)
            {
                // Find the one(s) with the correct ID
                if (vehicle.ModuleMounts[i].ID == moduleMountID)
                {
                    // cycle forward or backward
                    vehicle.ModuleMounts[i].Cycle(isForward);
                }
            }
        }

        protected override void InputUpdate()
        {
            // Cycle forward input
            if (cycleForwardInput.Down())
            {
                Cycle(true);
            }

            // Cycle backward input
            if (cycleBackwardInput.Down())
            {
                Cycle(false);
            }
        }
    }
}
