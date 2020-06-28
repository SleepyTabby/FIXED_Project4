using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public HealthBarScript GainHealth;
    [SerializeField] private int HealthGainedByPickingUpHPPack = 20;

    void OnTriggerEnter(Collider col)
    {
        GainHealth.GainHealth(HealthGainedByPickingUpHPPack);
        Destroy(this.gameObject);
    }
}
