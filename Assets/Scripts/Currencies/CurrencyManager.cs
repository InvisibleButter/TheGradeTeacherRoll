using System;
using UnityEngine;

namespace Currencies
{
    public class CurrencyManager : MonoBehaviour
    {
        private const string KEY = "Currency";
        private static CurrencyManager Instance;

        [SerializeField] private int startMoney = 10;
        [SerializeField] private int weeklySalery = 10;

        private int _money;

        public event Action<int> OnMoneyChanged; 

        public int Money
        {
            get => _money;
            private set
            {
                var old = _money;
                _money = value;
                OnMoneyChanged?.Invoke(old);
            }
        }

        public int WeeklySalery => weeklySalery;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                throw new Exception("CurrencyManager already initzialised");
            }

            Instance = this;
            if(PlayerPrefs.HasKey(KEY))
            {
                Money = PlayerPrefs.GetInt(KEY);
            }
        }

        public bool Has(int amount)
        {
            return Money >= amount;
        }

        private void Validate(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("The amount cant be negative");
            }
        }

        public void Add(int amount)
        {
            Validate(amount);
            Money += amount;
        }
        
        public void Substract(int amount)
        {
            Validate(amount);
            if (!Has(amount))
            {
                throw new Exception("You dont have enought money");
            }
            Money -= amount;
        }

        public void Save()
        {
            PlayerPrefs.SetInt(KEY, Money);
        }

        public static string Display(int amount, int e = 0)
        {
            if (amount >= 1000 && e != 4)
            {
                return Display(amount / 1000, e + 1);
            }
      
            var suffix = GetEToDisplay(e);
            return amount + suffix;
        }

        private static string GetEToDisplay(int e)
        {
            return e switch
            {
                0 => "",
                1 => "k",
                2 => "m",
                3 => "b",
                _ => "t"
            };
        }
    }
}