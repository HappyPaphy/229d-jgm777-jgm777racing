using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectible
{
    Coin,
    HealthItem,
    PowerUp1,
    PowerUp2,
    Ring
};

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private int coin;
    public int Coin { get { return coin; } }

    [SerializeField] private float curHP;
    public float CurHP { get { return curHP; } }

    [SerializeField] private float maxHP;
    public float MaxHP { get { return maxHP; } }

    public static CollectibleManager instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
       
    }
}
