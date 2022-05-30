using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]private Image healthBar;
    private Health playerHealth;
    

    public float fillAmount;

    private void Awake()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    private void Update()
    {
        fillAmount = playerHealth.GetCurrentHealthPoints() / playerHealth.GetMaxHealthPoints();
        healthBar.fillAmount = fillAmount;
    }
}
