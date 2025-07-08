using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private GameObject healthBarUI;

    void Start() {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    public void TakeDamage(float amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0,maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
    private void UpdateHealthBar() {
        float targetFillAmount = currentHealth / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;
        healthBarUI.SetActive(targetFillAmount < 1f);
    }

    
            
}
