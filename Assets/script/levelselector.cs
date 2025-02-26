using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelselector : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        int LevelReached = PlayerPrefs.GetInt("LevelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > LevelReached){
                levelButtons[i].interactable = false;
            }
           
        }
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

  
}
