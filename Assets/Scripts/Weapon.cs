using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public float fireRate;
    public int ammoMax;
    public int ammo;
    // public float damages;
    //  float range = 120;
    protected float lastFire = 0f;
    public Transform bulletStartPosition;
    public string projectile;
    AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Fire()
    {
        if (Time.time > lastFire + fireRate && ammo > 0)
        {
            ammo--;
            lastFire = Time.time;


            Ray ray = new Ray(Camera.main.transform.position + Camera.main.transform.forward / 2, Camera.main.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            if (hits.Length > 0)
            {
                float distanceMin = hits[0].distance;
                RaycastHit firstHit = hits[0];
                foreach (RaycastHit hit in hits)
                {
                    if (hit.distance < distanceMin)
                    {
                        distanceMin = hit.distance;
                        firstHit = hit;
                    }

                }


                GameObject b = ObjectPool.instance.GetObjectForType(projectile, true);

                if (b != null)
                {
                    if (audio != null)
                    {
                        audio.PlayOneShot(audio.clip);
                    }

                    b.transform.position = bulletStartPosition.position;
                    b.transform.LookAt(firstHit.point);
                }
                else
                {
                    Debug.Log("Pool vide");
                }
            }
            else
            { //on tire dans le vide
                GameObject b = ObjectPool.instance.GetObjectForType(projectile, true);

                if (b != null)
                {
                    if (audio != null)
                    {
                        audio.PlayOneShot(audio.clip);
                    }
                    b.transform.position = bulletStartPosition.position;
                    b.transform.rotation = Camera.main.transform.rotation;

                }

            }

            //GameObject b = ObjectPool.instance.GetObjectForType(projectile, true);

            //if (b != null)
            //{
            //    if (audio != null)
            //    {
            //        audio.PlayOneShot(audio.clip);
            //    }
            //     Debug.Log(bulletStartPosition.position);


            //    b.transform.position = bulletStartPosition.position;
            //    b.transform.rotation = Camera.main.transform.rotation;
            //}


            //RaycastHit[] hits = Physics.RaycastAll(ray, range);
            //if (hits.Length > 0)
            //{
            //    float distanceMin = hits[0].distance;
            //    RaycastHit firstHit = hits[0];
            //    foreach (RaycastHit hit in hits)
            //    {
            //        if (hit.distance < distanceMin)
            //        {
            //            distanceMin = hit.distance;
            //            firstHit = hit;
            //        }

            //    }

            //Health health = firstHit.collider.gameObject.GetComponent<Health>();
            //if (health != null)
            //{
            //    health.TakeDamages(damages);
            // Debug.Log("Touché");
            //}
            //}
            //Debug.Log("pan");
        }
    }
}
