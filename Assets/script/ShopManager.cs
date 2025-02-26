using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ShopManager : MonoBehaviour
{

    public Text nameText;
    public Text ShopText;
    public GameObject ShopBox;
    public GameObject PNJ;
    public bool isShop=false;
    public GameObject ButtonSellPrefab;
    public Transform ButtonSellParent;

    

    public static ShopManager instance;

    private void Awake()
    {

        
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }
        else
        {
            instance = this;
        }
         
        
    }

    public void StartShop(Item[] ItemToSell, string PnjName, string Pnjphrase)
    {
        StartCoroutine(Startshop(ItemToSell, PnjName, Pnjphrase));

       
    }

    void UpdateItemToSell(Item[] ItemToSell)
    {
        for(int i = 0; i < ButtonSellParent.childCount; i++)
        {
            Destroy(ButtonSellParent.GetChild(i).gameObject);
        }

        for (int i = 0; i < ItemToSell.Length; i++)
        {
            
            GameObject button = Instantiate(ButtonSellPrefab, ButtonSellParent);
            SellButtonItem buttonscript = button.GetComponent<SellButtonItem>();
            buttonscript.itemtext.text = ItemToSell[i].name;
            buttonscript.itemImage.sprite = ItemToSell[i].img;
            buttonscript.itemPrice.text = ItemToSell[i].price.ToString();
            buttonscript.item = ItemToSell[i];
            

            
            button.GetComponent<Button>().onClick.AddListener(
               delegate { buttonscript.OnButtonSell();});
        }

    }

    

   public void EndShop()
    {
        StartCoroutine(EndShopcarou());
    }

    IEnumerator EndShopcarou()
    {
        
        ShopBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isShop = false;
    }

IEnumerator Startshop(Item[] ItemToSell, string PnjName, string Pnjphrase){

        ShopBox.SetActive(true);

        nameText.text = PnjName;
        ShopText.text = Pnjphrase;
        
        UpdateItemToSell(ItemToSell);
        yield return new WaitForSeconds(0.5f);
        isShop = true;
}
    

    private void Update()
    {
       if (isShop && Input.GetKeyDown(KeyCode.E))
        {
            EndShop();
        }
        
    }
}

