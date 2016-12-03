using UnityEngine;
using System.Collections;

public class bot : MonoBehaviour
{

    public GameObject player;
    public float vspeed = 5f;

    public int damages;
    public float delay = 1f;
    private float lastHit = 0f;

    bool control = true;

    // Use this for initialization
    void OnEnable()
    {
        control = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));
        if (control)
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * vspeed;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (GetComponent<Health>().getHP() > 0)
        {
            if (col.gameObject.name == "Sol")
            {
                control = true;
            }
            else if (col.gameObject.name == "Player" && Time.time > lastHit + delay)
            {
                col.gameObject.GetComponent<playerHp>().TakeDamages(damages);
                lastHit = Time.time;
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (GetComponent<Health>().getHP() > 0)
        {
            if (col.gameObject.name == "Sol")
            {
                control = true;
            }
            else if (col.gameObject.name == "Player" && Time.time > lastHit + delay)
            {
                col.gameObject.GetComponent<playerHp>().TakeDamages(damages);
                lastHit = Time.time;
            }
        }
    }

    public void Eject() {
        control = false;
    } 

}
