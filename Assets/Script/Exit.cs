using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject Win;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Win.gameObject.SetActive(true);
        }
    }
}