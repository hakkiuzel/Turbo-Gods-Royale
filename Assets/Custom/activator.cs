using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class activator : NetworkBehaviour
{
    public GameObject mapobj;


 void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }





    IEnumerator ExampleCoroutine()
    {
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);

        //After we have waited 5 seconds print the time again.
        mapobj.SetActive(true);
    }

}
