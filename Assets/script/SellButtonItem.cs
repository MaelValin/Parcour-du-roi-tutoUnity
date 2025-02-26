using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemtext;
    public Image itemImage;
    public Text itemPrice;

    public Item item;

    public void OnButtonSell()
    {
        inventaire inventory=inventaire.instance;
        if(inventory.NumberCoins >= item.price)
        {
            inventory.NumberCoins -= item.price;
            inventory.AddItem(item,1);
    
            inventory.UpdateTextUi();
        }
    }
}
