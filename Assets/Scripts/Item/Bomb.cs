using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CleanCity
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private ParticleSystem humanExplosionPrefab;
        [SerializeField] private ParticleSystem explosion;

        public void Use()
        {
            IEnemySpawnSystem enemySpawnSystem = Locator<IEnemySpawnSystem>.Resolve();
            explosion.Play();
            foreach (GameObject enemy in enemySpawnSystem.GetAliveEnemies())
            {
                Vector3 position = enemy.transform.position;
                Instantiate(humanExplosionPrefab, position, Quaternion.identity);
                Destroy(enemy);
            }
		}

		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.Space))
            {
                Use();
			}
		}
	}
}