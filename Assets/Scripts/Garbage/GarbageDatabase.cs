using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace CleanCity
{
    [CreateAssetMenu(fileName = "GarbageDatabase", menuName = "CleanCity/GarbageDatabase")]
    public class GarbageDatabase : ScriptableObject, IGarbageDatabase
    {
        [SerializeField] private Garbage[] garbages;

		private List<Garbage> garbageInstances = new List<Garbage>();

		/// <summary>ランダムにゴミを取得</summary>
		public Garbage CreateRandomGarbage()
		{
			Garbage garbageInstance = Instantiate(garbages[Random.Range(0, garbages.Length)]);
			garbageInstances.Add(garbageInstance);
			garbageInstance.OnDestroyEvent += () => garbageInstances.Remove(garbageInstance);
			return garbageInstance;
		}

		public ReadOnlyCollection<Garbage> GetGarbageInstances()
		{
			return garbageInstances.AsReadOnly();
		}
	}
}