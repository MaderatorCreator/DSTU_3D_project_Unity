using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("посилання")]
    [SerializeField] private Health targetHealth; //скріпт health
    [SerializeField] private Slider healthSlider; //UI полоска здоров'я

    private void OnDestroy()
    {
        //відписатись від події після смерті
        if (targetHealth != null)
        {
            targetHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }

    //повідомлення: здоров'є змінено (авто-виклик)
    private void UpdateHealthBar(int newHealthValue)
    {
        healthSlider.value = newHealthValue;
    }
}
