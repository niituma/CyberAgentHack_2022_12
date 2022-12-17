using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CleanCity
{
    public class GarbagePlace : MonoBehaviour
    {
        private List<Garbage> garbages = new List<Garbage>();
        
        /// <summary>拾ったごみを頭にのせる</summary>
        public void PickUp(Garbage garbage)
        {
            float height = 0;
            foreach(Garbage g in garbages)
            {
                height += g.Size.y;
            }
            garbages.Add(garbage);
            garbage.transform.SetParent(transform);
            garbage.transform.localPosition = new Vector3(0, height, 0);
		}

        public void Clear()
        {
            garbages.Clear();
		}
    }
}