using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.Pooling;

namespace VSX.UniversalVehicleCombat
{
    /// <summary>
    /// A spawn point for a member of a wave.
    /// </summary>
    public class PilotedVehicleSpawner : Spawner
    {
        [Header("General")]

        [SerializeField]
        protected List<GameAgent> pilotPrefabs = new List<GameAgent>();

        [SerializeField]
        protected List<Vehicle> vehiclePrefabs = new List<Vehicle>();

        [Header("Warp")]

        [SerializeField]
        protected bool warpIn = true;

        [SerializeField]
        protected AnimationCurve warpPositionCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        
        [SerializeField]
        protected float warpTime = 0.5f;

        [SerializeField]
        protected float warpDistance = 1000;

        [SerializeField]
        protected AudioSource warpAudio;

        [SerializeField]
        protected float warpAudioDelay = 0.15f;

        protected bool animating = false;
        protected float warpStartTime = 0;

        protected GameAgent pilot;
        protected Vehicle vehicle;

        public override bool Destroyed { get { return (pilot != null && pilot.IsDead); } }


        /// <summary>
        /// Spawn the object.
        /// </summary>
        public override void Spawn()
        {

            base.Spawn();

            Vector3 spawnPos = transform.position;
            if (warpIn)
            {
                spawnPos = transform.position - transform.forward * warpDistance;
            }

            if (usePoolManager)
            {

                pilot = PoolManager.Instance.Get(pilotPrefabs[Random.Range(0, pilotPrefabs.Count)].gameObject, spawnPos, transform.rotation).GetComponent<GameAgent>();
                vehicle = PoolManager.Instance.Get(vehiclePrefabs[Random.Range(0, vehiclePrefabs.Count)].gameObject, spawnPos, transform.rotation).GetComponent<Vehicle>();
            }
            else
            {
                pilot = Instantiate(pilotPrefabs[Random.Range(0, pilotPrefabs.Count)], spawnPos, transform.rotation);
                vehicle = Instantiate(vehiclePrefabs[Random.Range(0, vehiclePrefabs.Count)], spawnPos, transform.rotation);
            }

            pilot.Revive();
            vehicle.Restore();

            if (warpIn)
            {
                StartAnimation();
            }

            pilot.EnterVehicle(vehicle);

        }

        // Start the warp animation
        protected virtual void StartAnimation()
        {
            animating = true;

            vehicle.CachedRigidbody.isKinematic = true;

            if (warpIn)
            {
                warpStartTime = Time.time;
                if (warpAudio != null) warpAudio.PlayDelayed(warpAudioDelay);
            }
        }

        protected virtual void UpdateAnimation()
        {
            if (animating)
            {
                // Get the amount of the warp time that has passed
                float warpTimeAmount = (Time.time - warpStartTime) / warpTime;

                // If the warp has finished, place the object at the final position and finish
                if (warpTimeAmount >= 1)
                {
                    vehicle.transform.position = transform.position;
                    vehicle.CachedRigidbody.isKinematic = false;
                    animating = false;
                }
                else
                {
                    // Position the object according to the warp position curve
                    float warpAmount = warpPositionCurve.Evaluate(warpTimeAmount);
                    vehicle.transform.position = warpAmount * transform.position + (1 - warpAmount) * (transform.position - transform.forward * warpDistance);
                }
            }
        }

        // Called every frame
        protected virtual void Update()
        {
            if (animating) UpdateAnimation();
        }
    }
}
