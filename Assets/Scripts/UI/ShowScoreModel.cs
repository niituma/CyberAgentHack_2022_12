using System;
using UniRx;

public class ShowScoreModel
{
    public int Score { get => _score.Value; set => _score.Value = value; }
    public IObservable<int> CurrentScoreChanged => _score;
    readonly ReactiveProperty<int> _score = new();

    public float Count { get => _count.Value; set => _count.Value = value; }
    public IObservable<float> CurrentCountChanged => _count;
    readonly ReactiveProperty<float> _count = new();

    public void SetScoreValue(int value)
    {
        _score.Value = value;
    }

    public void SetCountValue(float value)
    {
        _count.Value = value;
    }
}
