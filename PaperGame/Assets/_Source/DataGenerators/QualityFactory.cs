using System.Collections.Generic;
using UnityEngine;

namespace DataFactories
{
    public class QualityFactory
    {
        private const string TEXT_MESSAGE = "Документ должен быть чистым";
        private bool _canBeWithMistake = false;

        public bool CreateScratches(List<GameObject> scratches, bool isError = false)
        {
            for (int i = 0; i < scratches.Count; i++)
                scratches[i].SetActive(false);

            if (isError == true && _canBeWithMistake == true)
            {
                for (int i = 0; i < Random.Range(0, scratches.Count); i++)
                    scratches[i].SetActive(true);
                return false;
            }
            return true;
        }

        public string WriteMessage()
        {
            _canBeWithMistake = true;
            return TEXT_MESSAGE;
        }

        public void ResetMistake()
        {
            _canBeWithMistake = false;
        }
    }
}