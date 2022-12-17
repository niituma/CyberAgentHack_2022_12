using System;
using CleanCity.UI;
using Utility;

namespace CleanCity
{
    public class ScoreManager : IScoreManager
    {
        private int score;

        /// <summary>スコア取得</summary>
        public int GetScore => score;

        /// <summary>スコアが追加されたときのコールバック</summary>
        public event Action<(int nowScore, int addScore)> OnAddScore;

        /// <summary>スコアを追加する</summary>
        public void AddScore(int score)
        {
            this.score += score;
            Locator<ShowScorePresenter>.Resolve().ScoreShow(this.score);
            OnAddScore?.Invoke((this.score, score));
		}
    }
}