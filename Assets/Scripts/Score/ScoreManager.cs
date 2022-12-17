using System;
using CleanCity.UI;
using Utility;

namespace CleanCity
{
    public class ScoreManager : IScoreManager
    {
        private int score;
        private int clearedGarbage;

		/// <summary>スコア取得</summary>
		public int GetScore => score;

		/// <summary>処理したごみの数取得</summary>
		public int GetClearedGarbage => clearedGarbage;

		/// <summary>スコアが追加されたときのコールバック</summary>
		public event Action<(int nowScore, int addScore)> OnAddScore;
		public event Action<int> OnAddClearedGarbage;

		/// <summary>スコアを追加する</summary>
		public void AddScore(int score)
        {
            this.score += score;
            Locator<ShowScorePresenter>.Resolve().ScoreShow(this.score);
            OnAddScore?.Invoke((this.score, score));
		}

		/// <summary>処理したごみの数を追加</summary>
		public void AddClearedGarbage()
		{
			clearedGarbage++;
			OnAddClearedGarbage?.Invoke(clearedGarbage);
		}
	}
}