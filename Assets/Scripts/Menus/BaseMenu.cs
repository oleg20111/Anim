using System.Collections;
using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    [SerializeField] private float _disableTimeout = 0.5f;

    private bool _initialized;

    public virtual void show()
    {
        StopCoroutine(nameof(WaitAndDisable));

        if (!_initialized)
        {
            _initialized = true;
            init();
        }

        gameObject.SetActive(true);
    }

    public virtual void init()
    {
    }

    public virtual void hide()
    {
        StopCoroutine(nameof(WaitAndDisable));
        StartCoroutine(nameof(WaitAndDisable));
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(_disableTimeout);
        gameObject.SetActive(false);
    }
}