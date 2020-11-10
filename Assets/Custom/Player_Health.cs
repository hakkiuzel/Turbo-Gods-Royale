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
  
    public Image Healthbar;
    public float percentage;
    float lerpspeed;
    public GameObject explosion;
    public Text feedText;
    public GameObject mytransform;
    public string myName;

     
    [SyncVar(hook = "OnPlayerDead")] public string WhoISDead;

    [SyncVar]
    public int isDead = 0;

      void Start()
    {
        mytransform = this.gameObject;
        myName = mytransform.name.ToString();
        feedText = GameObject.FindGameObjectWithTag("feed").GetComponent<Text>();
        health = maxHealth;
        
            if (isLocalPlayer) {
           
       Healthbar = GameObject.Find("HealthBar").GetComponent<Image>();
    }
    else return;





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

        Color healthcolor = Color.Lerp(Color.yellow, Color.green, percentage);
        Healthbar.color = healthcolor;

        if (health <= 0 && isDead==0)
        {
            
            CmdDie(myName);
        }

       
 
    }


    void OnPlayerDead(string playerName2)
    {
        WhoISDead = playerName2;
        feedText.text = WhoISDead + " is Dead";
    }

 [Command]
  public void CmdDie(string playerDead)
    {
        WhoISDead = playerDead;
         
    }
}
