using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class MaxHealthTest
{
    [Test]
    public void Heal_DoesNotExceedMaxHealth()
    {
        // Arrange: Létrehozunk egy Player objektumot, és inicializáljuk a szükséges mezõket.
        var playerObject = new GameObject("Player");
        var playerHealth = playerObject.AddComponent<PlayerHealth>();

        playerHealth.maxHealth = 100; // Maximális életerõ
        playerHealth.currentHealth = 95; // Kezdõ életerõ

        // Slider hozzáadása a teszthez.
        var healthBarObject = new GameObject("HealthBar");
        var slider = healthBarObject.AddComponent<Slider>();
        playerHealth.healthSlider = slider;

        // Act: Megpróbáljuk gyógyítani a játékost.
        playerHealth.Heal(10); // Gyógyítás, ami 105-re emelné az életerõt.

        // Assert: Az életerõ nem lépheti túl a maximális értéket.
        Assert.AreEqual(100, playerHealth.currentHealth, "The health should not exceed the maximum health.");
    }
}
