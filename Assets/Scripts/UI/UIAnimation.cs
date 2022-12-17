using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public void OpenWindow()
    {
        transform.localScale = Vector3.zero;
        WindowAnim(1, 1, Ease.OutBounce, true);
    }
    public void ClozeWindow()
    {
        transform.localScale = Vector3.one;
        WindowAnim(0, 0.5f, Ease.Unset, false);
    }

    void WindowAnim(float xsize, float _time, Ease ease, bool active)
    {
        transform.DOScale(xsize, _time).SetEase(ease).OnComplete(() => { if (!active) { this.gameObject.SetActive(false); } });
    }
}
