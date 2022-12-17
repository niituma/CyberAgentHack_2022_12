﻿using UniRx;
using UnityEngine;
using Utility;

namespace CleanCity.UI
{
    public class ShowScorePresenter : MonoBehaviour
    {
        [SerializeField] ShowScoreView _view;
        [SerializeField] float _time = 1f;
        [SerializeField] bool _startShow = false;
        ShowScoreModel _model = new ShowScoreModel();


        private void Awake()
        {
            Locator<ShowScorePresenter>.Register(this);
        }
        void Start()
        {
            
            if (_startShow) { ScoreShow(Locator<IScoreManager>.Resolve().GetScore); }//仮の値を入れてる最終的にはゲーム終了までの総合得点を入れる
        }

        /// <summary>
        /// scoreを更新してTextに表示する
        /// </summary>
        /// <param name="value"></param>
        public void ScoreShow(int value)
        {
            _model.SetScoreValue(value);
            _model.CurrentScoreChanged.
            First().Subscribe(value => _view.SetScoreText(value, _time));
        }

        public void CountShow(int value)
        {
            _model.SetCountValue(value);
            _model.CurrentCountChanged.
            First().Subscribe(value => _view.SetCountText(value, _time));
        }
    }
}