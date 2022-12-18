using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace CleanCity
{
  public class EnemySpawnSystem : MonoBehaviour, IEnemySpawnSystem
  {
    [SerializeField] private List<EnemySpawnData> enemyDataList;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<Transform> exitPoints;

    private int maxEnemyCount = 5;
    private float spawnTimeSpan = 1.5f;
    private List<GameObject> enemies = new List<GameObject>();
    private float timeLeft = 0;

    private void Start()
    {
      var waveSystem = Locator<IWaveSystem>.Resolve();
      waveSystem.OnAddWave += OnAddWave;
      Locator<IEnemySpawnSystem>.Register(this);
    }

    private void OnAddWave(int wave)
    { 
      var quota = Locator<IQuota>.Resolve();
      maxEnemyCount = quota.GetNextMaxSpawnCount(wave);
      spawnTimeSpan = quota.GetNextSpawnTimeSpan(wave);
    }

    private void Update()
    {
      if (!IsSpawnState(GameSystem.Singleton.Status))
      {
        return;
      }
      
      // 時間を更新
      timeLeft -= Time.deltaTime;
      
      // 時間が0以下なら敵をスポーンする
      if (timeLeft <= 0)
      {
        SpawnEnemy();
        timeLeft = GetNextTimeSpan();
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
    private (Transform start, Transform dest)? GetRandomPath()
    {
      for (int i = 0; i < 100; i++)
      {
        var start = spawnPoints[Random.Range(0, spawnPoints.Count)];
        var dest = exitPoints[Random.Range(0, exitPoints.Count)];
        if (Vector3.Distance(start.position, dest.position) > 10f)
        {
          return (start, dest);
        }
      }
      return null;
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
      var path = GetRandomPath();
      if (path == null)
      {
        Debug.LogWarning("Failed to spawn enemy.");
        return;
      }
      
      var (spawnPos, dest) = path.Value;
      
      // 敵を生成
      var enemy = Instantiate(enemyData.prefab, spawnPos.position, Quaternion.identity);
      enemies.Add(enemy);
      
      // 行き先を設定
      var moveDir = enemy.GetComponent<ISetEnemyMoveDir>();
      moveDir.SetMoveDistination(dest.position);
    }

    public List<GameObject> GetAliveEnemies()
    {
      // 敵のリストを更新する
      enemies = enemies.Where(v => v != null).ToList();
      return enemies;
    }
  }
}