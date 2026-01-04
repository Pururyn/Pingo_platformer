using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    public int fishcoin;

    public static count instance;

    public Image FishCoin;
    public Sprite[] numberSprites;
    
    //Ici la méthode Awake sert à initialiser les variables et les objets mais aussi à faire en sorte qu'il n'y ait qu'1 instance pour compter les fishcoins
    private void Awake() 
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance count dans la scène");
            return;
        }
        instance = this;
    }

    public void AddCoins(int fish)
    {
        fishcoin += fish;
        UpdateFishCoin();

        if (fishcoin == 5)
        { 
            DestroyDoor();
        }
            
    }

    private void UpdateFishCoin()
    {
        if (fishcoin >= 0 && fishcoin < numberSprites.Length)
        {
           FishCoin.sprite = numberSprites[fishcoin];
        }
    }

    private void DestroyDoor()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

        foreach (GameObject door in doors)
        {
            Destroy(door);
        }
    }
}
