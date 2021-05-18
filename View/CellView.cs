using System;
using UnityEngine;

namespace Code.BonusGame.View
{
    public class CellView:MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(gameObject.name);
        }
    }
}