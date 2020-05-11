using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MazeGoal : MonoBehaviour
{

    public Sprite closedGoalSprite;
    public Sprite openedGoalSprite;


    void Start()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = openedGoalSprite;

    }

    public void OpenGoal()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = openedGoalSprite;
    }

    void OnTriggerEnter2D()
    {
        int attempt = PlayerPrefs.GetInt("Attempt");
        if(attempt == -1)
        {
            SceneManager.LoadScene("ExitTraining", LoadSceneMode.Single);
        } else if(attempt == 3)
        {
            SceneManager.LoadScene("Exit3", LoadSceneMode.Single);
        } else
        {
            SceneManager.LoadScene("Exit12", LoadSceneMode.Single);
        }
    }
}
