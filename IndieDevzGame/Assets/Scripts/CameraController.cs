using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 2f; // A kamera mozgási sebessége
    public float endX = 100f;    // Az X tengely végpontja, ahová a kamera elérhet

    private void Update()
    {
        // Ellenőrzi, hogy a kamera elérte-e a végpontot
        if (transform.position.x < endX)
        {
            // Folyamatosan jobbra mozgatja a kamerát
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}