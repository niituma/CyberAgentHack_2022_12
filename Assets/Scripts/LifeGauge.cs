using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace CleanCity_UI
{
    public class LifeGauge : MonoBehaviour
    {
        [SerializeField]
        Image[] _hearts;
        // Start is called before the first frame update
        void Awake()
        {
            Locator<LifeGauge>.Register(this);
        }

        public void SetDamageLifeGauge()
        {
            foreach (var heart in _hearts)
            {
                if (!heart.gameObject.activeSelf) { continue; }
                heart.gameObject.SetActive(false);
                break;
            }
        }

        public void SetHeelLifeGauge()
        {
            foreach (var heart in _hearts)
            {
                if (heart.gameObject.activeSelf) { continue; }
                heart.gameObject.SetActive(true);
                break;
            }
        }
    }
}