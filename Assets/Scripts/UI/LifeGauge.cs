using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace CleanCity.UI
{
    public class LifeGauge : MonoBehaviour
    {
        [SerializeField, Tooltip("HPのUIのPrefab")]
        Image[] _hearts;
        [SerializeField, Tooltip("スケール変える大きさ")]
        float _panchScale = 1.1f;
        [SerializeField, Tooltip("UIのアニメーションする時間")]
        float _motionTime = 1f;

        // Start is called before the first frame update
        void Start()
        {
            Locator<IDamageable>.Resolve().OnDamage += (point) =>
            {
                SetDamageLifeGauge(point);
            };

            Locator<IDamageable>.Resolve().OnHeal += () =>
            {
                SetHeelLifeGauge(1);
            };
        }

        /// <summary>
        /// HPのUIを消す
        /// </summary>
        public void SetDamageLifeGauge(int point)
        {
            for (int i = 0; i < point; i++)
            {
                for (int j = _hearts.Length - 1; j >= 0; j--)
                {
                    if (!_hearts[j].gameObject.activeSelf) { continue; }

                    DOTween.Sequence()
                        .Append(transform.DOScale(Vector3.one, 0))//スケールを初期化
                        .Append(transform.DOPunchScale(new Vector3(_panchScale, _panchScale, _panchScale), _motionTime));
                    _hearts[j].gameObject.SetActive(false);
                    break;
                }
            }
        }

        /// <summary>
        /// HPのUIを増やす
        /// </summary>
        public void SetHeelLifeGauge(int point)
        {
            for (int i = 0; i < point; i++)
            {
                for (int j = _hearts.Length - 1; j >= 0; j--)
                {
                    if (_hearts[j].gameObject.activeSelf) { continue; }
                    _hearts[j].gameObject.SetActive(true);
                    DOTween.Sequence()
                       .Append(_hearts[j].transform.DOScale(Vector3.one, 0))//スケールを初期化
                       .Append(_hearts[j].transform.DOPunchScale(new Vector3(_panchScale, _panchScale, _panchScale), _motionTime));
                    break;
                }
            }
        }
    }
}