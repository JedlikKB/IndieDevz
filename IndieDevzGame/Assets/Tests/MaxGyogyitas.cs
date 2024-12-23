using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class MaxHealthTest
{
    [Test]
    public void Heal_DoesNotExceedMaxHealth()
    {
        // Arrange: L�trehozunk egy Player objektumot, �s inicializ�ljuk a sz�ks�ges mez�ket.
        var playerObject = new GameObject("Player");
        var playerHealth = playerObject.AddComponent<PlayerHealth>();

        playerHealth.maxHealth = 100; // Maxim�lis �leter�
        playerHealth.currentHealth = 95; // Kezd� �leter�

        // Slider hozz�ad�sa a teszthez.
        var healthBarObject = new GameObject("HealthBar");
        var slider = healthBarObject.AddComponent<Slider>();
        playerHealth.healthSlider = slider;

        // Act: Megpr�b�ljuk gy�gy�tani a j�t�kost.
        playerHealth.Heal(10); // Gy�gy�t�s, ami 105-re emeln� az �leter�t.

        // Assert: Az �leter� nem l�pheti t�l a maxim�lis �rt�ket.
        Assert.AreEqual(100, playerHealth.currentHealth, "The health should not exceed the maximum health.");
    }
}
