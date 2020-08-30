using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Water;



    void OnTriggerEnter(Collider other)
    {
        Water.SetActive(false);
        
    }



     void OnTriggerExit(Collider other)
    {
        Water.SetActive(true);
    }
}
