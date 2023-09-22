using System.Collections;
using UnityEngine;

namespace MenuInteractiveBlocks
{
    public class BaseMenuInteractiveBlock:MonoBehaviour
    {
        // [SerializeField] private GameObject _button;
        [SerializeField] private Animator _buttonAnimator;

        private static readonly int ClickShow = Animator.StringToHash("click");
        
        public virtual bool isAvaiable()
        {
            return true;
        }

        public virtual void click()
        {
            _buttonAnimator.SetTrigger(ClickShow);
            StartCoroutine(nameof(WaitAnim));
        }

        private IEnumerator WaitAnim()
        {
            yield return new WaitForSeconds(0.35f);
            activate();
        }

        public virtual void activate()
        {
            // _button.SetActive(false);
        }
    }
}