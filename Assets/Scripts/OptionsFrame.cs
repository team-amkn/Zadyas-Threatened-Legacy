using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsFrame : MonoBehaviour
{

    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = AudioManager.GetVolumeMultiplier(); //For two way binding
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyOptionsMenu()
    {
        Destroy(this.gameObject);
    }
}
