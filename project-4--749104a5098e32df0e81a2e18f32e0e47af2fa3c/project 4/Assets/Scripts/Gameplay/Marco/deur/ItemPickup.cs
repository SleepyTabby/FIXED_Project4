using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool RedKey = false;
    [SerializeField] private GameObject redKeyCard;
    public bool PinkKey = false;
    [SerializeField] private GameObject pinkKeyCard;
    public bool GreenKey = false;
    [SerializeField] private GameObject greenKeyCard;
    public bool BlueKey = false;
    [SerializeField] private GameObject blueKeyCard;

    public KeycardChecker door;
    //public override void Interact()
    //{
    //    base.Interact();    
    //        PickUp();     

    //}

    private void Update()
    {
        if (RedKey)
        {
            pinkKeyCard.SetActive(true);
            
            greenKeyCard.SetActive(true);

            blueKeyCard.SetActive(true);

            RedKey = false;

            door.RedKey = true;
            door.BlueKey = false;
            door.PinkKey = false;
            door.GreenKey = false;

        }
        if (PinkKey)
        {
            redKeyCard.SetActive(true);

            greenKeyCard.SetActive(true);

            blueKeyCard.SetActive(true);

            PinkKey = false;

            door.RedKey = false;
            door.BlueKey = false;
            door.PinkKey = true;
            door.GreenKey = false;
        }
        if (BlueKey)
        {

            redKeyCard.SetActive(true);

            greenKeyCard.SetActive(true);

            pinkKeyCard.SetActive(true);

            BlueKey = false;

            door.RedKey = false;
            door.BlueKey = true;
            door.PinkKey = false;
            door.GreenKey = false;
        }
        if (GreenKey)
        {
            redKeyCard.SetActive(true);

            blueKeyCard.SetActive(true);

            pinkKeyCard.SetActive(true);

            GreenKey = false;

            door.RedKey = false;
            door.BlueKey = false;
            door.PinkKey = false;
            door.GreenKey = true;
        }
    }
    
}

