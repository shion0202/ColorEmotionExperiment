using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InputNumber : UI_Popup
{   
    enum Texts
    {
        TxtNumber
    }

    enum InputFields
    {
        InputNumber
    }

    void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string number = Get<TMP_InputField>((int)InputFields.InputNumber).text;
            Managers.Experiment.UserNumber = number;
            Managers.UI.ClosePopupUI();
            Managers.UI.ShowPopupUI<UI_Notice02>();
        }
    }

    public override void Init()
    {
        base.Init();
        Bind<TMP_InputField>(typeof(InputFields));
        Bind<TextMeshProUGUI>(typeof(Texts));
    }
}
