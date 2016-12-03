using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayerSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
		if (isLocalPlayer){
			//GetComponent<>().setActive(true);
			GetComponent<playerMovement>().enabled = true;
			GetComponent<playerShooting>().enabled = true;
		}
	}
	

}
