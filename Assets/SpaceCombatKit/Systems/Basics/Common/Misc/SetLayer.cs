using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSX.UniversalVehicleCombat
{
    public class SetLayer : MonoBehaviour
    {
        [SerializeField]
        protected string layerName;

        [SerializeField]
        protected bool includeChildren = true;

        private void Awake()
        {
            int layer = LayerMask.NameToLayer(layerName);

            if (layer != -1)
            {
                gameObject.layer = layer;

                if (includeChildren)
                {
                    foreach(Transform child in transform)
                    {
                        child.gameObject.layer = layer;
                    }
                }
            }
            else
            {
                Debug.LogError("Cannot set gameobject layer to '" + layerName + "' because it doesn't exist. Add this layer to your project before running the scene.");
            }
        }
    }
}

