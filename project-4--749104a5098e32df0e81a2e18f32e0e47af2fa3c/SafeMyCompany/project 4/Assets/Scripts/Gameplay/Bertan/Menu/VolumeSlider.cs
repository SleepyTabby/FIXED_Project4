using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSrc;

    [SerializeField] private Slider slider;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void SetVolume()
    {
        audioSrc.volume = (1f
            / slider.maxValue) * slider.value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
