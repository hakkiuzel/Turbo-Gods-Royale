using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSX.UniversalVehicleCombat
{
    public class SpaceshipPatrolBehaviour : AISpaceshipBehaviour
    {

        public PatrolRoute patrolRoute;
        protected int patrolTargetIndex;

        public float maxPatrolTargetArrivalDistance = 50;

        public float patrolThrottle = 0.5f;

        protected VehicleEngines3D engines;


        protected override bool Initialize(Vehicle vehicle)
        {

            if (!base.Initialize(vehicle)) return false;

            engines = vehicle.GetComponent<VehicleEngines3D>();
            if (engines == null) { return false; }

            return true;

        }

        public override bool BehaviourUpdate()
        {
            if (!base.BehaviourUpdate()) return false;

            if (patrolRoute == null || patrolRoute.Waypoints.Count == 0) return false;

            //Look for patrol route
            if (Vector3.Distance(vehicle.transform.position, patrolRoute.Waypoints[patrolTargetIndex].position) < maxPatrolTargetArrivalDistance)
            {
                patrolTargetIndex++;
                if (patrolTargetIndex >= patrolRoute.Waypoints.Count)
                {
                    patrolTargetIndex = 0;
                }
            }
            
            Maneuvring.TurnToward(vehicle.transform, patrolRoute.Waypoints[patrolTargetIndex].position, maxRotationAngles, shipPIDController.steeringPIDController);
            engines.SetSteeringInputs(shipPIDController.steeringPIDController.GetControlValues());

            engines.SetMovementInputs(new Vector3(0, 0, patrolThrottle));

            return true;

        }
    }
}