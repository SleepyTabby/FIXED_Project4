using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public HealthBarScript HealthZero;
    [SerializeField] bool lvlOne;
    [SerializeField] public GameObject DeathReason;
    [SerializeField] public GameObject PlayerGone;
    [SerializeField] public GameObject Statics;
    void Start()
    {

    }
    void update()
    {


    }
    public void GameOver()
    {
        if (HealthZero.Healthslider.value <= 0)
        {
            DeathReason.SetActive(true);
            Destroy(PlayerGone);
            //Time.timeScale = 0f;
            print("worked");
            if (HealthZero.countdown <= 0)
            {
                print("DAMN U NOOB");
                PlayerStatistics.timesDeath++;
                if (lvlOne)
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    SceneManager.LoadScene(3);
                }
            }
        }

    }
}
