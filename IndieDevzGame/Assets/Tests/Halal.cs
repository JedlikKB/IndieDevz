using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathTest
{
    [Test]
    public void Player_Dies_WhenHealthReachesZero()
    {
        // Arrange
        var playerObject = new GameObject("Player");
        var playerHealth = playerObject.AddComponent<PlayerHealth>();

        // Létrehozunk egy Slider-t a healthBar-hoz
        var sliderObject = new GameObject("HealthBar");
        var slider = sliderObject.AddComponent<Slider>();
        playerHealth.healthSlider = slider;

        playerHealth.maxHealth = 100;
        playerHealth.currentHealth = 10;

        // Act
        playerHealth.TakeDamage(10);

        // Assert
        Assert.AreEqual(0, playerHealth.currentHealth, "The player's health should be 0 after taking damage.");
        Assert.IsTrue(playerHealth.IsDead(), "The player should be marked as dead.");
    }
}
