using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Notice04 : UI_Popup
{
    void Start()
    {
        Init();
    }

    private void Update()
    {
        // ���� 1 40��
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
