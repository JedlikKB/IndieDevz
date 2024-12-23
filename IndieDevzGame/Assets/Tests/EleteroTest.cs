using NUnit.Framework;
using UnityEngine;

public class EleteroTest
{
    [Test]
    public void TakeDamage_ReducesHealth()
    {
        // Arrange
        var playerObject = new GameObject("Player"); // �j GameObject a j�t�kosnak
        var playerHealth = playerObject.AddComponent<PlayerHealth>();

        // L�trehozzuk a Slider UI elemet �s hozz�rendelj�k a PlayerHealth-hez
        var sliderObject = new GameObject("HealthBar");
        var slider = sliderObject.AddComponent<UnityEngine.UI.Slider>();
        playerHealth.healthSlider = slider;

        // Inicializ�ljuk az �rt�keket
        playerHealth.maxHealth = 100;
        playerHealth.Start(); // Megh�vjuk a Start met�dust az inicializ�l�shoz

        // Act
        playerHealth.TakeDamage(20);

        // Assert
        Assert.AreEqual(80, playerHealth.currentHealth);
    }
}
