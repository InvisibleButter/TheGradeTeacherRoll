using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Students
{
public class NameGenerator : MonoBehaviour
	{
        public String[] firstNames;
        public String[] lastNames;

        private Random _random;

        private void Awake()
        {
	        _random = new Random();
        }

        public string GetName()
        {
	        return firstNames[_random.Next(firstNames.Length)] + " " + lastNames[_random.Next(lastNames.Length)];
        }
	}
}