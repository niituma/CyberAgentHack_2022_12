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
    Slider _quotaSlider;
    // �A�j���[�V�������Ɏg�p����ꎞ�I�Ȍ��ݒl
    int _scoreCurrentValue;
    bool _scoreAnim;
    Tween _countAnim;

    public void ResetSlider()
    {
        SetCountText(0, 0.2f);
    }

    public void SetScoreText(int value, float time)
    {
        DOTween.To(() => _scoreCurrentValue,
                value =>
                {
                    // �w�i�o�[�̓A�j���[�V�����ōX�V
                    _scoreCurrentValue = value;
                    _scoreText.text = $"SCORE:{_scoreCurrentValue}";
                },value, time);
        if (!_scoreAnim) { _scoreText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _scoreAnim = false); }

        _scoreAnim = true;
    }

    public void SetCountText(float value, float time)
    {
        if (_countAnim is not null) { _countAnim.Kill(); }
        _countAnim = DOTween.To(() => _quotaSlider.value, x => _quotaSlider.value = x, value, time);
    }
}
