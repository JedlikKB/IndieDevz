using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class GyogyitasTest
{
    [Test]
    public void Heal_IncreasesHealth()
    {
        // Arrange
        var playerObject = new GameObject("Player");
        var playerHealth = playerObject.AddComponent<PlayerHealth>();

        // Health bar setup
        var sliderObject = new GameObject("HealthBar");
        var slider = sliderObject.AddComponent<UnityEngine.UI.Slider>();
        playerHealth.healthSlider = slider;

        playerHealth.maxHealth = 100;
        playerHealth.Start();

        // Set current health to a lower value
        playerHealth.TakeDamage(50);

        // Act
        playerHealth.Heal(30);

        // Assert
        Assert.AreEqual(80, playerHealth.currentHealth);
    }
}
