using CleanCity;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class ShowScoreView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _scoreText;
    [SerializeField]
    TextMeshProUGUI _moneyText;
    [SerializeField]
    Slider _quotaSlider;
    // アニメーション時に使用する一時的な現在値
    int _scoreCurrentValue;
    int _moneyCurrentValue;
    bool _scoreAnim;
    bool _moneyAnim;
    Tween _countAnim;

    public void ResetSlider()
    {
        SetCountValue(0, 0.2f);
    }

    public void SetScoreText(int value, float time)
    {
        DOTween.To(() => _scoreCurrentValue,
                value =>
                {
                    // 背景バーはアニメーションで更新
                    _scoreCurrentValue = value;
                    _scoreText.text = $"SCORE:{_scoreCurrentValue}";
                },value, time);
        if (!_scoreAnim) { _scoreText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _scoreAnim = false); }

        _scoreAnim = true;
    }
    public void SetMoneyText(int value, float time)
    {
        DOTween.To(() => _moneyCurrentValue,
                value =>
                {
                    // 背景バーはアニメーションで更新
                    _moneyCurrentValue = value;
                    _moneyText.text = $"MONEY:{_moneyCurrentValue}";
                }, value, time);
        if (!_moneyAnim) { _moneyText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _scoreAnim = false); }

        _moneyAnim = true;
    }

    public void SetCountValue(float value, float time)
    {
        Debug.Log(value);
        
        if (_countAnim is not null) { _countAnim.Kill(); }
        _countAnim = DOTween.To(() => _quotaSlider.value, x => _quotaSlider.value = x, value, time);
    }
}
