using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveLoadService : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;
    
    private readonly Dictionary<string, List<EnemyState>> _enemiesStates = new();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _loader.OnLeavingCurrentScene += OnLeavingScene;
        _loader.OnEnteringCurrentScene += OnEnteringCurrentScene;
    }

    private void OnDestroy()
    {
        _loader.OnLeavingCurrentScene -= OnLeavingScene;
        _loader.OnEnteringCurrentScene -= OnEnteringCurrentScene;
    }

    private void OnLeavingScene()
    {
        Save();
    }

    private void OnEnteringCurrentScene()
    {
        Restore();
    }

    private void Save()
    {
        if (_loader.Current == null)
            return;
        
        var enemiesProvider = FindObjectOfType<EnemiesProvider>();
        if (enemiesProvider == null)
            return;
        
        _enemiesStates.TryAdd(_loader.Current.Value.name, new List<EnemyState>());
        var list = _enemiesStates[_loader.Current!.Value.name];
        
        list.Clear();
        list.AddRange(enemiesProvider.Enemies.Select(enemy => enemy.GetState()));
    }

    private void Restore()
    {
        if (_loader.Current == null)
            return;
        

        var enemiesProvider = FindObjectOfType<EnemiesProvider>();
        if (enemiesProvider == null)
            return;

        if (_enemiesStates.TryGetValue(_loader.Current.Value.name, out var list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                enemiesProvider.Enemies[i].RestoreState(list[i]);
            }
        }
    }
}
