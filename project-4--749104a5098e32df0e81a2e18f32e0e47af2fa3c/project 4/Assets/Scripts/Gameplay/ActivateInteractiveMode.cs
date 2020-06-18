using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateInteractiveMode : MonoBehaviour
{
    public Gun gun;
    private bool PassiveMode;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PassiveMode = !PassiveMode;
            gun.SetCurrentPassiveMode(PassiveMode);
        }


    }
}
