using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace Assets.Scripts.Day1
{
    public class Day1 : MonoBehaviour
    {
        public List<int> Elves = new List<int>();

        // Start is called before the first frame update
        void Awake()
        {
            ParseInput();
            int topThreeMax = Elves.OrderByDescending(x => x).Take(3).Sum(x => x);
            Debug.Log(topThreeMax);
        }

        void ParseInput()
        {
            string day = nameof(Day1);

            string path = $"Assets/Scripts/{day}/input.txt";
            string[] lines = File.ReadAllLines(path);

            int currentElf = 0;
            Elves.Add(0);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    currentElf++;
                    Elves.Add(0);
                }
                else
                {
                    Elves[currentElf] += int.Parse(line);
                }
            }

        }
    }

}