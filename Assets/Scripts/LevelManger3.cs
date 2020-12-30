using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger3 : LevelManger
{
    public int maxGolemsCount, maxWraithCount;
    public int currGolemCount, currWraithCount;
    // Start is called before the first frame update
    void Start()
    {
        LevelManger.CurrCheckPoint = intialCheckPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
