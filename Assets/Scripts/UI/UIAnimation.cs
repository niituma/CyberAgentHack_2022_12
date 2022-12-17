using DG.Tweening;
using UnityEngine;


public class UIAnimation : MonoBehaviour
{
    Tween _tween;
    public void OpenWindow()
    {
        if (_tween is not null) { _tween.Kill(); }
        transform.localScale = Vector3.zero;
        _tween = WindowAnim(1, 1, Ease.OutBounce, true);
        _tween.Play();
    }
    public void CloseWindow()
    {
        if (_tween is not null) { _tween.Kill(); }
        transform.localScale = Vector3.one;
        _tween = WindowAnim(0, 0.5f, Ease.Unset, false);
        _tween.Play();
    }

    Tween WindowAnim(float xsize, float _time, Ease ease, bool active)
    {
        return transform.DOScale(xsize, _time).SetEase(ease).OnComplete(() => { if (!active) { this.gameObject.SetActive(false); } });
    }
}
