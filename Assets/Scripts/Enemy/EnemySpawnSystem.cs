using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CleanCity
{
  public class EnemySpawnSystem : MonoBehaviour
  {
    [SerializeField] private List<EnemySpawnData> enemyDataList;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<Transform> exitPoints;

    private int maxEnemyCount = 5;
    private float spawnTimeSpan = 3;
    private List<GameObject> enemies = new List<GameObject>();

    private void Update()
    {
      if (!IsSpawnState(GameSystem.Singleton.Status))
      {
        return;
      }
      
      // 時間を更新
      spawnTimeSpan -= Time.deltaTime;
      
      // 時間が0以下なら敵をスポーンする
      if (spawnTimeSpan <= 0)
      {
        SpawnEnemy();
        spawnTimeSpan = GetNextTimeSpan();
      }
    }
    
    private static bool IsSpawnState(GameSystem.State status)
    {
      return status is GameSystem.State.Menu or GameSystem.State.InGame;
    }

    /// <summary>
    /// 次に敵をスポーンさせるまでの間隔を返す
    /// </summary>
    /// <returns></returns>
    private float GetNextTimeSpan()
    {
      return spawnTimeSpan;
    }

    /// <summary>
    /// 敵のスポーン場所とゴールのペアをランダムに取得する
    /// </summary>
    /// <returns></returns>
    private (Transform start, Transform dest) GetRandomPath()
    {
      var start = spawnPoints[Random.Range(0, spawnPoints.Count)];
      var dest = exitPoints[Random.Range(0, exitPoints.Count)];
      return (start, dest);
    }

    /// <summary>
    /// 出現させる敵をランダムに取得する
    /// </summary>
    /// <returns></returns>
    private EnemySpawnData GetRandomEnemyData()
    {
      var sumProb = enemyDataList.Select(v => v.probability).Sum();

      var rand = Random.Range(0, sumProb);
      var sum = 0f;
      
      foreach (var data in enemyDataList)
      {
        if (sum <= rand && rand <= sum + data.probability)
        {
          return data;
        }
        sum += data.probability;
      }
      return null;
    }

    private void SpawnEnemy()
    {
      // 敵のリストを更新する
      enemies = enemies.Where(v => v != null).ToList();
      
      // 最大数敵が存在するならスポーンしない
      if (enemies.Count >= maxEnemyCount)
      {
        return;
      }

      // ランダムに敵を選ぶ
      var enemyData = GetRandomEnemyData();
      if (enemyData == null)
      {
        Debug.LogError("Failed to select enemy");
        return;
      }

      // スポーン地点とゴールを取得する
      var (spawnPos, dest) = GetRandomPath();
      
      // 敵を生成
      var enemy = Instantiate(enemyData.prefab, spawnPos.position, Quaternion.identity);
      enemies.Add(enemy);
      
      // 行き先を設定
      var moveDir = enemy.GetComponent<ISetEnemyMoveDir>();
      moveDir.SetMoveDistination(dest.position);
    }
  }
}