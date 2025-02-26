using UnityEngine;
using System.Linq;

public class loadandsavedata : MonoBehaviour
{

    public static loadandsavedata instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de loadandsavedata dans la scène");
            return;
        }
        else
        {
            instance = this;
        }
    }
        

    void Start()
    {
        inventaire.instance.NumberCoins = PlayerPrefs.GetInt("coinscount",0);
        inventaire.instance.UpdateTextUi();
       /* int currenthealth = PlayerPrefs.GetInt("currenthealth",PlayerHealth.instance.maxhealth);
        PlayerHealth.instance.currenthealth = currenthealth;
        PlayerHealth.instance.healthbar.SetHealth(currenthealth);*/

        
         string[] itemSave = PlayerPrefs.GetString("itemsInInventory","").Split(',');
        string[] QuantitySave = PlayerPrefs.GetString("QuantityInInventory","").Split(',');
        string[] JumpPotionQuantity = PlayerPrefs.GetString("JumpPotionQuantity","").Split(',');
        string[] GravityPotionQuantity = PlayerPrefs.GetString("GravityPotionQuantity","").Split(',');
        string[] RandomPotionQuantity = PlayerPrefs.GetString("RandomPotionQuantity","").Split(',');
        for (int i = 0; i < itemSave.Length; i++)
        {
            if(itemSave[i] != "")
            {
                
            
            int id = int.Parse(itemSave[i]);
            Item currentItem = ItemDataBase.instance.Allitems.Single(x => x.id == id);
            int number = int.Parse(QuantitySave.FirstOrDefault(q => q.StartsWith(currentItem.id + ":"))?.Split(':')[1]);

            inventaire.instance.AddItem(currentItem, number);
            }
        }

        inventaire.instance.UpdateTextUi();
    }

    public void SaveData()
    {
       // PlayerPrefs.SetInt("currenthealth", PlayerHealth.instance.currenthealth);
        PlayerPrefs.SetInt("coinscount", inventaire.instance.NumberCoins);
        
        if (PlayerPrefs.GetInt("LevelReached",1) < CurrentSceneManager.instance.levelToUnlock)
        {
            PlayerPrefs.SetInt("LevelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        string itemsInInventory = string.Join(",", inventaire.instance.items.Select(x => x.id));
        string QuantityInInventory = $"1:{inventaire.instance.LivePotionQuantity},2:{inventaire.instance.SpeedPotionQuantity},3:{inventaire.instance.JumpPotionQuantity},4:{inventaire.instance.GravityPotionQuantity},5:{inventaire.instance.RandomPotionQuantity}";
        PlayerPrefs.SetString("itemsInInventory", itemsInInventory);
        PlayerPrefs.SetString("QuantityInInventory", QuantityInInventory);
        

       
        
    }

    
}
