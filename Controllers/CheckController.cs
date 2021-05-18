using System;
using System.Collections.Generic;
using Code.BonusGame.View;
using Code.Character_Selection_Scene.Model;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.BonusGame.Controllers
{
    public sealed class CheckController:IInitialization
    {
        public event Action<byte> Dice;
        private List<Item> _itemObj;
        private BonusUI _ui;
        private int _numOfWhiteDice;
        private int _numOfGoldenDice;

        public CheckController(List<Item> item)
        {
            _itemObj = item;
        }

        public void Initialization()
        {
            _ui = Object.FindObjectOfType<BonusUI>();
            foreach (var VARIABLE in _itemObj)
            {
                if (VARIABLE.Name == "Dice") _numOfWhiteDice = VARIABLE.Count;
                if (VARIABLE.Name == "GoldenDice") _numOfGoldenDice = VARIABLE.Count;
            }
            _ui.ChangeDice(_numOfWhiteDice, _numOfGoldenDice);
            _ui.ChooseDice += CheckDice;
        }

        private void CheckDice(byte dice)
        {
            if (dice == 1 && _numOfWhiteDice > 0)
            {
                Dice?.Invoke(1);
                _numOfWhiteDice--;
                foreach (var VARIABLE in _itemObj)
                {
                    if (VARIABLE.Name == "Dice") VARIABLE.Use();
                }
            }
            if (dice == 2 && _numOfGoldenDice > 0)
            {
                Dice?.Invoke(2);
                _numOfGoldenDice--;
                foreach (var VARIABLE in _itemObj)
                {
                    if (VARIABLE.Name == "GoldenDice") VARIABLE.Use();
                }
                _ui.GoldenDice();
            }
            if (dice>10) Dice?.Invoke(dice);
            _ui.ChangeDice(_numOfWhiteDice, _numOfGoldenDice);
        }
    }
}