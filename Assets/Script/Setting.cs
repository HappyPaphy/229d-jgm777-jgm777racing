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

    public bool isSetTo_WASD_Button = true;

    public static Setting instance;
    public static PlayerController player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        PlayerKeyBindSetting();
    }

    public void SwitchTo_WASD_Button(bool b)
    {
        if (b)
        {
            Debug.Log("Change To WASD");
            wasd_UI.CrossFadeAlpha(1f, 1f, false);
            arrow_UI.CrossFadeAlpha(0.3f, 1f, false);
        }
        else
        {
            Debug.Log("Change To Arrow");
            arrow_UI.CrossFadeAlpha(1f, 1f, false);
            wasd_UI.CrossFadeAlpha(0.3f, 1f, false);
        }

        isSetTo_WASD_Button = b;
    }

    void PlayerKeyBindSetting()
    {
        if (isSetTo_WASD_Button == true)
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
