using UniRx;
using UnityEngine;
using Utility;
using static UnityEngine.Rendering.DebugUI;

namespace CleanCity.UI
{
    public class ShowScorePresenter : MonoBehaviour
    {
        [SerializeField] ShowScoreView _view;
        [SerializeField] float _time = 1f;
        [SerializeField] bool _startShow = false;
        ShowScoreModel _model = new ShowScoreModel();

        void Start()
        {
            Locator<IWaveSystem>.Resolve().OnAddWave += (num) =>
            {
                _model.Count = 0;
                CountShow(0);
            };

            Locator<IScoreManager>.Resolve().OnAddScore += (value) =>
            {
                ScoreShow(value.nowScore);
            };

            Locator<IScoreManager>.Resolve().OnAddClearedGarbage += (num) =>
            {
                var quota = (float)Locator<IQuota>.Resolve().GetNextQuota(Locator<IWaveSystem>.Resolve().GetWave);
                Debug.Log(Locator<IQuota>.Resolve().GetNextQuota(Locator<IWaveSystem>.Resolve().GetWave));
                if(_model.Count + 1 > quota) { return; }
                _model.Count++;
                CountShow(_model.Count / quota);
            };

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

        public void CountShow(float value)
        {
            _view.SetCountText(value, 0.4f);
        }
    }
}