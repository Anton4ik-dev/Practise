using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _image;
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

        if(transform.localPosition.x - _initialPosition.x > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30, 
                (_initialPosition.x + transform.localPosition.x)/(Screen.width/2)));
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
            if(transform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
            }
            else
            {
                _swipeLeft = true;
            }
            StartCoroutine(MovedCard());
        }
    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        while(_image.color != new Color(1,1,1,0))
        {
            time += Time.deltaTime;
            if(_swipeLeft)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x - Screen.width, 4 * time),
                    transform.localPosition.y, 0);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x + Screen.width, 4 * time),
                    transform.localPosition.y, 0);
            }
            _image.color = new Color(1,1,1, Mathf.SmoothStep(1, 0, 4 * time));
            yield return null;
        }
        gameObject.SetActive(false);
    }
}