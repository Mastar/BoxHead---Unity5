using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    // Use this for initialization
    private float hp = 60;
  //  public bool invulnerability = false;




    public float getHP() {
        return hp;
    }

    public void TakeDamages(float damages)
    {
        //if (!invulnerability)
        //{

            hp -= damages;

            
            if (hp <= 0)
            {
                gameObject.GetComponent<Rigidbody>().freezeRotation = false;

                //Destroy(gameObject, 2);
                StartCoroutine("delayPool");
                gameObject.GetComponent<bot>().enabled = false;

                this.enabled = false;
            }
        //}
    }

    private IEnumerator delayPool()
    {
        
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        gameObject.GetComponent<bot>().enabled = true;

        ObjectPool.instance.PoolObject(gameObject);
        StopCoroutine("delayPool");
    }
}
