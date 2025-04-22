using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Experiment02 : UI_Popup
{
    float timer;
    float waitingTime;

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
            Managers.UI.ShowPopupUI<UI_Experiment03>();
        }
    }

    public override void Init()
    {
        base.Init();

        timer = 0f;
        waitingTime = 0.25f;
    }
}
