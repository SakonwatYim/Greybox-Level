using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider hpSlider;

    void Start()
    {
        hpSlider.maxValue = playerHealth.maxHP;
    }

    void Update()
    {
        hpSlider.value = playerHealth.currentHP;
    }
}