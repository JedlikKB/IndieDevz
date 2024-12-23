using NUnit.Framework;
using UnityEngine;

public class EleteroTest
{
    [Test]
    public void TakeDamage_ReducesHealth()
    {
        // Arrange
        var playerObject = new GameObject("Player"); // Új GameObject a játékosnak
        var playerHealth = playerObject.AddComponent<PlayerHealth>();

        // Létrehozzuk a Slider UI elemet és hozzárendeljük a PlayerHealth-hez
        var sliderObject = new GameObject("HealthBar");
        var slider = sliderObject.AddComponent<UnityEngine.UI.Slider>();
        playerHealth.healthSlider = slider;

        // Inicializáljuk az értékeket
        playerHealth.maxHealth = 100;
        playerHealth.Start(); // Meghívjuk a Start metódust az inicializáláshoz

        // Act
        playerHealth.TakeDamage(20);

        // Assert
        Assert.AreEqual(80, playerHealth.currentHealth);
    }
}
