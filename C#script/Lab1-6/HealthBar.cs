using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public static int currentHealth;
    public int healthMax;
    private Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        currentHealth = healthMax;

    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (float)currentHealth / healthMax;
        healthText.text = currentHealth.ToString() + "/" + healthMax.ToString();
        if (currentHealth > healthMax)
        {
            currentHealth = healthMax;
        }
    }
}
