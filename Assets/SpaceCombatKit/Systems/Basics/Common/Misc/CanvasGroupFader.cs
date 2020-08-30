using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSX.UniversalVehicleCombat
{
    /// <summary>
    /// Fade a canvas group according to an animation curve.
    /// </summary>
    public class CanvasGroupFader : MonoBehaviour
    {
        [SerializeField]
        protected AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

        [SerializeField]
        protected float fadeTime = 3;
        protected float fadeStartTime;
        protected bool fading;

        [SerializeField]
        protected CanvasGroup canvasGroup;


        // Called when this component is first added to a gameobject or reset in the inspector
        protected virtual void Reset()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        protected virtual void Awake()
        {
            canvasGroup.alpha = 0;
        }

        /// <summary>
        /// Start fading the canvas group.
        /// </summary>
        public virtual void StartFade()
        {
            fading = true;
            fadeStartTime = Time.time;
        }


        // Called every frame
        protected virtual void Update()
        {
            if (fading)
            {
                float amount = (Time.time - fadeStartTime) / fadeTime;

                // If finished, stop fading
                if (amount >= 1)
                {
                    canvasGroup.alpha = fadeCurve.Evaluate(1);
                    fading = false;
                }
                // If still fading, update
                else
                {
                    float curveAmount = fadeCurve.Evaluate(amount);
                    canvasGroup.alpha = curveAmount;
                }
            }
        }
    }
}

