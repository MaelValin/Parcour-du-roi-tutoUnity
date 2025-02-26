using UnityEngine;

public class ItemDataBase : MonoBehaviour
{

    public Item[] Allitems;

  public static ItemDataBase instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ItemDataBase dans la scène");
            return;
        }
        else
        {
            instance = this;
        }
    }
}
