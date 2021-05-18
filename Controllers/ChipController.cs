using System;
using Code.BonusGame.Model;
using Code.BonusGame.View;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Code.BonusGame.Controllers
{
    public sealed class ChipController : IExecute, IInitialization
    {

        public event Action<Code.BonusGame.Model.Vector3> ChipPosition;
        
        private Camera _mainCamera;
        private byte direction=0;
        private byte _dice = 0;
        private ChipView _chipView;
        private Transform _chip;
        private CheckController _checkController;
        private BonusUI _ui;
        private int planeOfDice=0;
        private ChipModel _chipModel;
        public ChipController(Camera camera, CheckController checkController)
        {
            _mainCamera = camera;
            _checkController = checkController;
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
                if (hit.collider == null) return;
                if (hit.collider.gameObject.TryGetComponent<ChipView>(out ChipView _chip))
                {
                    _chip.ChangeArrowVisible();
                }
                else if (hit.collider.gameObject.CompareTag("Arrow"))
                {
                    for (int i = 0; i < hit.collider.gameObject.transform.parent.childCount; i++)
                    {
                        hit.collider.gameObject.transform.parent.GetChild(i).GetComponent<ArrowView>().ChooseOff();
                    }
                    hit.collider.gameObject.GetComponent<ArrowView>().ChooseOn();
                    ChooseDirection(hit);
                    if (_dice !=0) MoveChip(_dice, direction);
                }
            }
            if (Input.GetKeyDown(KeyCode.P)) SceneManager.LoadScene(0);
        }

        private void ChooseDirection(RaycastHit2D hit)
        {
            switch (hit.collider.gameObject.name)
            {
                case "leftArrow":
                    direction = 1;
                    break;
                case "rightArrow":
                    direction = 2;
                    break;
                case "upArrow":
                    direction = 3;
                    break;
                case "downArrow":
                    direction = 4;
                    break;
            }
        }

        private void GetDice(byte dice)
        {
            if (dice == 2) return;
            _dice = dice;
            if (direction!=0) MoveChip(_dice, direction);
        }

        public void Initialization()
        {
            _chipModel = new ChipModel();
            _chip = Object.FindObjectOfType<ChipView>().transform;
            _chip.position =new Vector3(_chipModel.Position.x, _chipModel.Position.y, _chipModel.Position.z);
            _chipView = Object.FindObjectOfType<ChipView>().GetComponent<ChipView>();
            _checkController.Dice += GetDice;
            _ui = Object.FindObjectOfType<BonusUI>();
        }

        private void MoveChip(byte dice, byte direction)
        {
            if (dice == 1) GenerateDice();
            else planeOfDice = dice - 10;
            _chipModel.MoveChip(direction, planeOfDice);
            _chip.position= new Vector3(_chipModel.Position.x, _chipModel.Position.y, _chipModel.Position.z);
            ChipPosition(_chipModel.Position);
            _dice = 0;
            this.direction = 0;
            for (int i = 0; i < _chipView.gameObject.transform.GetChild(0).gameObject.transform.childCount; i++)
            {
                _chipView.gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).GetComponent<ArrowView>().ChooseOff();
            }
            _chipView.DisableArrow();
        }

        private void GenerateDice()
        {
            planeOfDice = Random.Range(1, 7);
            _ui.WhiteDice(planeOfDice);
        }
    }
}