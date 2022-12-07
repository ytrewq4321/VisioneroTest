using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbarSprite;
    [SerializeField] private float reduceSpeed = 2f;
    private float target = 1f;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
        healthbarSprite.fillAmount = Mathf.MoveTowards(healthbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }

    public void UpdateHealtbar(float maxHealth,float currentHealth)
    {
        target = currentHealth / maxHealth;
    }
}
