using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Students
{
public class NameGenerator : MonoBehaviour
	{
        public String[] firstNames;
        public String[] lastNames;

        public string getName()
        {
	        var random = new System.Random();
	        return firstNames[random.Next(firstNames.Length)] + " " + lastNames[random.Next(lastNames.Length)];
        }
	}
}