using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExitMenu : MonoBehaviour
{
    public TextMeshProUGUI curAttempt;
    public TextMeshProUGUI nextAttempt;
    public TextMeshProUGUI time;
    Button survey;

    // Start is called before the first frame update
    void Start()
    {
        curAttempt = GameObject.Find("curAttempt").GetComponent<TextMeshProUGUI>();
        curAttempt.text = PlayerPrefs.GetInt("Attempt").ToString();

        nextAttempt = GameObject.Find("nextAttempt").GetComponent<TextMeshProUGUI>();
        nextAttempt.text = (PlayerPrefs.GetInt("Attempt") + 1).ToString();

        time = GameObject.Find("TimeDisplay").GetComponent<TextMeshProUGUI>();
        time.text = PlayerPrefs.GetString("Time");

        survey = GameObject.Find("Survey").GetComponent<Button>();
    }

    public void OnSurveyClick()
    {
        Application.OpenURL("https://survey.zohopublic.com/zs/M5Cs3c");
    }
}
