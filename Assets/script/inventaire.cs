using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public class inventaire : MonoBehaviour
{
    public int NumberCoins = 0;
    public Text coinText;
    public GameObject ImageInventaire;
    public Sprite imgvide;
    public GameObject textItem;
    public PlayerEffect playerEffect;
    public Text numberItem;
    public float LivePotionQuantity = 0;
    public float SpeedPotionQuantity = 0;
    public float JumpPotionQuantity = 0;
    public float GravityPotionQuantity = 0;
    public float RandomPotionQuantity = 0;
    public AudioClip Soundlive;
    public AudioClip Soundspeed;

    public List<Item> items = new List<Item>();
    private int contentCurrentIndex = 0;

    public static inventaire instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de inventaire dans la scène");
            return;
        }
        instance = this;
    }

    public void ConsumeItem()
    {
        if (PlayerMovement.instance.movespeed < 10)
        {
            Item currentItem = items[contentCurrentIndex];
            PlayerHealth.instance.Heal(currentItem.hpGiven);
            playerEffect.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);

            if(items[contentCurrentIndex].id == 1)
            {
                LivePotionQuantity--;
                if (LivePotionQuantity <= 0)
                {
                    items.Remove(currentItem);
                    GetNextItem();
                }

                AudioManager.instance.CreateAudioSource(Soundlive, transform.position);
            }
            else if (items[contentCurrentIndex].id == 2)
            {
                SpeedPotionQuantity--;
                 if (SpeedPotionQuantity <= 0)
            {
                
                items.Remove(currentItem);
                GetNextItem();
            }
            AudioManager.instance.CreateAudioSource(Soundspeed, transform.position);
            }
            else if(items[contentCurrentIndex].id == 3)
            {
                 JumpPotionQuantity--;
                 PlayerEffect.instance.AddJump(currentItem.Jumpforce);
                 if (JumpPotionQuantity <= 0)
            {
                
                items.Remove(currentItem);
                GetNextItem();
            }
            }
            else if(items[contentCurrentIndex].id == 4)
            {
                 GravityPotionQuantity--;
                 PlayerEffect.instance.FlotPotion(currentItem.Gravity, currentItem.flotduration);
                 if (GravityPotionQuantity <= 0)
            {
                
                items.Remove(currentItem);
                GetNextItem();
            }
            }
            else if (items[contentCurrentIndex].id == 5)
            {
                RandomPotionQuantity--;
                PlayerEffect.instance.RandomPotion();
                if (RandomPotionQuantity <= 0)
                {
                    items.Remove(currentItem);
                    GetNextItem();
                }
            }
           
        }
    }

    public void GetNextItem()
    {
        contentCurrentIndex++;

        if (contentCurrentIndex > items.Count - 1)
        {
            contentCurrentIndex = 0;
        }
    }

    public void GetPreviousItem()
    {
        contentCurrentIndex--;

        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = items.Count - 1;
        }
    }

    void Update()
    {
        if (items.Count == 0)
        {
            ImageInventaire.GetComponent<Image>().sprite = imgvide;
            textItem.GetComponent<Text>().text = "";
            numberItem.text = "";
        }
        else
        {
            ImageInventaire.GetComponent<Image>().sprite = items[contentCurrentIndex].img;
            textItem.GetComponent<Text>().text = items[contentCurrentIndex].name;
            if(items[contentCurrentIndex].id == 1)
            {
                numberItem.text = LivePotionQuantity.ToString();
            }
            else if (items[contentCurrentIndex].id == 2)
            {
                numberItem.text = SpeedPotionQuantity.ToString();
            }
            else if (items[contentCurrentIndex].id == 3)
            {
                numberItem.text = JumpPotionQuantity.ToString();
            }
            else if (items[contentCurrentIndex].id == 4)
            {
                numberItem.text = GravityPotionQuantity.ToString();
            }
            else if (items[contentCurrentIndex].id == 5)
            {
                numberItem.text = RandomPotionQuantity.ToString();
            }
            
            
        }

        if (Input.GetKeyDown(KeyCode.Q) && items.Count > 0)
        {
            ConsumeItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetNextItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetPreviousItem();
        }
    }

    public void AddItem(Item newItem, int quantity)
    {
        
        Item existingItem = items.Find(item => item.id == newItem.id);
        if (existingItem != null)
        {
            if(newItem.id == 1)
            {
                LivePotionQuantity+=quantity;
            }
            else if (newItem.id == 2)
            {
                 SpeedPotionQuantity+=quantity;
            }
            else if (newItem.id == 3)
            {
                 JumpPotionQuantity+=quantity;
            }
            else if (newItem.id == 4)
            {
                 GravityPotionQuantity+=quantity;
            }
            else if (newItem.id == 5)
            {
                RandomPotionQuantity += quantity;
            }
        }
        else
        {
            items.Add(newItem);
            if(newItem.id == 1)
            {
                LivePotionQuantity=quantity;
            }
            else if (newItem.id == 2)
            {
                 SpeedPotionQuantity=quantity;
            }
            else if (newItem.id == 3)
            {
                 JumpPotionQuantity=quantity;
            }
            else if (newItem.id == 4)
            {
                 GravityPotionQuantity=quantity;
            }
            else if (newItem.id == 5)
            {
                RandomPotionQuantity = quantity;
            }
        }
        
    }

    

    public void AddCoins(int count)
    {
        NumberCoins += count;
        coinText.text = NumberCoins.ToString();
    }

    public void RemoveCoins(int count)
    {
        NumberCoins -= count;
        coinText.text = NumberCoins.ToString();
    }

    public void UpdateTextUi()
    {
        coinText.text = NumberCoins.ToString();
    }
}
