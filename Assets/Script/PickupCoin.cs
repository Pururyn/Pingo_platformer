using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    //private bool isPickedUp = false; //Pour empêcher le bug du double drop sur 1 poisson

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (/*!isPickedUp &&*/collider.CompareTag("Player")) // Le tag est mis sur "penguin" (voir l'inspecteur)
        {
            //isPickedUp = true; 
            count.instance.AddCoins(1); // Va rajouter 1 au nb de poisson récup
            Destroy(gameObject); // va faire disparaitre le poisson
        }
    }
}