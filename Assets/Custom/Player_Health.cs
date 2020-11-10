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
    public Text KillerText;
    public GameObject mytransform;
    public string myName;


    [SyncVar(hook = "OnPlayerDead")] public string WhoISDead;

    [SyncVar(hook = "OnPlayerDeadKillerName")] public string WhoISKiller;

    [SyncVar]
    public int isDead = 0;

      void Start()
    {
        mytransform = this.gameObject;
        myName = mytransform.name.ToString();
        feedText = GameObject.FindGameObjectWithTag("feed").GetComponent<Text>();
        KillerText= GameObject.FindGameObjectWithTag("killerFeedName").GetComponent<Text>();
        health = maxHealth;
        
            if (isLocalPlayer) {
           
       Healthbar = GameObject.Find("HealthBar").GetComponent<Image>();
    }
    else return;





}



    public void InformTheKiller(string killerName)
    {

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
          
        lerpspeed = 3f * Time.deltaTime;
        percentage = (float) health / (float) maxHealth ;
        
        Healthbar.fillAmount = Mathf.Lerp(Healthbar.fillAmount, percentage, lerpspeed);

        Color healthcolor = Color.Lerp(Color.yellow, Color.green, percentage);
        Healthbar.color = healthcolor;

    

       
 
    }

    void OnPlayerDeadKillerName (string KillerName)
    {
        WhoISKiller = KillerName;
        KillerText.text = KillerName;

    }

    void OnPlayerDead(string playerName2)
    {
       
        WhoISDead = playerName2;
        feedText.text = WhoISKiller + " killed " + WhoISDead;
    }

 [Command]
  public void CmdDie(string playerDead)
    {
        WhoISDead = playerDead;
         
    }
}
