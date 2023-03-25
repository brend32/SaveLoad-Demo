using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    private bool _isAlive = true;

    private void Awake()
    {
        UpdateView();
    }

    public void Kill()
    {
        _isAlive = false;
        UpdateView();
    }

    public void Revive()
    {
        _isAlive = true;
        UpdateView();
    }

    public void RestoreState(EnemyState state)
    {
        transform.position = state.Position;
        _isAlive = state.IsAlive;
        UpdateView();
    }
    
    public EnemyState GetState()
    {
        return new EnemyState()
        {
            IsAlive = _isAlive,
            Position = transform.position
        };
    }

    private void UpdateView()
    {
        _image.color = _isAlive ? Color.green : Color.red;
    }
}
