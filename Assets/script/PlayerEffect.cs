using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour
{

    public Rigidbody2D rb;
      public static PlayerEffect instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerEffect dans la scène");
            return;
        }
        instance = this;
    }

    public void AddSpeed(float speedGiven, float speedDuration)
    {
        if(PlayerMovement.instance.movespeed<10)
        {
            
        
        float vitesse=PlayerMovement.instance.movespeed*speedGiven;
       PlayerMovement.instance.movespeed+= vitesse;
        StartCoroutine(RemoveSpeed(vitesse, speedDuration));
        
        }
    }

    private IEnumerator RemoveSpeed(float speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovement.instance.movespeed-= speedGiven;
    }
    

    public void AddJump(int Jumpforce)
    {
        rb.AddForce(new Vector2(0f, Jumpforce));
    }

    public void FlotPotion(float Gravity, int flotduration)
    {
        rb.gravityScale = Gravity;
        StartCoroutine(Flotremove(flotduration));
    }

    private IEnumerator Flotremove(int flotduration)
    {
        yield return new WaitForSeconds(flotduration);
        rb.gravityScale = 1;
    }

    public void RandomPotion()
    {
        int random = Random.Range(1, 7);
        if (random == 1)
        {
            AddSpeed(2, 5);
        }
        else if (random == 2)
        {
            AddJump(500);
        }
        else if (random == 3)
        {
            FlotPotion(0.5f, 5);
        }
        else if (random == 4)
        {
            AddSpeed(2, 5);
            AddJump(500);
            FlotPotion(0.5f, 5);
        }
        else if (random == 5)
        {
            PlayerHealth.instance.Die();
        }
        else if (random == 6)
        {
            StartColorChange();
        }
        Debug.Log(random);
        
    }


    private void RandomColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
    }

    private IEnumerator ChangeColorForDuration(float duration, float interval)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            RandomColor();
            yield return new WaitForSeconds(interval);
            elapsedTime += interval;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void StartColorChange()
    {
        StartCoroutine(ChangeColorForDuration(10f, 0.1f));
    }

}
