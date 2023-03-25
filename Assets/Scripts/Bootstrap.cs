using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader.Load("Room_1");
    }
}
