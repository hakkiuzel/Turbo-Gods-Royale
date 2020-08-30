using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VSX.UniversalVehicleCombat.Radar;

namespace VSX.UniversalVehicleCombat
{

    /// <summary>
    /// Base class for a guided missile.
    /// </summary>
    public class Missile : Projectile
    {

        [SerializeField]
        protected TargetLocker targetLocker;

        /// <summary>
        /// Set the target.
        /// </summary>
        /// <param name="target">The new target.</param>
        public virtual void SetTarget(Trackable target)
        {
            if (targetLocker != null) targetLocker.SetTarget(target);
        }

        /// <summary>
        /// Set the lock state of the missile.
        /// </summary>
        /// <param name="lockState">The new lock state.</param>
        public virtual void SetLockState(LockState lockState)
        {
            if (targetLocker != null) targetLocker.SetLockState(lockState);
        }
    }
}