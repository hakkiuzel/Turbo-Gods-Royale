using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.InteropServices;
using UnityStandardAssets.CrossPlatformInput;

public class Player_Health : NetworkBehaviour

{
    [SyncVar(hook = "OnHealthChanged")] public int health;
    private int maxHealth = 100000;
  
    public Image Healthbar;
    public float percentage;
    float lerpspeed;
    public GameObject explosion;
    public Text feedText;
    public Text KillerText;
    public GameObject mytransform;
    public string myName;
    public GameObject container;
    public Transform parentOFContainer;
   


    [SyncVar(hook = "OnPlayerDead")] public string WhoISDead;

    [SyncVar(hook = "OnPlayerDeadKillerName")] public string WhoISKiller;

    [SyncVar]
    public int isDead = 0;

      void Start()
    {
        parentOFContainer = GameObject.FindGameObjectWithTag("parent").transform;
        
         
        mytransform = this.gameObject;
        myName = mytransform.name.ToString();
        
        health = maxHealth;
        
            if (isLocalPlayer) {
           
       Healthbar = GameObject.Find("HealthBar").GetComponent<Image>();
    }
    else return;





}


    [ClientRpc]
   void RpcInstantiate()
    {
     if (isDead == 0) {
            isDead = 1;
        Instantiate(container, parentOFContainer);
            feedText = GameObject.FindGameObjectWithTag("feed").GetComponent<Text>();
            KillerText = GameObject.FindGameObjectWithTag("killerFeedName").GetComponent<Text>();
    }
}

[ClientRpc]
void RpcFindFeed()
    {
        feedText = GameObject.FindGameObjectWithTag("feed").GetComponent<Text>();
    }
    public void InformTheKiller(string killerName)
    {
        RpcInstantiate();
        WhoISKiller = killerName;
    }

    public void Inform (string playerKilled)
    {
       
        WhoISDead = playerKilled;
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
          if (isLocalPlayer) { 
        lerpspeed = 3f * Time.deltaTime;
        percentage = (float) health / (float) maxHealth ;
        
        Healthbar.fillAmount = Mathf.Lerp(Healthbar.fillAmount, percentage, lerpspeed);

        Color healthcolor = Color.Lerp(Color.yellow, Color.green, percentage);
        Healthbar.color = healthcolor;

        }

             
        

    }

    void OnPlayerDeadKillerName (string KillerName)
    {
         
        WhoISKiller = KillerName;
        KillerText.text = KillerName + " killed ";

    }

    void OnPlayerDead(string playerName2)
    {
       
        WhoISDead = playerName2;
        feedText.text = playerName2;
      
    }

 [Command]
  public void CmdDie(string playerDead)
    {
        WhoISDead = playerDead;
         
    }
}
