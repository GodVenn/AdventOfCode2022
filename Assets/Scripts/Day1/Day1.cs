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
        List<int> elves = new List<int>();

        // Start is called before the first frame update
        void Start()
        {
            ParseInput();
            int topThreeMax = elves.OrderByDescending(x => x).Take(3).Sum(x => x);
            Debug.Log(topThreeMax);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void ParseInput()
        {
            string day = nameof(Day1);

            string path = $"Assets/Scripts/{day}/input.txt";
            string[] lines = File.ReadAllLines(path);

            int currentElf = 0;
            elves.Add(0);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    currentElf++;
                    elves.Add(0);
                }
                else
                {
                    elves[currentElf] += int.Parse(line);
                }
            }

        }
    }

}