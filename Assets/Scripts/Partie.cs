using UnityEngine;
using System.Collections;

public class Partie : MonoBehaviour {

    private bool gameOver = false;
    private float timeScale;
	// Use this for initialization
	void Start () {
        timeScale = Time.timeScale;
        Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GameOver() {
        gameOver = true;
        Time.timeScale = 0;
        Screen.lockCursor = false;
        gameObject.GetComponent<playerShooting>().enabled = false;
        gameObject.GetComponent<MouseLook>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<MouseLook>().enabled = false;
    }

    void OnGUI() {
        if (gameOver) {
            GUI.Label(new Rect(Screen.width/2-50, Screen.height/3-10, 100, 20), "Game Over !");
            if (GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-25, 100, 50), "Reessayer ?"))
            {
                Time.timeScale = timeScale;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
