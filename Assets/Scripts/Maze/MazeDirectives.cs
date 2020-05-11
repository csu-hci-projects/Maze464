using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class MazeDirectives : MonoBehaviour
{

    public int keysToFind;

    public Text KeyValueText;

    public MazeGoal mazeGoalPrefab;

    MazeGoal mazeGoal;

    public static float time = 0.0f;

    List<Vector3> mazeKeyPositions;

    

    void Awake()
    {
        
        MazeGenerator.OnMazeReady += StartDirectives;
        
    }

    void Start()
    {
        KeyValueText = GameObject.Find("KeyValueText").GetComponent<Text>();
        mazeGoalPrefab = GameObject.Find("MazeGoal").GetComponent<MazeGoal>();
        GameObject.Find("MazeGoal").GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        float startTime = PlayerPrefs.GetFloat("StartTime");
        float time = Time.time - startTime;
        string timeString = "TIME: " + time.ToString("#.00") + " seconds";
        PlayerPrefs.SetString("Time", timeString);
        KeyValueText.text = time.ToString("#.00") + " sec";
    }

    void StartDirectives()
    {
        mazeGoal = Instantiate(mazeGoalPrefab, MazeGenerator.instance.mazeGoalPosition, Quaternion.identity) as MazeGoal;
        mazeGoal.transform.SetParent(transform);
        GameObject.Find("MazeGoal").GetComponent<Collider2D>().enabled = true;

    }

    public void CreateMazeGoal()
    {
        mazeGoal = Instantiate(mazeGoalPrefab, MazeGenerator.instance.mazeGoalPosition, Quaternion.identity) as MazeGoal;
        mazeGoal.transform.SetParent(transform);
    }

    public void OnGoalReached()
    {
        DontDestroyOnLoad(this.mazeGoal);
    }

}