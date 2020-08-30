﻿using System;
using System.Collections;
using System.Linq;
using Barebones.MasterServer;
using Barebones.Utils;
using TLGFPowerJoysticks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using Random = UnityEngine.Random;

public class PlayerController : NetworkBehaviour
{
     
 

    [SyncVar]
    public string Name;

    public Animator anim;
    private Text _nameObject;
    public Text NamePrefab;

    public Transform NameTransform;



    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;
    public Rigidbody rb;
    public float acceleration;
    public float rotationRate;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;
    



    private float rotationVelocity;
    private float groundAngleVelocity;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;




    // Use this for initialization
    private void Awake()
    {
        
        StartCoroutine(DisplayName());
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        
    }


    void FixedUpdate()
    {

 
        RaycastHit hit;
        foreach (Transform thruster in thrusters)
        {
            Vector3 downwardForce;
            float distancePercentage;

            if (Physics.Raycast(thruster.position, thruster.up * -1, out hit, thrusterDistance))
            {
                distancePercentage = 1 - (hit.distance / thrusterDistance);

                downwardForce = transform.up * thrusterStrength * distancePercentage;

                downwardForce = downwardForce * Time.deltaTime * rb.mass;


                rb.AddForceAtPosition(downwardForce, thruster.position);

            }
        }




        if (Physics.Raycast(transform.position, transform.up * -1, 3f))
        {
            rb.drag = 1;

            Vector3 forwardForce = transform.forward * acceleration * CrossPlatformInputManager.GetAxis("Vertical");
            forwardForce = forwardForce * Time.deltaTime * rb.mass;

            rb.AddForce(forwardForce);
        }
        else
        {
            rb.drag = 0;
        }

        


        Vector3 turnTorque = Vector3.up * rotationRate * CrossPlatformInputManager.GetAxis("Horizontal");
        turnTorque = turnTorque * Time.deltaTime * rb.mass;
        rb.AddTorque(turnTorque);

        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, CrossPlatformInputManager.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;
        
    

    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }



    private void LateUpdate()
    {
        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("Rechts", true);
            anim.SetBool("Links", false);
            anim.SetBool("Idling", false);
            this.GetComponent<setupPlayer>().CmdChangeAnimState("rechts");
            Debug.Log("rechts");
        }

        if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
        {

            anim.SetBool("Rechts", false);
            anim.SetBool("Links", true);
            anim.SetBool("Idling", false);
            this.GetComponent<setupPlayer>().CmdChangeAnimState("links");
            Debug.Log("links");
        }

        if (CrossPlatformInputManager.GetAxis("Horizontal") == 0)
        {

            anim.SetBool("Rechts", false);
            anim.SetBool("Links", false);
            anim.SetBool("Idling", true);
            this.GetComponent<setupPlayer>().CmdChangeAnimState("idle");
            Debug.Log("idle");
        }

        if (CrossPlatformInputManager.GetButton("Fire1") )
        {
            Debug.Log("feuer");
            CmdFire();
        }





    }










    public void Setup(string username)
    {
        Name = username;
    }

   
 
 

  

    public void MoveToRandomSpawnPoint()
    {
        var spawns = FindObjectsOfType<NetworkStartPosition>();
        var spawn = spawns[Random.Range(0, spawns.Length)];
        transform.position = spawn.transform.position;
    }
 

    
 
 
 

   
 

    public IEnumerator DisplayName()
    {
        // Create a player name
        _nameObject = Instantiate(NamePrefab).GetComponent<Text>();
        _nameObject.text = Name ?? ".";
        _nameObject.transform.SetParent(FindObjectOfType<Canvas>().transform);

        while (true)
        {
            if ((_nameObject.text != Name) && (Name != null))
                _nameObject.text = Name;

            // While we're still "online"
            _nameObject.transform.position = RectTransformUtility
                                                .WorldToScreenPoint(Camera.main, NameTransform.position) + Vector2.up*30;

            yield return 0;
        }
    }
}