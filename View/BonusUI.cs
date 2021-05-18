using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.BonusGame.View
{
    public sealed class BonusUI:MonoBehaviour
    {
        public event Action<byte> ChooseDice;
        public event Action<byte, Vector3> Reward;

        [SerializeField] private Text _whiteDice;
        [SerializeField] private Text _goldenDice;
        [SerializeField] private Image _whiteDiceImage;
        [SerializeField] private Image _goldenDiceImage;
        [SerializeField] private List<Sprite> _listOfWhiteDice;
        [SerializeField] private List<Sprite> _listOfGoldenDice;
        [SerializeField] private GameObject _start;
        private byte _goldNum = 1;
        

        public void ChooseWhiteDice()
        {
            DisableImageDice();
            ChooseDice?.Invoke(1);
        }
        public void ChooseGoldenDice()
        {
            DisableImageDice();
            ChooseDice?.Invoke(2);
        }

        public void ChangeDice(int whiteDice, int goldenDice)
        {
            _whiteDice.text = whiteDice.ToString();
            _goldenDice.text = goldenDice.ToString(); 
        }

        public void WhiteDice(int num)
        {
            _whiteDiceImage.gameObject.SetActive(true);
            _whiteDiceImage.sprite = _listOfWhiteDice[num - 1];
        }

        public void GoldenDice()
        {
            _start.SetActive(true);
            _goldenDiceImage.gameObject.SetActive(true);
            _goldenDiceImage.sprite = _listOfGoldenDice[0];
        }

        public void ChangeGoldenDice()
        {
            _goldNum++;
            if (_goldNum > 6) _goldNum = 1;
            _goldenDiceImage.sprite = _listOfGoldenDice[_goldNum-1];
        }

        private void DisableImageDice()
        {
            _goldenDiceImage.gameObject.SetActive(false);
            _whiteDiceImage.gameObject.SetActive(false);
            _start.SetActive(false);
        }

        public void StartGoldenDice()
        {
            _goldNum += 10;
            ChooseDice?.Invoke(_goldNum);
            _start.SetActive(false);
        }

        public void GetReward(byte num, Vector3 pos)
        {
            Reward?.Invoke(num, pos);
        }
    }
}