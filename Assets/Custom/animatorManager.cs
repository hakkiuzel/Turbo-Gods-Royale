using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class animatorManager : MonoBehaviour
{
 

 public void rechts()
    {
        GetComponent<NetworkAnimator>().SetTrigger("rechts");
    }


    public void links()
    {
        GetComponent<NetworkAnimator>().SetTrigger("links");
    }


     public void idle()
    {
        GetComponent<NetworkAnimator>().SetTrigger("idle");
    }



}
