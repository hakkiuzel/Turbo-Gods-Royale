using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace VSX.UniversalVehicleCombat
{
    [System.Serializable]
    public class FloatingOriginShiftEventHandler : UnityEvent { }

    /// <summary>
    /// Add this to any object that needs to be shifted when the floating origin shifts.
    /// </summary>
    public class FloatingOriginChild : MonoBehaviour
    {

        public FloatingOriginShiftEventHandler onPreOriginShift;
        public FloatingOriginShiftEventHandler onPostOriginShift;

        // Get the floating position of this object.
        public Vector3 FloatingPosition
        {
            get { return (transform.position - FloatingOriginManager.Instance.transform.position); }
        }


        // Use this for initialization
        void Awake()
        {
            Register();
        }

        public void Register()
        {
            if (FloatingOriginManager.Instance != null)
            {
                // Register this floating origin child
                FloatingOriginManager.Instance.Register(this);
            }
        }

        public void Deregister()
        {
            if (FloatingOriginManager.Instance != null)
            {
                // Register this floating origin child
                FloatingOriginManager.Instance.Deregister(this);
            }
        }

        /// <summary>
        /// Called before the floating origin shifts.
        /// </summary>
        public virtual void OnPreOriginShift()
        {
            onPreOriginShift.Invoke();
        }

        /// <summary>
        /// Called after the floating origin shifts.
        /// </summary>
        public virtual void OnPostOriginShift()
        {
            onPostOriginShift.Invoke();
        }
    }
}