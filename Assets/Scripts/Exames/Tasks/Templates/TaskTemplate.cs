using UnityEngine;
using Random = System.Random;

namespace Exames.Tasks.Templates
{
    public abstract class TaskTemplate : ScriptableObject
    {
        [SerializeField] protected string question;
        [SerializeField] protected string[] correct;
        [SerializeField] protected string[] wrong;
        [SerializeField] protected bool balancePool = true;

        public abstract int MaxPoints { get; } 
        
        protected virtual bool IsBalanceAble => true;

        public abstract ITask Generate(Random random);
        
        protected string[] TryBalance(string[] toFill, string[] other)
        {
            if (!balancePool || !IsBalanceAble)
            {
                return toFill;
            }

            return Balanced(toFill, other);
        }

        public static string[] Balanced(string[] toFill, string[] other)
        {
            if (toFill.Length >= other.Length)
            {
                return toFill;
            }

            var balanced = new string[other.Length];
            var index = 0;
            for (var i = 0; i < balanced.Length; i++)
            {
                balanced[i] = toFill[index];
                if (++index >= toFill.Length)
                {
                    index = 0;
                }
            }

            return balanced;
        }
        
        public static void Shuffle<T> (T[] array, Random random)
        {
            var n = array.Length;
            while (n > 1) 
            {
                var k = random.Next(n--);
                (array[n], array[k]) = (array[k], array[n]);
            }
        }
    }
}