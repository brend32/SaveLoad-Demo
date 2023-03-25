using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadedCallback : MonoBehaviour
{
    private void Start()
    {
        SceneLoader.Instance.Loaded();
    }
}
