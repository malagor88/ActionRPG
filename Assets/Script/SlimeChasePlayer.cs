using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SlimeChasePlayer : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;
    public Image hpBar;
    public float hp = 100f;

    public float stopDistance = 1f;
    public float detectionRange = 10f;

    Animator anim;
    bool isPlayerInRange = false;
    bool hasReachePlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        isPlayerInRange = distance <= detectionRange;
        if (isPlayerInRange)
        {  
            if (distance <= stopDistance)
            {
                StopMoving();
                hasReachePlayer = true;
            }
            else
            {
                MoveToPlayer();
                hasReachePlayer = false;
            }
        }
        else
        {
            StopMoving();
        }
        UpdateAnimation();
        UpdateUI();
    }
    void MoveToPlayer()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.SetDestination(player.transform.position);
            hasReachePlayer = false;
        }
    }
    void StopMoving()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.ResetPath();
            hasReachePlayer = true;
        }
    }
    void UpdateAnimation()
    {
        anim.SetBool("Atteck", !hasReachePlayer);
    }

    void UpdateUI()
    {
        hpBar.fillAmount = hp / 100f;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            hp -= 30f;
        }
    }
}
