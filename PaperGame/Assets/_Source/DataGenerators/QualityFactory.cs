using System.Collections.Generic;
using UnityEngine;

namespace DataFactories
{
    public class QualityFactory
    {
        public void CreateScratches(List<GameObject> scratches, bool isError = false)
        {
            for (int i = 0; i < scratches.Count; i++)
                scratches[i].SetActive(false);

            if (isError)
            {
                for (int i = 0; i < Random.Range(0, scratches.Count); i++)
                    scratches[i].SetActive(true);
            }
        }
    }
}