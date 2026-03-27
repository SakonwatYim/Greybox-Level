using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    public float boostAmount = 3f;
    public float duration = 4f;

    void OnTriggerEnter(Collider other)
    {
        PlayerSpeed player = other.GetComponent<PlayerSpeed>();

        if (player != null)
        {
            player.SpeedBoost(boostAmount, duration);
        }
    }
}