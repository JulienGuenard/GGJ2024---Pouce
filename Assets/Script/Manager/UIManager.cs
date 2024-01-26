using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Timer
    [SerializeField] TextMeshProUGUI timerText;
    public TextMeshProUGUI TimerText
    {
        get { return timerText; }
        set { timerText = value; }
    }
    #endregion

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
