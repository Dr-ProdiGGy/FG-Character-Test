using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    private const int fps = 60;

    private void Awake()
    {
        Application.targetFrameRate = fps;
    }
}
