using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    public bool _hasKey { get; set; }
    public Player player{ get; private set;}

    public void Awake()
    {
        _instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void AddDiamond(int Diamond)
    {
        player.diamond += Diamond;
        UIManager.Instance.UpdateDiamondCount(player.diamond);
        UIManager.Instance.OpenShop(player.diamond);
    }
}
