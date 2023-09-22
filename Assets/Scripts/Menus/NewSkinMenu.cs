using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewSkinMenu:BaseMenu
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _lightsAnimator;
    [SerializeField] private float _hideDelay = 1f;

    private static readonly int AnimShow = Animator.StringToHash("show");
    private static readonly int AnimHide = Animator.StringToHash("hide");

    public override void show()
    {
        base.show();

        _animator.SetTrigger(AnimShow);
        _lightsAnimator.SetTrigger(AnimShow);

        StartCoroutine(nameof(WaitAndHide));
    }

    private IEnumerator WaitAndHide()
    {
        yield return new WaitForSeconds(_hideDelay);
        hide();
    }

    public override void hide()
    {
        base.hide();

        StopCoroutine(nameof(WaitAndHide));
        _animator.SetTrigger(AnimHide);
    }
}