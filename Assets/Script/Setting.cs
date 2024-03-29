using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private Button button_WASD_Button;
    [SerializeField] private Image wasd_UI;

    [SerializeField] private Button button_arrow_Button;
    [SerializeField] private Image arrow_UI;

    [SerializeField] PlayerController player;

    public bool isSetTo_WASD_Button = true;

    public static Setting instance;
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(isSetTo_WASD_Button == null)
        {

        }
    }

    void Update()
    {

    }

    public void SwitchTo_WASD_Button(bool b)
    {
        Color alphaFull = wasd_UI.color;
        Color alphaFade = wasd_UI.color;

        alphaFull.a = 1f;
        alphaFade.a = 0.3f;

        if (b)
        { 
            Debug.Log("Change To WASD");
            wasd_UI.color = alphaFull;
            arrow_UI.color = alphaFade;
        }
        else
        {
            Debug.Log("Change To Arrow");
            wasd_UI.color = alphaFade;
            arrow_UI.color = alphaFull;
        }

        PlayerKeyBindSetting(isSetTo_WASD_Button);
    }

    void PlayerKeyBindSetting(bool isSetToWASD)
    {
        if (isSetToWASD == true)
        {
            player.moveForwardKey = KeyCode.W;
            player.rotateLeftKey = KeyCode.A;
            player.moveBackwardKey = KeyCode.S;
            player.rotateRightKey = KeyCode.D;
        }
        else
        {
            player.moveForwardKey = KeyCode.UpArrow;
            player.rotateLeftKey = KeyCode.LeftArrow;
            player.moveBackwardKey = KeyCode.DownArrow;
            player.rotateRightKey = KeyCode.RightArrow;
        }
    }
}
