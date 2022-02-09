using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class IsInDictionary : MonoBehaviour
{
    public TMP_Text text;
    public TMP_InputField input;
    public TextAsset textAssetData;
    public List<string> scrabbleDictionary;

    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        scrabbleDictionary = ReadCSV().ToList();
    }

    bool CheckInDictionary(string word)
    {
        return scrabbleDictionary.Contains(word.ToLower());
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
