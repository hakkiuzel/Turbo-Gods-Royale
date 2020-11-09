using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class gameStarter : NetworkBehaviour
{

    NetworkManagerSample nm;
    public int pz;
    public Canvas cav;
    public TrackObject cam;
     






    // Start is called before the first frame update
    void Start()
    {
        cav = GameObject.FindGameObjectWithTag("start").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

        nm = FindObjectOfType<NetworkManagerSample>();

        pz = nm.numPlayers;

        StartCoroutine(ExecuteAfterTime(3.0f));

    }




    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (pz == 2)
        {
            RpcStarting();

        }
       
    }

    [ClientRpc]
    void RpcStarting()
    {

         
        cam.StartCam();



    }
}
