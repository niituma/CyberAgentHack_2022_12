using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;
using static UnityEngine.Rendering.DebugUI;

namespace CleanCity_UI
{
    public class ShowScore : MonoBehaviour
    {
        [SerializeField] float _time = 1f;
        [SerializeField] TextMeshProUGUI _text;
        [SerializeField] bool _startShow = false;
        int _score;

        public int Score
        {
            private set
            {
                _score = value;
                _text.text = $"SCORE:{_score}";
            }
            get { return _score; }
        }

        private void Awake()
        {
            Locator<ShowScore>.Register(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            if (_startShow) { ScoreShow(Score + 10); }
        }

        /// <summary>
        /// scoreを更新してTextに表示する
        /// </summary>
        /// <param name="value"></param>
        public void ScoreShow(int value)
        {
            DOTween.Sequence()
                .Append(DOTween.To(() => Score, num => Score = num, value, _time))
                .Join(transform.DOShakeScale(duration: _time, strength: 0.3f));
        }
    }
}