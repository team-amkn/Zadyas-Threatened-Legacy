using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int rotationDegree = 45;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationDegree * Time.deltaTime));
    }
}
