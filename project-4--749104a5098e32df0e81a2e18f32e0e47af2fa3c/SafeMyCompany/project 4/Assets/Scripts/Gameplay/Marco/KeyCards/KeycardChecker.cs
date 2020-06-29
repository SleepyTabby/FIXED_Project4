using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardChecker : MonoBehaviour
{
    
    public ItemPickup pickup;
    [Header("currentKeyCard")]
    public bool RedKey;
    [SerializeField] GameObject RedKeyCardStatus;
    public bool PinkKey;
    [SerializeField] GameObject PinkKeyCardStatus;
    public bool GreenKey;
    [SerializeField] GameObject GreenKeyCardStatus;
    public bool BlueKey;
    [SerializeField] GameObject BlueKeyCardStatus;
    private void Start()
    {
        RedKeyCardStatus.SetActive(true);
        PinkKeyCardStatus.SetActive(true);
        GreenKeyCardStatus.SetActive(true);
        BlueKeyCardStatus.SetActive(true);

    }
    //private void Update()
    //{
    //    if (RedKey)
    //    {
    //        RedKeyCardStatus.SetActive(true);
    //    }
    //    else
    //    {
    //        RedKeyCardStatus.SetActive(false);
    //    }
    //    if (PinkKey)
    //    {
    //        PinkKeyCardStatus.SetActive(true);
    //    }
    //    else
    //    {
    //        PinkKeyCardStatus.SetActive(false);
    //    }
    //    if (GreenKey)
    //    {
    //        GreenKeyCardStatus.SetActive(true);
    //    }
    //    else
    //    {
    //        GreenKeyCardStatus.SetActive(false);
    //    }
    //    if (BlueKey)
    //    {
    //        BlueKeyCardStatus.SetActive(true);
    //    }
    //    else
    //    {
    //        BlueKeyCardStatus.SetActive(false);
    //    }
    //}
}
