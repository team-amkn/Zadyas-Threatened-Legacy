using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float CameraSpeed;

    public float minxX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if(target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, target.position, Time.deltaTime * CameraSpeed);
            float clampX = Mathf.Clamp(newCamPosition.x, minxX, maxX);
            float clampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(clampX, clampY, -10f);
        }
    }
}
