using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

	public GameObject cam;




	public override void OnStartServer()
	{
		Debug.Log("Starting Server"  + isLocalPlayer);
	}

	public override void OnStartClient()
	{
		Debug.Log("Starting Client"  + isLocalPlayer);
	}

	void Awake()
	{
		Debug.Log("Awaking Player " + isLocalPlayer);
	}



 





	// Use this for initialization
	void Start () 
	{
		if(isLocalPlayer)
		{
			GetComponent<PlayerController>().enabled = true;
			cam.SetActive(true);
		}
		else
		{
			GetComponent<PlayerController>().enabled = false;
			cam.SetActive(false);
			GetComponent<setupPlayer>().enabled = false;
		}
		Debug.Log("Starting Player " + isLocalPlayer);

		 
	}


	
}
