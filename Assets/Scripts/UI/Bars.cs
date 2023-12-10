using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public Slider playerSlider;
    public Slider fireplaceSlider;
    public Slider torchSlider;
    public Slider meleeEnemySlider;
    public Slider rangeEnemySlider;

    public void SetMaxPlayerHealth(float MaxHealth)
    {
        playerSlider.maxValue = MaxHealth;
        playerSlider.value = MaxHealth;
    }

    public void SetPlayerHealth(float health)
    {
        playerSlider.value = health;
    }

    public void SetMaxFireplaceHealth(float MaxHealth)
    {
        fireplaceSlider.maxValue = MaxHealth;
        fireplaceSlider.value = MaxHealth;
    }

    public void SetFireplaceHealth(float health)
    {
        fireplaceSlider.value = health;
    }

    public void SetMaxTorchHealth(float MaxHealth)
    {
        torchSlider.maxValue = MaxHealth;
        torchSlider.value = MaxHealth;
    }

    public void SetTorchHealth(float health)
    {
        torchSlider.value = health;
    }

    public void SetMaxMeleeEnemyHealth(float MaxHealth)
    {
        meleeEnemySlider.maxValue = MaxHealth;
        meleeEnemySlider.value = MaxHealth;
    }

    public void SetMeleeEnemyHealth(float health)
    {
        meleeEnemySlider.value = health;
    }

    public void SetMaxRangeEnemyHealth(float MaxHealth)
    {
        rangeEnemySlider.maxValue = MaxHealth;
        rangeEnemySlider.value = MaxHealth;
    }

    public void SetRangeEnemyHealth(float health)
    {
        rangeEnemySlider.value = health;
    }
}
