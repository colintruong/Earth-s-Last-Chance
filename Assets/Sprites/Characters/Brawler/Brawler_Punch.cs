using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Brawler_Punch : MonoBehaviour {
    public float detectionRadius = 0.5f;
    public LayerMask enemyLayer;
    [SerializeField] public float punchDamage;

    private Animator animator;
    private Brawler_Move moveScript;
    private bool isPunching = false;
    private Collider2D currentEnemy = null;

    void Start() {
        animator = GetComponent<Animator>();
        moveScript = GetComponent<Brawler_Move>();
    }

    void Update() {
        if (isPunching) return;

        Collider2D enemy = Physics2D.OverlapCircle(transform.position, detectionRadius, enemyLayer);

        if (enemy != null) {
            currentEnemy = enemy;
            isPunching = true;
            moveScript.enabled = false;
            animator.SetBool("Attacking", true);
        }
    }
    public void PunchDamageEvent() {
        if (currentEnemy == null) return;

        HealthBar health = currentEnemy.GetComponent<HealthBar>();
        if (health != null) {
            health.TakeDamage(punchDamage);

            // Stop punching if enemy is destroyed
            if (currentEnemy == null || currentEnemy.gameObject == null) {
                animator.SetBool("Attacking", false);
                moveScript.enabled = true;
                isPunching = false;
                currentEnemy = null;
            }
        }
    }

    public void PunchAnimationEndEvent() {
        if (currentEnemy == null) {
            animator.SetBool("Attacking", false);
            moveScript.enabled = true;
            isPunching = false;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
