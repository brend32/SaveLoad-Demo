using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    public event Action OnLeavingCurrentScene;
    public event Action OnEnteringCurrentScene;
    
    public Scene? Current { get; private set; }
    
    private void Awake()
    {
        if (Instance != null)
            return;
        
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void Load(string sceneName)
    {
        OnLeavingCurrentScene?.Invoke();
        Current = SceneManager.LoadScene(sceneName, new LoadSceneParameters());
    }

    public void Loaded()
    {
        OnEnteringCurrentScene?.Invoke();
    }
}
