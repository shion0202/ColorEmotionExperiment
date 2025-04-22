using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Experiment05 : UI_Popup
{
    enum Images
    {
        ImgFace
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

        if (Managers.Experiment.Count < 2)
        {
            if (timer >= waitingTime || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Q))
                Response();
        }
        else
        {
            if (timer >= waitingTime)
            {
                Managers.Experiment.Responses.Add("미응답");
                Managers.Experiment.Times.Add(0f);
                Response();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Managers.Experiment.Responses.Add("긍정");
                Managers.Experiment.Times.Add(timer);
                Response();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Managers.Experiment.Responses.Add("부정");
                Managers.Experiment.Times.Add(timer);
                Response();
            }
        }
    }

    public override void Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));

        timer = 0f;
        waitingTime = 1.0f;
        int count = Managers.Experiment.Count;

        if (count < 2)
        {
            GetImage((int)Images.ImgFace).sprite = Resources.Load<Sprite>($"Face/{Managers.Experiment.TestFaces[count]}");
        }
        else if (count < 42)
        {
            GetImage((int)Images.ImgFace).sprite = Resources.Load<Sprite>($"Face/{Managers.Experiment.FirstFaces[count - Managers.Experiment.Checksum]}");
        }
        else
        {
            int face = Managers.Experiment.SecondPatterns[count - Managers.Experiment.Checksum];
            if (face % 2 == 0)
            {
                GetImage((int)Images.ImgFace).sprite = Resources.Load<Sprite>($"Face/P{Managers.Experiment.SecondPositiveFaces[count - Managers.Experiment.Checksum]}");
            }
            else if (face % 2 == 1)
            {
                GetImage((int)Images.ImgFace).sprite = Resources.Load<Sprite>($"Face/Q{Managers.Experiment.SecondNegativeFaces[count - Managers.Experiment.Checksum]}");
            }
        }
    }

    public void Response()
    {
        timer = 0f;
        Managers.UI.ClosePopupUI();
        Managers.Experiment.CheckNext();
    }
}
