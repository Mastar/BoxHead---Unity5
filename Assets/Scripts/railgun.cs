using UnityEngine;
using System.Collections;

public class railgun : Weapon{

    private int damages = 100;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }
    public override void Fire()
     {
        
        if (Time.time > lastFire + fireRate && ammo > 0)
        {
            ammo--;
            lastFire = Time.time;
            animator.SetTrigger("shoot");

            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            }

            Ray ray = new Ray(Camera.main.transform.position + Camera.main.transform.forward / 2, Camera.main.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.GetComponent<Health>() != null)
                {
					Rigidbody rigid = hit.collider.gameObject.GetComponent<Rigidbody>();
					if (rigid != null)
					{
						hit.collider.gameObject.GetComponent<bot>().Eject();

						rigid.AddForce(hit.collider.gameObject.transform.forward * -3000);
					}
					hit.collider.gameObject.GetComponent<Health>().TakeDamages(damages);
                }

            }
        }

                //GameObject b = ObjectPool.instance.GetObjectForType(projectile, true);

                //if (b != null)
                //{
                //    if (audio != null)
                //    {
                //        audio.PlayOneShot(audio.clip);
                //    }

                //    b.transform.position = bulletStartPosition.position;
                //    b.transform.LookAt(firstHit.point);
                //}
                //else
                //{
                //    Debug.Log("Pool vide");
                //}
          
            
        }
}
