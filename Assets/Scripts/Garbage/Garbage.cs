using System;
using UnityEngine;

namespace CleanCity
{
    public class Garbage : MonoBehaviour
    {
        [SerializeField] private float weight = 10;
        [SerializeField] private int score = 100;
        [SerializeField] Vector3 size;

        public float Weight => weight;
        public int Score => score;
        public Vector3 Size => size;

        public event Action OnDestroyEvent;

        public bool IsPickedUp { get; private set; }

        public void OnPickUp()
        {
            IsPickedUp = true;
        }

		private void OnDestroy()
		{
            OnDestroyEvent?.Invoke();
        }
	}
}