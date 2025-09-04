using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Gameplay gameplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameplay.ReceiveDamage(10);
        }
    }
}
