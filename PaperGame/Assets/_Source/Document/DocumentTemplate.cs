using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Document
{
    public class DocumentTemplate : Swiper
    {
        [SerializeField] private TextMeshProUGUI _date;
        [SerializeField] private GameObject _mark;
        [SerializeField] private GameObject _header;
        [SerializeField] private List<GameObject> _scratches;

        public TextMeshProUGUI Date
        {
            get => _date;
            set
            {
                _date = value;
            }
        }

        public GameObject Mark
        {
            get => _mark;
            set
            {
                _mark = value;
            }
        }

        public GameObject Header
        {
            get => _header;
            set
            {
                _header = value;
            }
        }

        public List<GameObject> Scratches
        {
            get => _scratches;
            set
            {
                _scratches = value;
            }
        }
    }
}