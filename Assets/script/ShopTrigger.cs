using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ShopTigger : MonoBehaviour
{
    
    public bool isInRange;
    public Text textInteract;
    public string PnjName;
    public string Pnjphrase;
    public Item[] ItemToSell;


    void Awake()
    {
        textInteract = GameObject.FindGameObjectWithTag("textInteract").GetComponent<Text>();
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E)&&ShopManager.instance.isShop==false)
        {
            TriggerShop();
        }
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textInteract.enabled = true;
            isInRange = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textInteract.enabled = false;
            isInRange = false;
            ShopManager.instance.EndShop();
        }
    }

    void TriggerShop()
    {
        
        ShopManager.instance.StartShop(ItemToSell,PnjName,Pnjphrase);
        
    }
}
