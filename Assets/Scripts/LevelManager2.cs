using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager2 : LevelManager
{
    public GameObject lightning;
    private float[] lightningTiming = {26.50f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.55f,
        1.55f, 1.48f, 1.52f, 1.51f, 1.51f, 1.58f, 1.44f, 1.51f, 1.5f, 1.51f, 1.51f, 1.52f, 1.51f,
        9.2f, 1.54f, 1.55f, 1.41f, 1.55f, 1.45f, 1.6f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.52f, 1.53f,
        1.45f, 1.55f};
    private int i = 0;
    public float LightningXOffset;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currLevelManger = this;
        LevelManager.leftLevelBoundary = -4.83f;
        LevelManager.rightLevelBoundary = 364f;
        LevelManager.CurrCheckPoint = intialCheckPoint;
        StartCoroutine(SummonLightning());
    }


    IEnumerator SummonLightning()
    {
        while (true)
        {
            yield return new WaitForSeconds(lightningTiming[i]);
            float startXRange = playerStats.transform.position.x;
            float endXRange = playerStats.transform.position.x + LightningXOffset;
            float XSpawnPosition = Random.Range(startXRange, endXRange);
            Vector3 spawnPosition = new Vector3(XSpawnPosition, 0.1f, 0f);
            Instantiate(lightning, spawnPosition, Quaternion.identity);
            i = ++i % lightningTiming.Length;
        }
    }

    public override void Respawn()
    {
        {
            GameObject bigMonster = GameObject.FindGameObjectWithTag("BigMonster");
            bigMonster.transform.position = new Vector3(LevelManager.CurrCheckPoint.transform.position.x - 12f, -1.55f); ;
            base.Respawn();
        }
    }

}
