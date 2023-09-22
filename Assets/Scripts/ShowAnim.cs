using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ShowAnim:MonoBehaviour
{
    [SerializeField] private float _delay = 0.15f;
    [SerializeField] private float _scaleIn = 1.3f;
    [SerializeField] private float _scaleInTime = 0.2f;
    [SerializeField] private float _scaleOut = 1f;
    [SerializeField] private float _scaleOutTime = 0.15f;

    Vector2 startScale;
    Animator animController;

    private void OnEnable()
    {
        Show();
    }

    public void Show()
    {
        startScale = transform.localScale;

        animController = GetComponent<Animator>();
        if(animController != null)
        {
            animController.enabled = false;
        }

        Vector2 currentScale = startScale;
        currentScale.x = 0f;
        currentScale.y = 0f;
        transform.localScale = currentScale;

        StartCoroutine("waitAndShow");
    }

    IEnumerator waitAndShow()
    {
        yield return new WaitForSeconds(_delay);

        animate();
    }

    void animate()
    {
        transform.localScale = startScale;

        Sequence tween = DOTween.Sequence();
        tween.Append(transform.DOScale(_scaleIn, _scaleInTime));
        tween.Append(transform.DOScale(_scaleOut, _scaleOutTime));
        tween.OnComplete(complete);
    }

    void complete()
    {
        if(animController != null)
        {
            animController.enabled = true;
        }
    }
}
