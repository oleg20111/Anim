using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

namespace Vivat
{
    public class DelayButton:MonoBehaviour
    {
        [SerializeField] private float _delay = 0.1f;
        [SerializeField] private UnityEvent _onStartEvent;
        [SerializeField] private UnityEvent _onCompleteEvent;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => OnClick());
        }

        void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(() => OnClick());
        }

        public void OnClick()
        {
            if(_onStartEvent != null)
            {
                _onStartEvent.Invoke();
            }

            //SoundManager.instance.playSfx("c1");
            StartCoroutine("StartAnim");
        }

        IEnumerator StartAnim()
        {
            yield return new WaitForSeconds(_delay);
            CompleteAnim();
        }

        void CompleteAnim()
        {
            if(_onCompleteEvent != null)
            {
                _onCompleteEvent.Invoke();
            }
        }
    }
}