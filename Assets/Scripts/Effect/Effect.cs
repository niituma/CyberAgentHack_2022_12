using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1;

	private void Start()
	{
		StartCoroutine(WaitLifeTime());
	}

	private IEnumerator WaitLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
    }
}
