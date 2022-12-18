using System.Collections.Generic;
using UnityEngine;

namespace CleanCity
{
  public interface IEnemySpawnSystem
  {
    /// <summary>
    /// 生存している敵のリストを取得する
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetAliveEnemies();
  }
}