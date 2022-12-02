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
        Dictionary<char, int> scores = new() { { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

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
                char result = line[2];


                char myChoice;
                if (result == 'Y')
                {
                    score += 3;
                    myChoice = enemyChoice;
                }
                else if (result == 'Z')
                {
                    score += 6;
                    myChoice = (char)(enemyChoice + 1);
                    if (myChoice > 'C')
                        myChoice = 'A';
                }
                else
                {
                    myChoice = (char)(enemyChoice - 1);
                    if (myChoice < 'A')
                        myChoice = 'C';
                }

                score += scores[myChoice];
            }
            Debug.Log(score);

        }
    }
}
