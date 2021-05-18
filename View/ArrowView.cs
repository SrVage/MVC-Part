using UnityEngine;

namespace Code.BonusGame.View
{
    public class ArrowView:MonoBehaviour
    {
        [SerializeField] private Sprite[] _arrowsSprite;

        public void ChooseOn()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _arrowsSprite[1];
        }
        public void ChooseOff()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _arrowsSprite[0];
        }
    }
}