using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ExperimentNotice01 : UI_Popup
{
    void Start()
    {
        Init();
    }

    private void Update()
    {
        // ½ÇÇè 2-3 40Ç×
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Managers.UI.ClosePopupUI();
            Managers.UI.ShowPopupUI<UI_Experiment01>();
        }
    }

    public override void Init()
    {
        base.Init();
    }
}
