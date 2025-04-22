using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

[Serializable]
public class ExperimentData
{
    public List<string> userNumbers;
    public List<string> words;
    public List<string> faces;
    public List<int> colors;
    public List<string> responses;
    public List<float> times;
}

public class DataManager
{
    private ExperimentData _saveData;
    public ExperimentData SaveData
    {
        get
        {
            if (_saveData == null)
            {
                _saveData = new ExperimentData();
                _saveData.userNumbers = new List<string>();
                _saveData.words = new List<string>();
                _saveData.faces = new List<string>();
                _saveData.colors = new List<int>();
                _saveData.responses = new List<string>();
                _saveData.times = new List<float>();
            }
            return _saveData;
        }
    }

    private Dictionary<string, List<string>> _wordDict = new Dictionary<string, List<string>>();
    private Dictionary<string, List<string>> _faceDict = new Dictionary<string, List<string>>();
    private Dictionary<string, List<int>> _colorDict = new Dictionary<string, List<int>>();
    private Dictionary<string, List<string>> _responseDict = new Dictionary<string, List<string>>();
    private Dictionary<string, List<float>> _timeDict = new Dictionary<string, List<float>>();
    public Dictionary<string, List<string>> WordDict { get { return _wordDict; } }
    public Dictionary<string, List<string>> FaceDict { get { return _faceDict; } }
    public Dictionary<string, List<int>> ColorDict { get { return _colorDict; } }
    public Dictionary<string, List<string>> ResponseDict { get { return _responseDict; } }
    public Dictionary<string, List<float>> TimeDict { get { return _timeDict; } }

    private string curUser = "";
    private int curPage = 0;
    public string CurUser { get { return curUser; } set { curUser = value; } }
    public int CurPage { get { return curPage; } set { curPage = value; } }

    public void SaveExperimentData()
    {
        SetSaveData();

        string fileName = $"/ExperimentData.json";
        string filePath = Application.persistentDataPath + fileName;
        string ToJsonData = JsonUtility.ToJson(SaveData);
        File.WriteAllText(filePath, ToJsonData);
    }

    public void SetSaveData()
    {
        SaveData.userNumbers.Add(Managers.Experiment.UserNumber);

        for (int i = 0; i < 40; i++)
        {
            SaveData.words.Add(Managers.Experiment.FirstWords[i]);
            SaveData.faces.Add(Managers.Experiment.FirstFaces[i]);
        }

        for (int i = 0; i < 160; i++)
        {
            SaveData.words.Add(Managers.Experiment.SecondWords[i]);
            SaveData.colors.Add(Managers.Experiment.SecondPatterns[i]);

            if (Managers.Experiment.SecondPatterns[i] % 2 == 0)
                SaveData.faces.Add($"P{Managers.Experiment.SecondPositiveFaces[i]}");
            else
                SaveData.faces.Add($"Q{Managers.Experiment.SecondNegativeFaces[i]}");
        }

        for (int i = 0; i < 200; i++)
        {
            SaveData.responses.Add(Managers.Experiment.Responses[i].ToString());
            SaveData.times.Add((float)Managers.Experiment.Times[i]);
        }
    }

    public ExperimentData LoadExperimentData()
    {
        string fileName = $"/ExperimentData.json";
        string filePath = Application.persistentDataPath + fileName;

        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            _saveData = JsonUtility.FromJson<ExperimentData>(FromJsonData);
        }
        else
        {
            _saveData = new ExperimentData();
            _saveData.userNumbers = new List<string>();
            _saveData.words = new List<string>();
            _saveData.faces = new List<string>();
            _saveData.colors = new List<int>();
            _saveData.responses = new List<string>();
            _saveData.times = new List<float>();
        }

        return SaveData;
    }

    public void MakeDict()
    {
        List<string> wordList;
        List<string> faceList;
        List<int> colorList;
        List<string> responseList;
        List<float> timeList;

        for (int i = 0; i < SaveData.userNumbers.Count; i++)
        {
            if (WordDict.ContainsKey(SaveData.userNumbers[i]))
                continue;

            wordList = new List<string>();
            faceList = new List<string>();
            colorList = new List<int>();
            responseList = new List<string>();
            timeList = new List<float>();

            for (int j = 0; j < 200; j++)
            {
                wordList.Add(SaveData.words[j + (200 * i)]);
                faceList.Add(SaveData.faces[j + (200 * i)]);
                responseList.Add(SaveData.responses[j + (200 * i)]);
                timeList.Add(SaveData.times[j + (200 * i)]);
            }

            for (int j = 0; j < 160; j++)
            {
                colorList.Add(SaveData.colors[j + (160 * i)]);
            }

            WordDict.Add(SaveData.userNumbers[i], wordList);
            FaceDict.Add(SaveData.userNumbers[i], faceList);
            ColorDict.Add(SaveData.userNumbers[i], colorList);
            ResponseDict.Add(SaveData.userNumbers[i], responseList);
            TimeDict.Add(SaveData.userNumbers[i], timeList);
        }
    }

    public void Clear()
    {
        _saveData = null;
        _wordDict.Clear();
        _faceDict.Clear();
        _colorDict.Clear();
        _responseDict.Clear();
        _timeDict.Clear();
    }
}
