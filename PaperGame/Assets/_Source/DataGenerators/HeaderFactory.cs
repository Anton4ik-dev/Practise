using UnityEngine;

namespace DataFactories
{
    public class HeaderFactory
    {
        private const string TEXT_MESSAGE = "Наличие заголовка у документа";
        private bool _canBeWithMistake = false;

        public bool CreateHeader(GameObject mark, bool isError = false)
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