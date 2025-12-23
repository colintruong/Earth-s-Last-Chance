using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attack : MonoBehaviour {
    [Header("Attack Settings")]
    public float detectionRadius;
    public LayerMask enemyLayer;
    public float damage;
    public string attackAnimBool = "Attacking";

    [Header("Movement Control")]
    public MonoBehaviour movementScript;

    private Animator animator;
    private bool isAttacking = false;
    private Collider2D currentTarget = null;

    void Start() {
        animator = GetComponent<Animator>();
        if (movementScript == null) {
            Debug.LogWarning("Movement script not assigned!");
        }
    }

    void Update() {
        if (isAttacking) return;

        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRadius, enemyLayer);

        if (target != null) {
            currentTarget = target;
            isAttacking = true;
            if (movementScript != null) {
                movementScript.enabled = false;
            }
            animator.SetBool(attackAnimBool, true);
        }
    }

    public void AttackDamageEvent() {
        if (currentTarget == null) return;

        HealthBar health = currentTarget.GetComponentInParent<HealthBar>();
        if (health != null) {
            health.TakeDamage(damage);
        }
    }

    public void AttackAnimationEndEvent() {
        animator.SetBool(attackAnimBool, false);
        if (movementScript != null) {
            movementScript.enabled = true;
        }
        isAttacking = false;
        currentTarget = null;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
