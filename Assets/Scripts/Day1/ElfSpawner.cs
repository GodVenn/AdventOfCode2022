using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Day1
{
    [RequireComponent(typeof(Day1))]
    internal class ElfSpawner : MonoBehaviour
    {
        public GameObject ElfPrefab;
        private Day1 solution;
        private int currentElfCount = 0;
        private float delay = 0.5f;

        private List<int> elvesToSpawn;
        private List<Elf> elves = new List<Elf>();
        bool spawned = false;
        bool finished = false;

        private void Start()
        {
            solution = GetComponent<Day1>();
            elvesToSpawn = solution.Elves.Take(11).ToList();
            StartCoroutine(SpawnElves());
        }

        private void Update()
        {
            if (!spawned)
                return;

            if (finished)
                return;

            if (elves.Count(x => x.Score > 0) == 1)
            {
                var winner = elves.FirstOrDefault(x => x.Score > 0);
                winner.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                finished = true;
                return;
            }

            foreach (var elf in elves)
            {
                elf.Score -= 10;
            }

        }

        IEnumerator SpawnElves()
        {
            foreach (var elf in elvesToSpawn)
            {
                elves.Add(SpawnElf(elf));
                yield return new WaitForSeconds(delay);
            }
            spawned= true;
        }

        private Elf SpawnElf(int elfCalories)
        {
            Vector3 pos = new Vector3(-10 + currentElfCount*2, -2.56f, 0);
            Elf elf = Instantiate(ElfPrefab, pos, Quaternion.identity).GetComponent<Elf>();
            elf.Score = elfCalories;
            currentElfCount++;
            return elf;
        }
    }
}
