using UnityEngine;
using System.Collections;

public class botDevil : MonoBehaviour {

    private Animator animator;
    float lastHit;
    float delay = 6f;

    
	// Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }
	void OnEnable() {
        lastHit = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > lastHit + delay) {
            lastHit = Time.time;
            animator.SetTrigger("fire");
            StartCoroutine("fire");
        }
	}

    private IEnumerator fire()
    {

        yield return new WaitForSeconds(0.3f);
        GameObject b = ObjectPool.instance.GetObjectForType("rocket", true);

        if (b != null)
        {
            // Debug.Log(bulletStartPosition.position);
            b.transform.position = gameObject.transform.position + gameObject.transform.forward + gameObject.transform.up;
            b.transform.rotation = gameObject.transform.rotation;
            //b.SetActive(true);
            // Debug.Log(b.transform.position);
        }
        StopCoroutine("fire");
    }
}
