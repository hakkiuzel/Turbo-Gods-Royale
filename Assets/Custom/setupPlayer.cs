
using DMM;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class setupPlayer : NetworkBehaviour
{
    [SyncVar(hook = "OnChangeAnimaiton")]
    public string animState = "idle";

    public GameObject playerCam;
    public GameObject playerIcon;
    public GameObject remoteIcon;






    [SerializeField]
    private Camera cam;




   

    Animator animator;




    void OnChangeAnimaiton(string aS)
    {
        if (isLocalPlayer) return;
        UpdateAnimationState(aS);
    }



    [Command]
    public void CmdChangeAnimState(string aS)
    {
        if (isLocalPlayer) return;
        UpdateAnimationState(aS);
    }



    void UpdateAnimationState(string aS)
    {
        if (animState == aS) return;
        animState = aS;
        Debug.Log(animState);
        if (animState == "idle")
        {
            animator.SetBool("Idling", true);
            animator.SetBool("Links", false);
            animator.SetBool("Rechts", false);
        }
        else if (animState == "rechts")
        {
            animator.SetBool("Rechts", true);
            animator.SetBool("Idling", false);
            animator.SetBool("Links", false);
        }
        else if (animState == "links")
        {
            animator.SetBool("Links", true);
            animator.SetBool("Rechts", false);
            animator.SetBool("Idling", false);
        }
    }








    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Idling", true);

        if (isLocalPlayer)
        {
            
            playerCam.SetActive(true);
            playerIcon.SetActive(true);
            remoteIcon.SetActive(false);



        }
        else
        {
            GetComponent<PlayerController>().enabled = false;
            
            playerCam.SetActive(false);
            remoteIcon.SetActive(true);
            playerIcon.SetActive(false);



        }


    }





}
















