using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesProvider : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    public IReadOnlyList<Enemy> Enemies => _enemies;

    public void ReviveAll()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Revive();
        }
    }
}
