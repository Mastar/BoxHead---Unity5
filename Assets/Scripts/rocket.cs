using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour
{
    float velocity = 20f;
    // Use this for initialization
    int damages = 60;
    float radius = 5f;
    AudioSource audio;


    void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);

        transform.position += transform.forward * velocity * Time.deltaTime;
        //Debug.Log(transform.position);

    }

    void OnCollisionEnter(Collision col)
    {
        Explose();
    }

    void Explose() {
        if (audio != null)
        {
            Debug.Log("sons");
            audio.PlayOneShot(audio.clip);
        }
        Collider[] touchs = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider t in touchs){

            if (t.GetComponent<Collider>().gameObject.GetComponent<bot>() != null)
            {
                Rigidbody rigid = t.GetComponent<Collider>().gameObject.GetComponent<Rigidbody>();
                if (rigid != null)
                {
                    t.GetComponent<Collider>().gameObject.GetComponent<bot>().Eject();
                    rigid.AddExplosionForce(500f,new Vector3(transform.position.x,transform.position.y-2,transform.position.z),50f);

                }
            }

            Health health = t.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamages(damages);
            }

            playerHp player = t.gameObject.GetComponent<playerHp>();
            if (player != null)
            {
                player.TakeDamages(damages);
            }

            ObjectPool.instance.PoolObject(gameObject);
        
        }
    }
}
