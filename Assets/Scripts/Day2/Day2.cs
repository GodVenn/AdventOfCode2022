using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace Assets.Scripts.Day2
{
    internal class Day2 : MonoBehaviour
    {
        Dictionary<char, int> scores = new() { { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 } };

        private void Start()
        {
            ParseInput();
        }

        void ParseInput()
        {
            string day = nameof(Day2);

            string path = $"Assets/Scripts/{day}/input.txt";
            string[] lines = File.ReadAllLines(path);

            int score = 0;
            foreach (string line in lines)
            {
                char enemyChoice = line[0];
                enemyChoice += (char)23;
                char myChoice = line[2];
                Debug.Log(enemyChoice + " vs " + myChoice);
                score += scores[myChoice];

                if (myChoice == enemyChoice)
                    score += 3;
                else if (myChoice == 'X' && enemyChoice == 'Z' || myChoice == 'Y' && enemyChoice == 'X' || myChoice == 'Z' && enemyChoice == 'Y')
                    score += 6;

                Debug.Log(score);
            }

        }
    }
}
