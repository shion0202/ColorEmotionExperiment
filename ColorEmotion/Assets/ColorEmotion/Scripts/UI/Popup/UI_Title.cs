using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Title : UI_Popup
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
            Managers.UI.ShowPopupUI<UI_Notice01>();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Managers.Data.MakeDict();
            Managers.UI.ClosePopupUI();
            Managers.UI.ShowPopupUI<UI_ResultList>();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public override void Init()
    {
        base.Init();
    }
}
