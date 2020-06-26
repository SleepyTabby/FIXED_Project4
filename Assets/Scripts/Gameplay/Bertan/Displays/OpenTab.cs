using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTab : MonoBehaviour
{
    [SerializeField] public GameObject Statics;
    //[SerializeField] public GameObject StaticsSlot1;
    //[SerializeField] public GameObject StaticsSlot2;
    //[SerializeField] public GameObject StaticsSlot3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Statics.SetActive(true);
            //StaticsSlot1.SetActive(true);
            //StaticsSlot2.SetActive(true);
            //StaticsSlot3.SetActive(true);
        }
        else
        {
            Statics.SetActive(false);
        }
    }
}      