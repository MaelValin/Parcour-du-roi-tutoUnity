using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
  public int coinPickedUpthisScenecount;
  public Vector3 playerspawn;
  public int levelToUnlock;

   public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }
        else
        {
            instance = this;
        }

        playerspawn = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    
}
