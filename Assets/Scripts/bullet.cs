using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    float velocity = 40f;
    // Use this for initialization
    int damages = 30;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {

		playerHp health = col.collider.gameObject.GetComponent<playerHp>();

        if (col.collider.gameObject.GetComponent<bot>() != null)
        {
            Rigidbody rigid = col.collider.gameObject.GetComponent<Rigidbody>();
            if (rigid != null)
            {
                col.collider.gameObject.GetComponent<bot>().Eject();
                rigid.AddForce(transform.forward * 5);

            }
        }
        if (health != null)
        {
            health.TakeDamages(damages);

				GameObject b = ObjectPool.instance.GetObjectForType("bloodEmiter", true);
				if (b != null)
				{
					b.transform.position = transform.position;
				b.transform.forward = col.contacts[0].normal;
				//b.transform.rotation = Quaternion.FromToRotation(Vector3.right, col.contacts[0].normal);
				}
				else
				{
					Debug.Log("plus de sang");
				}

        }
        ObjectPool.instance.PoolObject(gameObject);

    }

    void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    //void OnEnable()
    //{
    //    Debug.Log(transform.position);
    //    Debug.Log(velocity);
    //    Debug.Log(Time.deltaTime);
    //}
    //void OnDisable()
    //{
    //    transform.position = Vector3.zero;
    //}
    //void Detruire()
    //{
    //    CancelInvoke("Detruire");
    //    ObjectPool.instance.PoolObject(gameObject);
    //}
}
