using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager3 : LevelManager
{
    public int maxGolemsCount, maxWraithCount;
    public int currGolemCount, currWraithCount;
    // Start is called before the first frame update
    void Start()
    {
        currGolemCount = 0;
        currWraithCount = 0;
        LevelManager.CurrCheckPoint = intialCheckPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
