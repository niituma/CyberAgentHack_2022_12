using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    // �A�j���[�V�������Ɏg�p����ꎞ�I�Ȍ��ݒl
    int _tempCurrentValue;
    public void SetScoreText(int value, float time)
    {
        DOTween.To(() => _tempCurrentValue,
                value =>
                {
                    // �w�i�o�[�̓A�j���[�V�����ōX�V
                    _tempCurrentValue = value;
                    _text.text = $"Score:{_tempCurrentValue}";
                },
                value, time);
        transform.DOShakeScale(duration: time, strength: 0.3f);
    }
}
