using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class UI_ResultList : UI_Popup
{
    enum GameObjects
    {
        Content
    }

    enum Buttons
    {
        BtnBack
    }

    int panelCount;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        panelCount = 0;

        GameObject go = GetButton((int)Buttons.BtnBack).gameObject;
        BindEvent(go, onClickBack, UIEvent.Click);

        GameObject panel = Get<GameObject>((int)GameObjects.Content);
        foreach (Transform child in panel.transform)
            Managers.Resource.Destroy(child.gameObject);

        CreateExperimentViews(panel);
        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(1820, (panelCount / 5 + 1) * 120 + 20);
    }

    private void CreateExperimentViews(GameObject parent)
    {
        foreach (var userNumber in Managers.Data.SaveData.userNumbers)
        {
            GameObject detail = Managers.Resource.Instantiate("UI/SubItem/UI_ResultView");
            detail.transform.SetParent(parent.transform);

            UI_ResultView detailSlot = Utils.GetAddedComponent<UI_ResultView>(detail);
            detailSlot.Setup(userNumber);

            panelCount++;
        }
    }

    public void onClickBack(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_Title>();
    }
}
