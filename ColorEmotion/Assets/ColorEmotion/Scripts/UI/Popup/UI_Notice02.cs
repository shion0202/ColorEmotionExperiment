using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Notice02 : UI_Popup
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
            Managers.UI.ShowPopupUI<UI_Notice03>();
        }
    }

    public override void Init()
    {
        base.Init();
    }
}
