using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class UI_ResultView : UI_Base
{
    enum Texts
    {
        TxtResult
    }

    enum Buttons
    {
        BtnClick
    }

    string user;

    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        GameObject go = GetButton((int)Buttons.BtnClick).gameObject;
        BindEvent(go, onClickUserNumber, UIEvent.Click);

        user = "";
    }

    public void Setup(string number)
    {
        Init();
        user = number;
        GetText((int)Texts.TxtResult).text = user;
    }

    public void onClickUserNumber(PointerEventData data)
    {
        Managers.Data.CurUser = user;
        Managers.Data.CurPage = 0;
        Managers.UI.ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_Result01>();
    }
}
