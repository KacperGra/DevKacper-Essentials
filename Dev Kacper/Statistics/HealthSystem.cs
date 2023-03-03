using System;
using UnityEngine;

namespace DevKacper.Gameplay
{
    public class HealthSystem
    {
        public event Action OnDeath;

        public event Action OnHealthChanged;

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

            OnHealthChanged?.Invoke();
        }

        public void Heal(int value)
        {
            Health += value;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            OnHealthChanged?.Invoke();
        }

        public void ChangeMaxHealth(int health, bool setHealthEqualToMax = false)
        {
            MaxHealth = health;
            if (setHealthEqualToMax)
            {
                Health = MaxHealth;
            }

            OnHealthChanged?.Invoke();
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
            return $"{Health}/{MaxHealth}";
        }
    }
}