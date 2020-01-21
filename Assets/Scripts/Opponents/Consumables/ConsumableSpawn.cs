using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSpawn : MonoBehaviour
{
    [Range(0,100)]
    public int ProbabilityDrop;
    public List<ConsumableType> Drops;
    private int overallProbability;

    private void Start()
    {
        foreach(ConsumableType drop in Drops)
        {
            drop.bottomLine = overallProbability;
            overallProbability += drop.Probability;
            drop.topLine = overallProbability;
        }
    }

    public void Spawn()
    {
        if (ProbabilityDrop != 0 && Random.Range(1, 100) <= ProbabilityDrop)
        {
            int result = Random.Range(1, overallProbability);
            foreach(ConsumableType drop in Drops)
            {
                if (result >= drop.bottomLine && result <= drop.topLine)
                {
                    Instantiate(drop.Object, transform.position, Quaternion.identity);
                    break ;
                }
            }
        }
    }
}
