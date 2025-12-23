using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour {
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private GameObject healthBarUI;
    [SerializeField] private float fillSpeed;
    [SerializeField] private Gradient colorGradient;

    private Tween fillTween;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        UpdateHealthBar();
    }
    public void TakeDamage(float amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0,maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0) {
            if (fillTween != null && fillTween.IsActive()) {
                fillTween.Kill();
            }
            Destroy(gameObject);
        }
    }
    private void UpdateHealthBar() {
        float targetFillAmount = currentHealth / maxHealth;
        if (fillTween != null && fillTween.IsActive()) {
            fillTween.Kill();
        }
        fillTween = healthBarFill.DOFillAmount(targetFillAmount, fillSpeed).SetEase(Ease.OutQuad);
        if (currentHealth == maxHealth) {
            healthBarUI.SetActive(false);
        } else {
            healthBarUI.SetActive(targetFillAmount < 1f);
        }
        healthBarFill.color = colorGradient.Evaluate(targetFillAmount);
    }

    
            
}
