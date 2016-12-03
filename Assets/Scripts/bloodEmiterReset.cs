using UnityEngine;
using System.Collections;

public class bloodEmiterReset : MonoBehaviour {

	void OnEnable(){
		StartCoroutine("delayPool");
	}

	private IEnumerator delayPool()
	{
		
		yield return new WaitForSeconds(3f);		
		ObjectPool.instance.PoolObject(gameObject);
		StopCoroutine("delayPool");
	}
}
