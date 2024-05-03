﻿using System.Collections;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    const string privateCode = "EBK8xw12ZEWtG-IiP1o7kgs3zcsOZVWUSphDj-jWMFIA";
    const string publicCode = "661d80498f40bb79a86f5e3a";
    const string webURL = "http://dreamlo.com/lb/";

    public PlayerScore[] scoreList;
    DisplayHighscores myDisplay;

    static HighScores instance;
    void Awake()
    {
        instance = this;
        myDisplay = GetComponent<DisplayHighscores>();
    }
    
    public static void UploadScore(string username, int score)
    {
        instance.StartCoroutine(instance.DatabaseUpload(username,score));
    }

    IEnumerator DatabaseUpload(string userame, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(userame) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            DownloadScores();
    }

    public void DownloadScores()
    {
        StartCoroutine("DatabaseDownload");
    }
    IEnumerator DatabaseDownload()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/0/10");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            OrganizeInfo(www.text);
            myDisplay.SetScoresToMenu(scoreList);
        }
    }

    void OrganizeInfo(string rawData)
    {
        string[] entries = rawData.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        scoreList = new PlayerScore[entries.Length];
        for (int i = 0; i < entries.Length; i ++)
        {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            scoreList[i] = new PlayerScore(username,score);
        }
    }
}

public struct PlayerScore
{
    public string username;
    public int score;

    public PlayerScore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}