using UnityEngine;

namespace CleanCity
{
    [CreateAssetMenu(fileName = "GarbageDatabase", menuName = "CleanCity/GarbageDatabase")]
    public class GarbageDatabase : ScriptableObject, IGarbageDatabase
    {
        [SerializeField] private Garbage[] garbages;

		/// <summary>ランダムにゴミを取得</summary>
		public Garbage CreateRandomGarbage()
		{
			return Instantiate(garbages[Random.Range(0, garbages.Length)]);
		}
	}
}