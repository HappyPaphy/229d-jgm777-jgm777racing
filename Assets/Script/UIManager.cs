using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Button button_Restart;
    [SerializeField] private Button button_SettingUI;
    [SerializeField] private Button button_BackSettingUI;
    [SerializeField] private GameObject settingUI;

    [SerializeField] private SoundManager soundManager;

    void Start()
    {
        if (settingUI != null)
        {
            settingUI.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public void OpenUI(GameObject gameObject, bool b)
    {
        soundManager.UIClickSound();
        gameObject.SetActive(b);
    }
}
