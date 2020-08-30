using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat;
using UnityEngine.Events;

public class CarrierLaunch : MonoBehaviour
{

    public GameState launchingGameState;
    public GameState launchingFinishedGameState;

    public Transform launchEnd;

    public AnimationCurve launchCurve;
    public AnimationCurve rumbleCurve;

    public float launchTime = 3;

    public List<Collider> carrierColliders = new List<Collider>();

    public UnityEvent onLaunched;


    private void Awake()
    {
        for(int i = 0; i < carrierColliders.Count; ++i)
        {
            carrierColliders[i].enabled = false;
        }
    }

    public void Launch(Vehicle vehicle)
    {
        StartCoroutine(LaunchCoroutine(vehicle));      
    }

    IEnumerator LaunchCoroutine(Vehicle vehicle)
    {

        GameStateManager.Instance.EnterGameState(launchingGameState);
        vehicle.transform.LookAt(launchEnd, Vector3.up);
        vehicle.GetComponent<VehicleEngines3D>().SetMovementInputs(new Vector3(0, 0, 0));

        float startTime = Time.time;
        while (true)
        {
            float timeAmount = (Time.time - startTime) / launchTime;
            float launchAmount = launchCurve.Evaluate(timeAmount);
            
            vehicle.GetComponent<VehicleEngines3D>().SetMovementInputs(new Vector3(0, 0, launchAmount));
            RumbleManager.Instance.AddSingleFrameRumble(rumbleCurve.Evaluate(timeAmount));

            if (timeAmount > 1)
            {
                Cursor.lockState = CursorLockMode.Locked;
                yield return null;
                Cursor.lockState = CursorLockMode.None;
                GameStateManager.Instance.EnterGameState(launchingFinishedGameState);

                for (int i = 0; i < carrierColliders.Count; ++i)
                {
                    carrierColliders[i].enabled = true;
                }

                onLaunched.Invoke();

                break;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
