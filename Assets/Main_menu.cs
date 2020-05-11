using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main_menu : MonoBehaviour
{
    Dropdown attempt;
    int size = 0;

    public void Awake()
    {
        attempt = GameObject.Find("AttemptInput").GetComponent<Dropdown>();
    }

    // Start is called before the first frame update
    public void PlayGame()
    {
        PlayerPrefs.SetInt("Attempt", int.Parse(attempt.options[attempt.value].text));
        float time = Time.time;
        PlayerPrefs.SetFloat("StartTime", time);
        SceneManager.LoadScene("Scene1");
    }

    public void StartTraining()
    {
        PlayerPrefs.SetInt("Attempt", -1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
