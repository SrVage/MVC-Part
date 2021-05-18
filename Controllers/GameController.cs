using System.Collections.Generic;
using UnityEngine;

namespace Code.BonusGame.Controllers
{
    public class GameController: MonoBehaviour
    {
        [SerializeField] private List<Sprite> _cell;
        [SerializeField] private GameObject _winAnimation;
        private Controllers _controllers;
        private float _deltaTime;

        private void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _cell, _winAnimation);
            _controllers.Initialization();
        }

        private void Update()
        {
            _deltaTime = Time.deltaTime;
            _controllers.Execute(_deltaTime);
        }
    }
}