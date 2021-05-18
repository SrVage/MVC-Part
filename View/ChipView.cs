using System;
using UnityEngine;

namespace Code.BonusGame.View
{
    public sealed class ChipView : MonoBehaviour
    {
        [SerializeField] private GameObject _arrows;
        [SerializeField] private Sprite[] _arrowsSprite;

        public void ChangeArrowVisible()
        {
            _arrows.gameObject.SetActive(!_arrows.gameObject.activeSelf);
        }

        public void DisableArrow()
        {
            _arrows.gameObject.SetActive(false);
        }
    }
}