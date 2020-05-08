﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps GameObject on screen 
/// Notes that this is only works for an orthographic MainCamera at [0,0,0].
/// </summary>

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;

    [Header("Set Dynamically")]
    public float camWidth;
    public float camHeight;

    void Awake ()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
        }

        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
        }

        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
        }

        if (pos.y < - camHeight + radius)
        {
            pos.y = -camHeight + radius;
        }

        transform.position = pos;
    }

    void OnDrawGizmos ()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, .1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }

}
