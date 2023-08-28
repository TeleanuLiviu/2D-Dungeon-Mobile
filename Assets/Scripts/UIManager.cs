using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    public static UIManager Instance
    {
        get { return _instance; }
    }

    public Text playerGemCount;
    public Image SelectionImage;
    public Text DiamondCountText;
    public List<Image> HealthBars;
    public GameObject Congrats, YouNeedKey,Dead;

    private void Awake()
    {
        _instance = this;
    }


    public void OpenShop(int GemCount)
    {
        playerGemCount.text = GemCount.ToString() + "G";
    }

    public void UpdateDiamondCount(int count)
    {
        DiamondCountText.text = count.ToString();
    }


    public void UpdateLives(int health)
    {
        HealthBars[health].enabled = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    
}
