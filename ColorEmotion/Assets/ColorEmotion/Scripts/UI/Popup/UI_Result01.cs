using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class UI_Result01 : UI_Popup
{
    enum GameObjects
    {
        Content
    }

    enum Texts
    {
        TxtTitle,
        TxtColumn
    }

    enum Buttons
    {
        BtnNext,
        BtnPrev,
        BtnBack
    }

    List<string> wordList;
    List<string> faceList;
    List<string> responseTemp;
    List<float> timeTemp;
    ArrayList responseList;
    ArrayList timeList;

    int page = 0;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        GameObject go = GetButton((int)Buttons.BtnNext).gameObject;
        BindEvent(go, onClickNext, UIEvent.Click);
        go = GetButton((int)Buttons.BtnPrev).gameObject;
        BindEvent(go, onClickPrev, UIEvent.Click);
        go = GetButton((int)Buttons.BtnBack).gameObject;
        BindEvent(go, onClickBack, UIEvent.Click);

        page = Managers.Data.CurPage;

        GetText((int)Texts.TxtTitle).text = $"{Managers.Data.CurUser} - 실험 1 결과";
        GetText((int)Texts.TxtColumn).text = $"{1 + (8 * page)}\n{2 + (8 * page)}\n{3 + (8 * page)}\n{4 + (8 * page)}\n" +
            $"{5 + (8 * page)}\n{6 + (8 * page)}\n{7 + (8 * page)}\n{8 + (8 * page)}";

        GameObject panel = Get<GameObject>((int)GameObjects.Content);
        foreach (Transform child in panel.transform)
            Managers.Resource.Destroy(child.gameObject);

        CreateExperimentDetailViews(panel);
    }

    private void CreateExperimentDetailViews(GameObject parent)
    {
        Managers.Data.WordDict.TryGetValue(Managers.Data.CurUser, out wordList);
        for (int i = 0; i < 8; i++)
        {
            GameObject detail = Managers.Resource.Instantiate("UI/SubItem/UI_ResultDetailView");
            detail.transform.SetParent(parent.transform);
            UI_ResultDetailView detailSlot = Utils.GetAddedComponent<UI_ResultDetailView>(detail);
            detailSlot.Setup(wordList[i + (8 * page)]);
        }

        Managers.Data.FaceDict.TryGetValue(Managers.Data.CurUser, out faceList);
        for (int i = 0; i < 8; i++)
        {
            GameObject detail = Managers.Resource.Instantiate("UI/SubItem/UI_ResultDetailView");
            detail.transform.SetParent(parent.transform);
            UI_ResultDetailView detailSlot = Utils.GetAddedComponent<UI_ResultDetailView>(detail);

            string info = faceList[i + (8 * page)];
            string face = info.Substring(0, 1);
            int sex = int.Parse(info.Substring(1));

            if (face.Equals("P"))
            {
                if (sex > 20)
                    detailSlot.Setup("긍정 (여)");
                else
                    detailSlot.Setup("긍정 (남)");
            }
            else if (face.Equals("Q"))
            {
                if (sex > 20)
                    detailSlot.Setup("부정 (여)");
                else
                    detailSlot.Setup("부정 (남)");
            }
        }

        Managers.Data.ResponseDict.TryGetValue(Managers.Data.CurUser, out responseTemp);
        responseList = new ArrayList(responseTemp);
        for (int i = 0; i < 8; i++)
        {
            GameObject detail = Managers.Resource.Instantiate("UI/SubItem/UI_ResultDetailView");
            detail.transform.SetParent(parent.transform);
            UI_ResultDetailView detailSlot = Utils.GetAddedComponent<UI_ResultDetailView>(detail);
            detailSlot.Setup(responseList[i + (8 * page)].ToString());
        }

        Managers.Data.TimeDict.TryGetValue(Managers.Data.CurUser, out timeTemp);
        timeList = new ArrayList(timeTemp);
        for (int i = 0; i < 8; i++)
        {
            GameObject detail = Managers.Resource.Instantiate("UI/SubItem/UI_ResultDetailView");
            detail.transform.SetParent(parent.transform);
            UI_ResultDetailView detailSlot = Utils.GetAddedComponent<UI_ResultDetailView>(detail);
            detailSlot.Setup(timeList[i + (8 * page)].ToString());
        }
    }

    public void onClickNext(PointerEventData data)
    {
        Managers.Data.CurPage++;
        Managers.UI.ClosePopupUI();

        if (Managers.Data.CurPage > 4)
            Managers.UI.ShowPopupUI<UI_Result02>();
        else
            Managers.UI.ShowPopupUI<UI_Result01>();
    }

    public void onClickPrev(PointerEventData data)
    {
        if (Managers.Data.CurPage > 0)
        {
            Managers.Data.CurPage--;
            Managers.UI.ClosePopupUI();
            Managers.UI.ShowPopupUI<UI_Result01>();
        }
    }

    public void onClickBack(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_ResultList>();
    }
}
