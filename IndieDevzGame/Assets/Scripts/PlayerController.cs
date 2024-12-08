using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class PlayertController : MonoBehaviour
{
    
    public float moveSpeed = 5f; // A mozgás sebessége (a playert kiválasztva a scriptnél manuálisan változtatható)

    //----------------------------------------------Tüzelés---------------------------------------------------
    public GameObject projectilePrefab; // A lovedek prefab
    public Transform shootPoint;       // A kilovesi pont (allithato)
    public float fireRate = 0.5f;      // Idokoz ket loves kozott (masodpercben)
    private float nextFireTime = 0f;   // A kovetkezo loves idopontja

    void Shoot()                                                                                                        
    {
        // Lovedek kilovese
        Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
    }
    //--------------------------------------------------------------------------------------------------------

    private void Update()
    {
        // Bemeneti értékek beolvasása (W, A, S, D vagy a nyilak, unityben alapból meg vannak adva)
        float moveX = Input.GetAxis("Horizontal"); // Vízszintes mozgás (az x tengelyen)
        float moveY = Input.GetAxis("Vertical");   // Függőleges mozgás (az y tengelyen)

        // Mozgás irányának kiszámítása
        Vector2 movement = new Vector2(moveX, moveY); //átlósan is tudunk haladni ezzel

        // Mozgás végrehajtása
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        //-------------------------------------------------Tüzelés------------------------------------------------
        // Ha a Space lenyomva, es elerkezett a kovetkezo loves ideje (tudom kicsit erdekes de mukodik esku)
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Megadjuk a kovi loves idopontjat
        }
        //--------------------------------------------------------------------------------------------------------

    }
}
