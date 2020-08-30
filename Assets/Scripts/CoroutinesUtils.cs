using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineUtils : MonoBehaviour
{

    public static IEnumerator StartWaiting(
        float time, Action doneCallback,
        float increment, Action<float> incrementCallback,
        bool countUp = true)
    {
        float timeElapsed = 0f;
        float timeRemaining = time;

        while (timeRemaining > 0f)
        {
            yield return new WaitForSeconds(increment);
            timeRemaining -= increment;
            timeElapsed += increment;
            incrementCallback.Invoke(countUp ? timeElapsed : timeRemaining);
        }
        doneCallback.Invoke();
    }

    public static IEnumerator StartWaiting(float time,
        Action doneCallback)
    {
        yield return new WaitForSeconds(time);
        doneCallback.Invoke();
    }

}
