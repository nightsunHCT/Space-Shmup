using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float rotationsPerSecond = .1f;

    [Header("Set Dynamically")]
    public int levelShown = 0;

    // this non-public variable will not apppear in inspector
    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // raad the current shiled level from the Hero Singleton
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
        // if this is different from levelShown
        
        if (levelShown != currLevel)
        {
            levelShown = currLevel;
            // ajdust the texture offset to show diff shield level
            mat.mainTextureOffset = new Vector2(.2f * levelShown, 0);
        }

        // rotate the shield a bit every frame in a time-based way
        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
