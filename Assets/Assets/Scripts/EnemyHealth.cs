using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Animator animator;
    private NavMeshAgent agent;

    [Header("Ragdoll Settings")]
    public GameObject ragdollPrefab;  // Ragdoll prefab reference

    [Header("Physics Settings")]
    public float deathImpactThreshold = 5f;  // Minimum velocity for instant ragdoll

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Called when taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy took damage: {damage}, Current Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();  // Trigger death
        }
    }

    // Handle the enemy's death and spawn the ragdoll
    private void Die()
    {
        Debug.Log("Enemy died!");

        // Disable NavMeshAgent and Animator
        if (agent != null)
        {
            agent.isStopped = true;
            agent.enabled = false;
        }

        animator.enabled = false;

        // Instantiate the ragdoll at the enemy's current position and rotation
        GameObject ragdollInstance = Instantiate(
            ragdollPrefab,
            transform.position,
            transform.rotation
        );

        // Match the bone positions to ensure seamless appearance
        CopyTransforms(transform, ragdollInstance.transform);

        // Disable the original GameObject to avoid overlap
        gameObject.SetActive(false);
    }

    // Check for collisions with physics objects
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a Rigidbody
        Rigidbody rb = collision.rigidbody;

        if (rb != null)
        {
            float impactSpeed = collision.relativeVelocity.magnitude;

            Debug.Log($"Collided with {collision.gameObject.name} at speed {impactSpeed}");

            // Check if the collision speed exceeds the death threshold
            if (impactSpeed >= deathImpactThreshold)
            {
                Debug.Log("Fatal collision detected! Triggering ragdoll.");
                Die();
            }
        }
    }

    // Copy transforms from the original model to the ragdoll
    private void CopyTransforms(Transform original, Transform ragdoll)
    {
        for (int i = 0; i < original.childCount; i++)
        {
            Transform originalChild = original.GetChild(i);
            Transform ragdollChild = ragdoll.GetChild(i);

            ragdollChild.position = originalChild.position;
            ragdollChild.rotation = originalChild.rotation;

            // Recursively copy transforms for child bones
            if (originalChild.childCount > 0)
            {
                CopyTransforms(originalChild, ragdollChild);
            }
        }
    }
}


