using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Button button_Restart;
    [SerializeField] private Button button_MainMenu;
    [SerializeField] private Button button_PlayGame;
    [SerializeField] private Button button_ExitGame;

    [SerializeField] private Button button_CreditUI;
    [SerializeField] private Button button_backCreditUI;
    [SerializeField] private GameObject creditUI;

    [SerializeField] private Button button_TutorialUI;
    [SerializeField] private Button button_backTutorialUI;
    [SerializeField] private GameObject tutorialUI;

    [SerializeField] private GameObject youWinUI;
    [SerializeField] private GameObject youLoseUI;

    [SerializeField] public SoundManager soundManager;

    public static SceneChanger instance;
    

    void Start()
    {
        instance = this;

        if(tutorialUI != null)
        {
            tutorialUI.SetActive(false);
        }

        if (creditUI != null)
        {
            creditUI.SetActive(false);
        }

        if (youWinUI != null)
        {
            youWinUI.SetActive(false);
        }

        if (youLoseUI != null)
        {
            youLoseUI.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public void RestartScene()
    {
        soundManager.UIClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuScene()
    {
        soundManager.UIClickSound();
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PlayGameScene()
    {
        soundManager.UIClickSound();
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitGameScene()
    {
        soundManager.UIClickSound();
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OpenCreditUI()
    {
        soundManager.UIClickSound();
        creditUI.SetActive(true);
    }

    public void CloseCreditUI()
    {
        soundManager.UIClickSound();
        creditUI.SetActive(false);
    }

    public void OpenTutorialUI()
    {
        soundManager.UIClickSound();
        tutorialUI.SetActive(true);
    }

    public void CloseTutorialUI()
    {
        soundManager.UIClickSound();
        tutorialUI.SetActive(false);
    }

    public void YouWinUI()
    {
        soundManager.WinSound();
        youWinUI.SetActive(true);
    }

    public void YouLoseUI()
    {
        soundManager.LoseSound();
        youLoseUI.SetActive(true);
    }
}
