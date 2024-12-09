using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;           // Reference to the player's transform
    public float chaseDistance = 10f;  // Distance to start chasing the player
    public float attackDistance = 2f;  // Distance to attack the player
    public float attackCooldown = 2f;  // Time between attacks
    public int damage = 20;            // Damage dealt to the player

    private NavMeshAgent agent;        // NavMeshAgent reference
    private Animator animator;         // Animator reference
    private bool isAttacking;          // To prevent double attacks
    private float lastAttackTime;      // Timer for attack cooldown

    public SwordHitbox swordHitbox;    // Reference to the SwordHitbox for the enemy's sword

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Calculate distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Chase the player if within the chase range
        if (distanceToPlayer <= chaseDistance && distanceToPlayer > attackDistance)
        {
            agent.SetDestination(player.position);
            animator.SetFloat("Speed", agent.velocity.magnitude); // Walk animation
        }
        else if (distanceToPlayer <= attackDistance && Time.time >= lastAttackTime + attackCooldown)
        {
            // Stop moving and attack
            Attack();
        }
        else
        {
            // Stop moving if player is out of range
            agent.ResetPath();
            animator.SetFloat("Speed", 0f); // Idle animation
        }
    }

    // Triggers the attack
    private void Attack()
    {
        if (isAttacking) return;  // Prevent double attacks

        // Stop moving and face the player
        agent.isStopped = true;
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        // Trigger the swing animation
        animator.SetTrigger("Swing");
        swordHitbox.EnableHitbox();  // Enable the hitbox when the enemy swings
        Debug.Log("Enemy attacking!");

        // Start the attack cooldown
        lastAttackTime = Time.time;
    }

    // Called by Animation Event at the moment of impact
    public void ApplyDamage()
    {
        Debug.Log("Player hit!");

        // Assuming the player has a "PlayerHealth" component
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // Apply damage to the player
        }

        // Allow movement again
        agent.isStopped = false;
    }
}

