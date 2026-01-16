using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        // On récupère le nom de la scène actuelle
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Platformer - Facile")
        {
            SceneManager.LoadScene("Platformer - Normal");
        }
        else if (currentSceneName == "Platformer - Normal")
        {
            SceneManager.LoadScene("Platformer - Difficile");
        }
        else
        {
            //SceneManager.LoadScene("Menu")Debug.Log("Aucune correspondance de niveau trouvée ou fin du jeu !");
        }
    }
}