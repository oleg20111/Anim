using System.Collections;
using UnityEngine;

namespace MenuInteractiveBlocks
{
    public class InitialBlock : BaseMenuInteractiveBlock
    {
        [SerializeField] private NewSkinMenu _newSkinMenu;

        private bool _launchButtonActivate = true;

        public override void activate()
        {
            if (!_launchButtonActivate)
            {
                return;
            }
            StartCoroutine(nameof(ButtonTrue));

            base.activate();

            _newSkinMenu.show();
            
            _launchButtonActivate = false;
        }

        private IEnumerator ButtonTrue()
        {
            yield return new WaitForSeconds(1f);
            _launchButtonActivate = true;
        }
    }
}
