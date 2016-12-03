using UnityEngine;
using System.Collections;

public class fpsCounter : MonoBehaviour {

    GUIText text;
	// Use this for initialization
	void Start () {
        text = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {

        text.text = (1 / Time.deltaTime).ToString();
	}
}
