using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;

public class UI_ResultDetailView : UI_Base
{
    enum Texts
    {
        TxtResult
    }

    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    public void Setup(string text)
    {
        Init();
        GetText((int)Texts.TxtResult).text = text;
    }
}
