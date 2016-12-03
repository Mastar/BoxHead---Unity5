using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour {

    Vector3 direction;
    float speed = 1;

	// Use this for initialization
    void Start()
    {

    }
    void OnEnable()
    {
       // rigidbody.AddForce(new Vector3(0,1,0));
        GetComponent<Rigidbody>().velocity = Vector3.zero;
		Invoke("Detruire", 1);
	}
    //void OnDisable()
    //{
    //    CancelInvoke("Detruire");
    //}
	
	// Update is called once per frame
	void Update () {

        transform.position += transform.forward* speed * Time.deltaTime;
	}

    void Detruire()
    {
        CancelInvoke("Detruire");
        ObjectPool.instance.PoolObject(gameObject);
    }
}
