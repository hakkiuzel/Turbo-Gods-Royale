using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class Player_Health : NetworkBehaviour

{
    [SyncVar(hook = "OnHealthChanged")] public int health;
    private int maxHealth = 100000;
    private Text healthText;
    public Image Healthbar;
    public float percentage;
    float lerpspeed;

      void Start()
    {
        health = maxHealth;
        if (isLocalPlayer)
        {
            
            Healthbar = GameObject.Find("HealthBar").GetComponent<Image>();

        }
     

         
         
    }
 


    public void DetuctHealth(int dmg)
    {
        health -= dmg;
    }

    public void OnHealthChanged(int hlth)
    {
        health = hlth;

      
        
    }


    void Update()
    {
        lerpspeed = 3f * Time.deltaTime;
        percentage = (float) health / (float) maxHealth ;
        
        Healthbar.fillAmount = Mathf.Lerp(Healthbar.fillAmount, percentage, lerpspeed);
    }

}
