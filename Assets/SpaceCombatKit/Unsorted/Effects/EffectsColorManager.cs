using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSX.UniversalVehicleCombat
{
    /// <summary>
    /// Control the color of a set of effects materials.
    /// </summary>
    public class EffectsColorManager : MonoBehaviour
    {

        [SerializeField]
        protected Color effectsColor = Color.white;

        [SerializeField]
        protected string colorID = "_Color";

        [SerializeField]
        protected float colorMultiplier = 1;

        [SerializeField]
        protected bool preserveAlpha = true;

        [Header("Effects Elements")]

        [SerializeField]
        protected List<Renderer> effectsRenderers = new List<Renderer>();
        protected List<Material> effectsMaterials = new List<Material>();
        protected List<float> effectsOriginalAlphas = new List<float>();


        private void Awake()
        {
            // Cache the materials
            for (int i = 0; i < effectsRenderers.Count; ++i)
            {
                effectsMaterials.Add(effectsRenderers[i].material);
                Color c = effectsRenderers[i].material.GetColor(colorID);
                effectsOriginalAlphas.Add(c.a);
                effectsRenderers[i].material.SetColor(colorID, colorMultiplier * new Color(effectsColor.r, effectsColor.g, effectsColor.b, c.a));
            }
        }

        public void SetAlpha(float alpha)
        {
            for(int i = 0; i < effectsMaterials.Count; ++i)
            {
                Color c = effectsMaterials[i].GetColor(colorID);
                c.a = alpha * (preserveAlpha ? effectsOriginalAlphas[i] : 1);
            }
        }
    }
}