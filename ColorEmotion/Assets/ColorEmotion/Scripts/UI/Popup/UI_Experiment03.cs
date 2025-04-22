using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Experiment03 : UI_Popup
{
    enum Texts
    {
        TxtTarget
    }
    
    float timer;
    float waitingTime;
    int count;

    void Start()
    {
        Init();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            timer = 0f;
            Managers.UI.ClosePopupUI();
            Managers.UI.ShowPopupUI<UI_Experiment04>();
        }
    }

    public override void Init()
    {
        base.Init();
        Bind<TextMeshProUGUI>(typeof(Texts));

        timer = 0f;
        waitingTime = 0.5f;
        count = Managers.Experiment.Count;

        if (count < 2)
        {
            GetText((int)Texts.TxtTarget).text = Managers.Experiment.TestWords[count].ToString();
        }
        else if (count < 42)
        {
            GetText((int)Texts.TxtTarget).text = Managers.Experiment.FirstWords[count - Managers.Experiment.Checksum];
        }
        else
        {
            GetText((int)Texts.TxtTarget).text = Managers.Experiment.SecondWords[count - Managers.Experiment.Checksum];
            
            int color = Managers.Experiment.SecondPatterns[count - Managers.Experiment.Checksum];
            if (color == 0 || color == 1)
            {
                // 연보라
                GetText((int)Texts.TxtTarget).color = new Color32(190, 170, 214, 255);
            }
            else if (color == 2 || color == 3)
            {
                // 진보라
                GetText((int)Texts.TxtTarget).color = new Color32(90, 58, 114, 255);
            }
            else if (color == 4 || color == 5)
            {
                // 연노랑
                GetText((int)Texts.TxtTarget).color = new Color32(249, 227, 140, 255);
            }
            else if (color == 6 || color == 7)
            {
                // 진노랑
                GetText((int)Texts.TxtTarget).color = new Color32(111, 88, 21, 255);
            }
        }
    }
}
