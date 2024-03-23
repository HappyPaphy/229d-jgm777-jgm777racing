using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectible
{
    Coin,
    HealthItem,
    PowerUp1,
    PowerUp2
};

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private SimpleCollectibleScript coin;
    public SimpleCollectibleScript Coin { get { return coin; } }

    [SerializeField] private PlayerController curHP;
    PlayerController CurHP { get { return curHP; } }

    [SerializeField] private PlayerController maxHP;
    PlayerController MaxHP { get { return maxHP; } }

    public static CollectibleManager instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
