using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftBoundary;
    public static float rightBoundary;
    public static float frontBoundary;
    public static float rearBoundary;

    public float leftLimit;
    public float rightLimit;

    void Update()
    {
        leftBoundary = transform.localScale.x / -2;
        rightBoundary = transform.localScale.x / 2;
        leftLimit = leftBoundary;
        rightLimit = rightBoundary;

        frontBoundary = transform.localScale.z / 2;
        rearBoundary = transform.localScale.z / -2;
    }
}


