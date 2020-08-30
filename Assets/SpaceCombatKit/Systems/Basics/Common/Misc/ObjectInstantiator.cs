using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.Pooling;

namespace VSX.UniversalVehicleCombat
{
    /// <summary>
    /// Instantiate one or more objects in the scene.
    /// </summary>
    public class ObjectInstantiator : MonoBehaviour
    {
        [Tooltip("A list of gameobjects to be instantiated.")]
        [SerializeField]
        protected List<GameObject> objectsToInstantiate = new List<GameObject>();

        [Tooltip("Whether to use object pooling or instantiate a new instance every time.")]
        [SerializeField]
        protected bool usePoolManager;

        [Tooltip("The transform representing the position and rotation to instantiate objects with.")]
        [SerializeField]
        protected Transform instantiationTransform;


        protected virtual void Reset()
        {
            instantiationTransform = transform;
        }

        /// <summary>
        /// Instantiate all the objects in the list.
        /// </summary>
        public virtual void InstantiateAll()
        {
            for(int i = 0; i < objectsToInstantiate.Count; ++i)
            {
                InstantiateObject(objectsToInstantiate[i]);
            }
        }

        /// <summary>
        /// Instantiate an object at a specified index in the list.
        /// </summary>
        /// <param name="index">The list index.</param>
        public virtual void InstantiateAtIndex(int index)
        {
            if (objectsToInstantiate.Count >= index)
            {
                InstantiateObject(objectsToInstantiate[index]);
            }
        }

        /// <summary>
        /// Instantiate an object.
        /// </summary>
        /// <param name="objectToInstantiate"></param>
        protected virtual void InstantiateObject(GameObject objectToInstantiate)
        {
            if (usePoolManager)
            {
                PoolManager.Instance.Get(objectToInstantiate, instantiationTransform.position, instantiationTransform.rotation);
            }
            else
            {
                Instantiate(objectToInstantiate, instantiationTransform.position, instantiationTransform.rotation);
            }
        }
    }
}

