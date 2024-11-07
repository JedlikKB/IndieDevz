using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public Camera mainCamera; // A fő kamera
    public float leftMargin = 0.05f; // A bal oldali margó (X tengely)
    public float rightMargin = 0.05f; // A jobb oldali margó (X tengely)
    public float topMargin = 0.05f; // A felső margó (Y tengely)
    public float bottomMargin = 0.05f; // Az alsó margó (Y tengely)

    private void Update()
    {
        // Az űrhajó pozíciója világkoordinátákban
        Vector3 worldPosition = transform.position;

        // A kamera látóterének bal és jobb széle a világkoordinátákban
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(leftMargin, 0, 0)).x;
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1 - rightMargin, 0, 0)).x;

        // A kamera látóterének alsó és felső széle a világkoordinátákban
        float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, bottomMargin, 0)).y;
        float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1 - topMargin, 0)).y;

        // Az űrhajó pozíciójának korlátozása
        worldPosition.x = Mathf.Clamp(worldPosition.x, minX, maxX);
        worldPosition.y = Mathf.Clamp(worldPosition.y, minY, maxY);

        // Frissítjük az űrhajó pozícióját
        transform.position = worldPosition;
    }
}