using DG.Tweening;
using UniRx;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Utility;

namespace CleanCity.UI
{
    public class ShowScorePresenter : MonoBehaviour
    {
        [SerializeField] ShowScoreView _view;
        [SerializeField] GameObject _UIParent;

        [SerializeField] float _time = 1f;
        [SerializeField] bool _startShow = false;
        ShowScoreModel _model = new ShowScoreModel();

        void Start()
        {
            if (_startShow) { OpenUI(); }
            Locator<IScoreManager>.Resolve().OnAddScore += (value) =>
            {
                ScoreShow(value.nowScore);
            };
            
            Locator<IWaveSystem>.Resolve().OnAddWave += (num) =>
            {
                CountShow(0);
            };
            Locator<IWallet>.Resolve().OnChangeMoney += (value) =>
            {
                MoneyShow(value.nowMoney);
            };
            Locator<IScoreManager>.Resolve().OnGarbageDiscarded += () =>
            {
                var progress = Locator<IWaveSystem>.Resolve().GetWaveProgress();
                CountShow(progress);
            };
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
        public void MoneyShow(int value)
        {
            _model.SetMoneyValue(value);
            _model.CurrentMoneyChanged.
            First().Subscribe(value => _view.SetMoneyText(value, _time));
        }
        public void CountShow(float value)
        {
            _view.SetCountValue(value, 0.4f);
        }

        public void OpenUI()
        {
            _UIParent.transform.localScale = Vector3.zero;
            _UIParent.GetComponent<CanvasGroup>().alpha = 0;
            DOTween.Sequence()
                   .Append(_UIParent.transform.DOScale(1, 1f).SetEase(Ease.OutBack))
                   .Join(_UIParent.GetComponent<CanvasGroup>().DOFade(1f, 1f).SetEase(Ease.Linear))
                   .OnComplete(() => ScoreShow(Locator<IScoreManager>.Resolve().GetScore));
        }
    }
}