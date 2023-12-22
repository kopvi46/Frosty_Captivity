using UnityEngine;
using UnityEngine.UI;

public class RangeEnemyBar : MonoBehaviour
{
    public Slider rangeEnemySlider;

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
