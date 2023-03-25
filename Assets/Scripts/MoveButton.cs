using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public void GoToRoom1()
    {
        SceneLoader.Instance.Load("Room_1");
    }
    
    public void GoToRoom2()
    {
        SceneLoader.Instance.Load("Room_2");
    }
    
    public void GoToRoom3()
    {
        SceneLoader.Instance.Load("Room_3");
    }
}
