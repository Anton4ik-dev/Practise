using UnityEngine;

namespace DataFactories
{
    public class MarkFactory
    {
        private const string TEXT_MESSAGE = "������� ������ ������ �� ���������";
        private bool _canBeWithMistake = false;

        public bool CreateMark(GameObject mark, bool isError = false)
        {
            if (isError == true && _canBeWithMistake == true)
            {
                mark.SetActive(false);
                return false;
            }
            mark.SetActive(true);
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