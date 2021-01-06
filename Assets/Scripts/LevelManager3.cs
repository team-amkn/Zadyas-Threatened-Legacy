using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager3 : LevelManager
{
    public int maxGolemsCount, maxWraithCount;
    public int currGolemCount, currWraithCount;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currLevelManger = this;
        currGolemCount = 0;
        currWraithCount = 0;
        LevelManager.CurrCheckPoint = intialCheckPoint;
        LevelManager.leftLevelBoundary = -9.29f;
        LevelManager.rightLevelBoundary = 5.83f;
    }


}
