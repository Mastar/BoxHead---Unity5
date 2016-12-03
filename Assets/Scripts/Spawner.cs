using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float spawnRate = 1f;
    float lastSpawn=0f;

    bool active = true;
    public GameObject player;

    public string botType = "BotZombie";
	// Use this for initialization
    
    void Start() {
    
    }
	
	// Update is called once per frame
	void Update () {

       // bool visible = Camera.main.WorldToViewportPoint(transform.position).x > 0 && Camera.main.WorldToViewportPoint(transform.position).y > 0 && Camera.main.WorldToViewportPoint(transform.position).x < 1 && Camera.main.WorldToViewportPoint(transform.position).y < 1;
        if (active && Time.time > lastSpawn + spawnRate)
        {
            lastSpawn = Time.time;
            GameObject spawn = ObjectPool.instance.GetObjectForType(botType,false);

            spawn.GetComponent<Rigidbody>().velocity = Vector3.zero;
            spawn.transform.position = transform.position;
            spawn.transform.rotation = transform.rotation;
            
            bot leBot = spawn.GetComponent<bot>();
            leBot.player = player;
            
            //bot leBot = ((GameObject)Instantiate(Resources.Load(botType), transform.position, transform.rotation)).GetComponent<bot>();

        }
    }

    void OnBecameInvisible() {
        active = true;
    }

    void OnBecameVisible()
    {
        active = false;
    }
}
