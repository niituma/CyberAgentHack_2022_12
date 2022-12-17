using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScoreView : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI _scoreText;
    [SerializeField]
    TextMeshProUGUI _countText;
    // アニメーション時に使用する一時的な現在値
    int _scoreCurrentValue;
    int _countCurrentValue;
    bool _scoreAnim;
    bool _countAnim;
    public void SetScoreText(int value, float time)
    {
        DOTween.To(() => _scoreCurrentValue,
                value =>
                {
                    // 背景バーはアニメーションで更新
                    _scoreCurrentValue = value;
                    _scoreText.text = $"SCORE:{_scoreCurrentValue}";
                },
                value, time);
        if (!_scoreAnim) { _scoreText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _scoreAnim = false); }

        _scoreAnim = true;
    }

    public void SetCountText(int value, float time)
    {
        DOTween.To(() => _countCurrentValue,
                value =>
                {
                    // 背景バーはアニメーションで更新
                    _countCurrentValue = value;
                    _countText.text = $"COUNT:{_countCurrentValue}";
                },
                value, time);
        if (!_countAnim) { _countText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _countAnim = false); }

        _countAnim = true;
    }
}
