using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedSquare"))
        {
            gameManager.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("BlackSquare"))
        {
            gameManager.GameOver();
            Destroy(other.gameObject);
        }
    }
}