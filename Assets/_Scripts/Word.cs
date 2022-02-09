using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Word : MonoBehaviour
{
    public TextAsset textAssetData;
    public List<string> scrabbleDictionary;

    private string word = "bad";

    private void Start()
    {
        scrabbleDictionary = ReadCSV().ToList();
    }

    bool CheckInDictionary(string word)
    {
        return scrabbleDictionary.Contains(word.ToLower());
    }

    void OnMouseDown()
    {
        Debug.Log(CheckInDictionary(word));
    }

    string[] ReadCSV()
    {
        string[] myDict = textAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);
        for (int i = 0; i < myDict.Length; i++)
        {
            myDict[i] = myDict[i].Trim();
        }
        return myDict;
    }
}
