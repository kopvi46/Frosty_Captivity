using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public Slider _playerSlider;
    public Slider _fireplaceSlider;
    public Slider _torchSlider;
    public Slider _meleeEnemySlider;

    public void SetMaxPlayerHealth(float MaxHealth)
    {
        _playerSlider.maxValue = MaxHealth;
        _playerSlider.value = MaxHealth;
    }

    public void SetPlayerHealth(float health)
    {
        _playerSlider.value = health;
    }

    public void SetMaxFireplaceHealth(float MaxHealth)
    {
        _fireplaceSlider.maxValue = MaxHealth;
        _fireplaceSlider.value = MaxHealth;
    }

    public void SetFireplaceHealth(float health)
    {
        _fireplaceSlider.value = health;
    }

    public void SetMaxTorchHealth(float MaxHealth)
    {
        _torchSlider.maxValue = MaxHealth;
        _torchSlider.value = MaxHealth;
    }

    public void SetTorchHealth(float health)
    {
        _torchSlider.value = health;
    }

    public void SetMaxMeleeEnemyHealth(float MaxHealth)
    {
        _meleeEnemySlider.maxValue = MaxHealth;
        _meleeEnemySlider.value = MaxHealth;
    }

    public void SetMeleeEnemyHealth(float health)
    {
        _meleeEnemySlider.value = health;
    }
}
