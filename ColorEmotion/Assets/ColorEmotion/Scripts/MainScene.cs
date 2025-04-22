using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    void Start()
    {
        Managers.UI.ShowPopupUI<UI_Title>();
        Managers.Data.LoadExperimentData();
        Managers.Experiment.Init();
    }
}
