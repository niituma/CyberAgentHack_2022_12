using UnityEngine;

namespace CleanCity
{
  [CreateAssetMenu(fileName = "Enemy", menuName = "CleanCity/EnemySpawnData")]
  public class EnemySpawnData : ScriptableObject
  {
    public float probability;
    public GameObject prefab;
  }
}