using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider sliderHP;
    [SerializeField] private int curHP;

    [SerializeField] private Text numRingText;
    [SerializeField] private int numRing;

    [SerializeField] public PlayerController playerController;

    /*[SerializeField] private PlayerController curHP;
    public PlayerController CurHP { get { return curHP; } set { curHP = value; } }

    *//*[SerializeField] private float curHP;
    public float CurHP { get { return curHP; } }*/

    /*[SerializeField] private float maxHP;
    public float MaxHP { get { return maxHP; } }*/

    void Start()
    {
        sliderHP.minValue = 0;
        sliderHP.maxValue = playerController.maxHP;
    }

    void Update()
    {
        numRing = playerController.numRing;
        curHP = playerController.curHP;
        sliderHP.value = curHP;
        numRingText.text = $"{numRing} / 14"; 
    }
}
