using System;
using UniRx;

public class ShowScoreModel
{
    public int Score { get => _score.Value; set => _score.Value = value; }
    public IObservable<int> CurrentScoreChanged => _score;
    readonly ReactiveProperty<int> _score = new();

    public int Money { get => _money.Value; set => _money.Value = value; }
    public IObservable<int> CurrentMoneyChanged => _money;
    readonly ReactiveProperty<int> _money = new();

    public void SetScoreValue(int value)
    {
        _score.Value = value;
    }

    public void SetMoneyValue(int value)
    {
        _money.Value = value;
    }
}
