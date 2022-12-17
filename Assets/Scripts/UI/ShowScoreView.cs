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
    // �A�j���[�V�������Ɏg�p����ꎞ�I�Ȍ��ݒl
    int _scoreCurrentValue;
    int _countCurrentValue;
    bool _scoreAnim;
    bool _countAnim;
    [SerializeField] TextMeshProUGUI _text;
    int _tempCurrentValue;
    public void SetScoreText(int value, float time)
    {
        DOTween.To(() => _scoreCurrentValue,
                value =>
                {
                    // �w�i�o�[�̓A�j���[�V�����ōX�V
                    _scoreCurrentValue = value;
                    _scoreText.text = $"Score:{_scoreCurrentValue}";
                    _tempCurrentValue = value;
                    _text.text = $"Score:{_tempCurrentValue}";
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
                    // �w�i�o�[�̓A�j���[�V�����ōX�V
                    _countCurrentValue = value;
                    _countText.text = $"Score:{_countCurrentValue}";
                },
                value, time);
        if (!_countAnim) { _countText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _countAnim = false); }

        _countAnim = true;
    }
}
