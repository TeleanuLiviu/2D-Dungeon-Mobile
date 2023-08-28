using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject ShopWindow;
    private int currentItem, currentCost;
    Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            player = collision.GetComponent<Player>();
            
            UIManager.Instance.OpenShop(player.diamond);
            ShopWindow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UIManager.Instance.SelectionImage.enabled = false;
            ShopWindow.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        
        switch (item)
        {
            case 0:
                UIManager.Instance.SelectionImage.enabled = true;
                UIManager.Instance.SelectionImage.rectTransform.anchoredPosition = new Vector2(UIManager.Instance.SelectionImage.rectTransform.anchoredPosition.x, 92.0f);
                currentItem = 0;
                currentCost = 200;
                break;
            case 1:
                UIManager.Instance.SelectionImage.enabled = true;
                UIManager.Instance.SelectionImage.rectTransform.anchoredPosition = new Vector2(UIManager.Instance.SelectionImage.rectTransform.anchoredPosition.x, -29.0f);
                currentItem = 1;
                currentCost = 400;
                break;
            case 2:
                UIManager.Instance.SelectionImage.enabled = true;
                UIManager.Instance.SelectionImage.rectTransform.anchoredPosition = new Vector2(UIManager.Instance.SelectionImage.rectTransform.anchoredPosition.x, -147.0f);
                currentItem = 2;
                currentCost = 100;
                break;
            default:
                UIManager.Instance.SelectionImage.enabled = false;
                break;


        }
    }

    public void BuyItem()
    {
        if(player.diamond>=currentCost)
        {
            if(currentItem ==2)
            {
                GameManager.Instance._hasKey = true;
            }

            player.diamond -= currentCost;
            UIManager.Instance.UpdateDiamondCount(player.diamond);
            ShopWindow.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough diamonds");
            ShopWindow.SetActive(false);
        }
    }
}
