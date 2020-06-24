using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text up, left, down, right;

    private GameObject currentKey;

    private Color32 normal = new Color(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);
    void Start()
    {
        keys.Add("Up", KeyCode.W);
        keys.Add("Left", KeyCode.A);
        keys.Add("Down", KeyCode.S);
        keys.Add("Right", KeyCode.D);

        up.text = keys["Up"].ToString();
        left.text = keys["Left"].ToString();
        down.text = keys["Down"].ToString();
        right.text = keys["Right"].ToString();

    }

    void Update()
    {
        if (Input.GetKeyDown(keys["Up"]))
        {
            float hor = Input.GetAxis("Vertical");
            hor = +1;
        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            float hor = Input.GetAxis("Horizontal");
            hor = -1;
        }
        if (Input.GetKeyDown(keys["Down"]))
        {
            float hor = Input.GetAxis("Vertical");
            hor = -1;
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            float hor = Input.GetAxis("Horizontal");
            hor = +1;
        }

    }
    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }
    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }
    
}
