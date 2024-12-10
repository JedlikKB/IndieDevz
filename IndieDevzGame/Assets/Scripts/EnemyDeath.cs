using UnityEngine;

public class Enemyy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellen�rizz�k, hogy l�ved�k �rte-e el
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Ellens�g tal�latot kapott!");
            Destroy(gameObject);  // Ellens�g elt�vol�t�sa
            Destroy(collision.gameObject);  // L�ved�k elt�vol�t�sa
        }
    }
}
