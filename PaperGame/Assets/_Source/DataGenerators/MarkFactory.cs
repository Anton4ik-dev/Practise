using UnityEngine;

namespace DataFactories
{
    public class MarkFactory
    {
        public void CreateMark(GameObject mark, bool isError = false)
        {
            if (isError)
            {
                mark.SetActive(false);
                return;
            }
            mark.SetActive(true);
        }
    }
}