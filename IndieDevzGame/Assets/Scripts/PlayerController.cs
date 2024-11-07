using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class PlayertController : MonoBehaviour
{
    public float moveSpeed = 5f; // A mozgás sebessége (a playert kiválasztva a scriptnél manuálisan változtatható)

    private void Update()
    {
        // Bemeneti értékek beolvasása (W, A, S, D vagy a nyilak, unityben alapból meg vannak adva)
        float moveX = Input.GetAxis("Horizontal"); // Vízszintes mozgás (az x tengelyen)
        float moveY = Input.GetAxis("Vertical");   // Függőleges mozgás (az y tengelyen)

        // Mozgás irányának kiszámítása
        Vector2 movement = new Vector2(moveX, moveY); //átlósan is tudunk haladni ezzel

        // Mozgás végrehajtása
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
