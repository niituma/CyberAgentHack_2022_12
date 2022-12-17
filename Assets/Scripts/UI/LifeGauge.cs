using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace CleanCity_UI
{
    public class LifeGauge : MonoBehaviour
    {
        [SerializeField, Tooltip("HPのUIのPrefab")]
        Image[] _hearts;
        [SerializeField, Tooltip("スケール変える大きさ")]
        float _panchScale = 1.1f;
        [SerializeField,Tooltip("UIのアニメーションする時間")]
        float _motionTime = 1f;

        // Start is called before the first frame update
        void Awake()
        {
            Locator<LifeGauge>.Register(this);
        }

        /// <summary>
        /// HPのUIを1つ消す
        /// </summary>
        public void SetDamageLifeGauge(int point)
        {
            for (int i = 0; i < point; i++)
            {
                foreach (var heart in _hearts)
                {
                    if (!heart.gameObject.activeSelf) { continue; }
                    
                    DOTween.Sequence()
                        .Append(transform.DOScale(Vector3.one, 0))//スケールを初期化
                        .Append(transform.DOPunchScale(new Vector3(_panchScale, _panchScale, _panchScale), _motionTime));
                    heart.gameObject.SetActive(false);
                    break;
                }
            }
        }

        /// <summary>
        /// HPのUIを1つ増やす
        /// </summary>
        public void SetHeelLifeGauge(int point)
        {
            for (int i = 0; i < point; i++)
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
}