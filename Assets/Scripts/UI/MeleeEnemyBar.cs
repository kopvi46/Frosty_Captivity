using UnityEngine;
using UnityEngine.UI;

public class MeleeEnemyBar : MonoBehaviour
{
    public Slider meleeEnemySlider;

    public void SetMaxMeleeEnemyHealth(float MaxHealth)
    {
        meleeEnemySlider.maxValue = MaxHealth;
        meleeEnemySlider.value = MaxHealth;
    }

    public void SetMeleeEnemyHealth(float health)
    {
        meleeEnemySlider.value = health;
    }
}
