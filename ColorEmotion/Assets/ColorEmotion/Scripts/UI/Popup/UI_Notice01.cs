using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Notice01 : UI_Popup
{
    void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Managers.UI.ClosePopupUI();
            Managers.UI.ShowPopupUI<UI_InputNumber>();
        }
    }

    public override void Init()
    {
        base.Init();
    }
}
