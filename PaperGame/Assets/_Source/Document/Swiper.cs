using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Document
{
    public class Swiper : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private CanvasGroup _image;
        [SerializeField] private float _dissolveSpeed;
        private Vector3 _initialPosition;
        private float _distanceMoved;
        private bool _swipeLeft;
        private DocumentModel _documentModel;

        [Inject]
        public void Construct(DocumentModel documentModel)
        {
            _documentModel = documentModel;
            _initialPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

            if (transform.localPosition.x - _initialPosition.x > 0)
            {
                transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30,
                    (_initialPosition.x + transform.localPosition.x) / (Screen.width / 2)));
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30,
                    (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPosition.x);
            if (_distanceMoved < 0.4f * Screen.width)
            {
                transform.localPosition = _initialPosition;
                transform.localEulerAngles = Vector3.zero;
            }
            else
            {
                if (transform.localPosition.x > _initialPosition.x)
                    _swipeLeft = false;
                else
                    _swipeLeft = true;
                StartCoroutine(MovedCard(-_dissolveSpeed, 0));
            }
        }

        public void SetDocument()
        {
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = Vector3.zero;
            _documentModel.CreateData();
            StartCoroutine(MovedCard(_dissolveSpeed, 1));
        }

        private IEnumerator MovedCard(float dissolveSpeed, float result)
        {
            while (_image.alpha != result)
            {
                _image.alpha += dissolveSpeed;
                yield return new WaitForSeconds(0.05f);
            }
            if(result == 0)
            {
                _documentModel.CheckExit(_swipeLeft);
                SetDocument();
            }
        }
    }
}