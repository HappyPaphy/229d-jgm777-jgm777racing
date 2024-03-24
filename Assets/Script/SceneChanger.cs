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
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGameScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void OpenCreditUI()
    {
        creditUI.SetActive(true);
    }

    public void CloseCreditUI()
    {
        creditUI.SetActive(false);
    }

    public void OpenTutorialUI()
    {
        creditUI.SetActive(true);
    }

    public void CloseTutorialUI()
    {
        creditUI.SetActive(false);
    }



}
