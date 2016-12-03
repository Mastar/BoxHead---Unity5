using UnityEngine;
using System.Collections;

public class playerHp : MonoBehaviour {

	public delegate void HPChanged(int hp);
	public static event HPChanged HPChangedAction;

    private int hp = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamages(int damages)
    {
		if (HPChangedAction!=null)
			HPChangedAction(hp-damages);
        hp -= damages;
        if (hp <= 0) {
            gameObject.GetComponent<Partie>().GameOver();
        
        }
    }
}
