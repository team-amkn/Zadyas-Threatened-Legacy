using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager1 : LevelManager
{
    // Start is called before the first frame update
    protected override void Start()
    {
        LevelManager.CurrCheckPoint = intialCheckPoint;
        LevelManager.leftLevelBoundary = -7.74f;
        LevelManager.rightLevelBoundary = 82.68f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
