using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ExperimentManager
{
    string userNumber;
    int count;
    int checksum;

    // ��� �����
    ArrayList responses;
    ArrayList times;

    // ���� ���� 2��
    List<string> testWords;
    List<string> testFaces;

    // ���� 1 40��
    List<string> firstWordBase;
    List<string> firstFaceBase;
    string[] firstWords;
    string[] firstFaces;

    // ���� 2 160��
    List<string> secondWordBase;
    List<int> secondPatternBase;
    string[] secondWords;
    int[] secondPatterns;

    List<int> secondFaceBase;
    int[] secondPositiveFaces;
    int[] secondNegativeFaces;

    public string UserNumber { get { return userNumber; } set { userNumber = value; } }
    public int Count { get { return count; } }
    public int Checksum { get { return checksum; } }
    public ArrayList Responses { get { return responses; } }
    public ArrayList Times { get { return times; } }
    public List<string> TestWords { get { return testWords; } }
    public List<string> TestFaces { get { return testFaces; } }
    public List<string> FirstWordBase { get {  return firstWordBase; } }
    public List<string> FirstFaceBase { get { return firstFaceBase; } }
    public string[] FirstWords { get { return firstWords; } }
    public string[] FirstFaces { get { return firstFaces; } }
    public List<string> SecondWordBase { get { return secondWordBase; } }
    public List<int> SecondPatternBase { get { return secondPatternBase; } }
    public string[] SecondWords { get { return secondWords; } }
    public int[] SecondPatterns { get { return secondPatterns; } }
    public List<int> SecondFaceBase { get { return secondFaceBase; } }
    public int[] SecondPositiveFaces { get { return secondPositiveFaces; } }
    public int[] SecondNegativeFaces { get { return secondNegativeFaces; } }

    public void Init()
    {
        userNumber = "";
        count = 0;
        checksum = 0;

        responses = new ArrayList();
        times = new ArrayList();

        testWords = new List<string> { "����", "�Ắ" };
        testFaces = new List<string> { "P", "Q" };

        firstWordBase = new List<string>
        {
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��",
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��"
        };
        firstFaceBase = new List<string>();

        ShuffleFirst();

        secondWordBase = new List<string>
        {
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��",
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��",
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��",
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��",
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��",
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��",
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��",
            "�μ�", "����", "�а�", "����", "���t", "���f", "����", "���O", "�襄", "�Gű",
            "�v��", "����", "�h��", "����", "�u��", "�P��", "�Y��", "ƫ�F", "�Q��", "�v��"
        };
        secondPatternBase = new List<int>
        {
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7
        };

        secondFaceBase = new List<int>
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40
        };

        ShuffleSecond();
    }

    // ���� 1�� �ܾ�� ������ �����ؼ� ����
    public void ShuffleFirst()
    {
        int randl, randr;
        string temp;

        firstWords = firstWordBase.ToArray();
        for (int i = 0; i < firstWords.Length; ++i)
        {
            randl = Random.Range(0, firstWords.Length);
            randr = Random.Range(0, firstWords.Length);

            temp = firstWords[randl];
            firstWords[randl] = firstWords[randr];
            firstWords[randr] = temp;
        }

        int iSelect = 0;
        for (int i = 0; i < 20; ++i)
        {
            do
            {
                iSelect = Random.Range(1, 41);
            }
            while (firstFaceBase.Contains($"P{iSelect}"));

            firstFaceBase.Add($"P{iSelect}");
        }
        for (int i = 0; i < 20; ++i)
        {
            do
            {
                iSelect = Random.Range(1, 41);
            }
            while (firstFaceBase.Contains($"Q{iSelect}"));

            firstFaceBase.Add($"Q{iSelect}");
        }

        firstFaces = firstFaceBase.ToArray();
        for (int i = 0; i < firstFaces.Length; ++i)
        {
            randl = Random.Range(0, firstFaces.Length);
            randr = Random.Range(0, firstFaces.Length);

            temp = firstFaces[randl];
            firstFaces[randl] = firstFaces[randr];
            firstFaces[randr] = temp;
        }
    }

    // ���� 1�� �ܾ�� ����(��, ����)�� �����ؼ� ����
    public void ShuffleSecond()
    {
        int randl, randr;
        string tempStr;
        int tempInt;

        secondWords = secondWordBase.ToArray();
        for (int i = 0; i < secondWords.Length; ++i)
        {
            randl = Random.Range(0, secondWords.Length);
            randr = Random.Range(0, secondWords.Length);

            tempStr = secondWords[randl];
            secondWords[randl] = secondWords[randr];
            secondWords[randr] = tempStr;
        }

        secondPatterns = secondPatternBase.ToArray();
        for (int i = 0; i < secondPatterns.Length; ++i)
        {
            randl = Random.Range(0, secondPatterns.Length);
            randr = Random.Range(0, secondPatterns.Length);

            tempInt = secondPatterns[randl];
            secondPatterns[randl] = secondPatterns[randr];
            secondPatterns[randr] = tempInt;
        }

        secondPositiveFaces = secondFaceBase.ToArray();
        for (int i = 0; i < secondPositiveFaces.Length; ++i)
        {
            randl = Random.Range(0, secondPositiveFaces.Length);
            randr = Random.Range(0, secondPositiveFaces.Length);

            tempInt = secondPositiveFaces[randl];
            secondPositiveFaces[randl] = secondPositiveFaces[randr];
            secondPositiveFaces[randr] = tempInt;
        }

        secondNegativeFaces = secondFaceBase.ToArray();
        for (int i = 0; i < secondNegativeFaces.Length; ++i)
        {
            randl = Random.Range(0, secondNegativeFaces.Length);
            randr = Random.Range(0, secondNegativeFaces.Length);

            tempInt = secondNegativeFaces[randl];
            secondNegativeFaces[randl] = secondNegativeFaces[randr];
            secondNegativeFaces[randr] = tempInt;
        }
    }

    public void CheckNext()
    {
        if (count == 1)
        {
            checksum += 2;
            Managers.UI.ShowPopupUI<UI_Notice04>();
        }
        else if (count == 41)
        {
            checksum += 40;
            Managers.UI.ShowPopupUI<UI_Notice05>();
        }
        else if (count == 81)
        {
            Managers.UI.ShowPopupUI<UI_Notice06>();
        }
        else if (count == 121)
        {
            Managers.UI.ShowPopupUI<UI_ExperimentNotice01>();
        }
        else if (count == 161)
        {
            Managers.UI.ShowPopupUI<UI_ExperimentNotice02>();
        }
        else if (count == 201)
        {
            Managers.UI.ShowPopupUI<UI_Notice07>();
        }
        else
        {
            Managers.UI.ShowPopupUI<UI_Experiment01>();
        }

        count++;
    }

    public void Clear()
    {
        userNumber = "";
        count = 0;
        checksum = 0;

        ShuffleFirst();
        ShuffleSecond();

        responses.Clear();
        times.Clear();
    }
}
