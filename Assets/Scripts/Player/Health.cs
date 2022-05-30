using GameDevTV.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Health : MonoBehaviour
    {
        private PlayerStats playerStats;
        private LazyValue<float> healthPoints;
        public UnityEvent onDie;
        [HideInInspector]public float damageFormula;

        
        private bool wasDeadLastFrame;

        // LIFECYCLE METHODS
        private void Awake()
        {
            playerStats = GetComponent<PlayerStats>();
            healthPoints = new LazyValue<float>(GetInitialHealth);
        }
        

        // PRIVATE
        private float GetInitialHealth()
        {
            return GetComponent<PlayerStats>().GetStat(Stat.PlayerMaxHealth);
        }

        private void Start()
        {
            healthPoints.ForceInit();
        }

        private void UpdateState()
        {
            Animator animator = GetComponent<Animator>();
            if (!wasDeadLastFrame && IsDead())
            {
                // Add dead anim trigger
            }

            wasDeadLastFrame = IsDead();
        }

        // PUBLIC

        public bool IsDead()
        {
            return healthPoints.value <= 0;
        }

        public void TakeDamage(float damage)
        {
            damageFormula = damage * (1f - playerStats.GetStat(Stat.PlayerArmor)/100);
            //damageFormula = damage * (100/(100+playerStats.GetStat(Stat.PlayerArmor)));
            //Debug.Log(damageFormula);
            healthPoints.value = Mathf.Max(healthPoints.value - damageFormula, 0);
            print(gameObject.name +" took " + damage + " net damage. Player Armor: " + playerStats.GetStat(Stat.PlayerArmor) + " Damage with armor in consideration is " + damageFormula + ". Remaining HP is " + GetCurrentHealthPoints());

            if (IsDead())
            {
                onDie.Invoke();
            }
            
            UpdateState();
        }

        public float GetCurrentHealthPoints()
        {
            return healthPoints.value;
        }

        public float GetMaxHealthPoints()
        {
            return GetComponent<PlayerStats>().GetStat(Stat.PlayerMaxHealth);
        }
    }
}