using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Brawler_Punch : MonoBehaviour {
    public float detectionRadius = 0.5f;
    public LayerMask enemyLayer;

    private Animator animator;
    private Brawler_Move moveScript;
    private bool isPunching = false;
    private Collider2D currentEnemy = null;

    void Start() {
        animator = GetComponent<Animator>();
        moveScript = GetComponent<Brawler_Move>();
    }

    void Update() {
        if (isPunching) return; // Ignore detection during punch

        // Check for nearby enemies
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, detectionRadius, enemyLayer);

        if (enemy != null) {
            currentEnemy = enemy;
            isPunching = true;
            moveScript.enabled = false;
            animator.SetBool("Attacking", true);
            StartCoroutine(PerformPunchRoutine());
        }
    }

    private IEnumerator PerformPunchRoutine() {
        yield return new WaitForSeconds(3f); // Wait 3 seconds

        if (currentEnemy != null) {
            Destroy(currentEnemy.gameObject); // Remove enemy
        }

        isPunching = false;
        animator.SetBool("Attacking", false);
        moveScript.enabled = true; // Resume walking
        currentEnemy = null;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
