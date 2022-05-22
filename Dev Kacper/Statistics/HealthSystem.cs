using System;

namespace DevKacper.Mechanic
{
    public class HealthSystem
    {
        public event Action OnDeath;

        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public HealthSystem(int healthValue)
        {
            MaxHealth = healthValue;
            Health = healthValue;
        }

        public void TakeDamage(int value)
        {
            Health -= value;
            if (Health <= 0)
            {
                OnDeath?.Invoke();
            }
        }

        public void Heal(int value)
        {
            Health += value;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public void ChangeMaxHealth(int health, bool SetHealthEqualToMax = false)
        {
            MaxHealth = health;
            if (SetHealthEqualToMax)
            {
                Health = MaxHealth;
            }
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public float GetHealthRatio()
        {
            return (float)Health / MaxHealth;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Health.ToString(), MaxHealth.ToString());
        }
    }
}