using CleanCity;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Utility;
using static UnityEngine.Rendering.DebugUI;

namespace CleanCity_UI
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
            _model.SetValue(value);
            _model.CurrentChanged.
            First().Subscribe(value => _view.SetScoreText(value, _time));
        }
    }
}