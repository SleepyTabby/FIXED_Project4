using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public static bool MuteAudio = true;
    public void ToggleMute(bool mute)
    {
        MuteAudio = !mute;
    }
    public void mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
