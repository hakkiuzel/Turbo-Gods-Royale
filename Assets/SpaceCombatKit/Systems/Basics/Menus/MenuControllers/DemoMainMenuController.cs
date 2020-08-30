using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VSX.UniversalVehicleCombat
{
    /// <summary>
    /// The main menu controller for the Space Combat Kit demos.
    /// </summary>
    public class DemoMainMenuController : MonoBehaviour
    {
        /// <summary>
        /// Called when click on a specific demo in the mnu.
        /// </summary>
        /// <param name="sceneIndex">The scene index for the selected scene.</param>
        public void StartScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

}
