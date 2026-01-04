using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public GameObject Hide;

    void Start() //masque le gameobject gameover
    {
        if (Hide.gameObject.activeSelf)
        {
            Hide.gameObject.SetActive(false);
        }
    }
}