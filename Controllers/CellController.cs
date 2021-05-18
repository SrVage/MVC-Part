using System;
using System.Collections.Generic;
using Code.BonusGame.Model;
using Code.BonusGame.TimeRemaining;
using Code.BonusGame.View;
using Code.Character_Selection_Scene.Model;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using Vector3 = Code.BonusGame.Model.Vector3;

namespace Code.BonusGame.Controllers
{
    public sealed class CellController:IInitialization
    {
        private EventsController _eventsController;
        private byte[,] _cells;
        private BonusUI _ui;
        private List<Item> _itemObj;
        private GameObject _winAnimation;
        protected ITimeRemaining _timeRemaining;
        private string _item = String.Empty;
        private Code.BonusGame.Model.Vector3 _position;
        public CellController(byte[,] cells, EventsController eventsController, GameObject winAnimation, List<Item> itemObj)
        {
            this._cells = cells;
            _eventsController = eventsController;
            _winAnimation = winAnimation;
            _itemObj = itemObj;
        }

        public void Initialization()
        {
            _eventsController.ChooseCell += ChooseCell;
            _timeRemaining = new TimeRemaining.TimeRemaining(CreateItem, 1.0f);
        }

        private void ChooseCell(Code.BonusGame.Model.Vector3 positionChip)
        {
            if (_cells[(int) positionChip.x, (int) positionChip.y] != 0)
            {
                Reward(_cells[(int) positionChip.x, (int) positionChip.y], positionChip);
                _cells[(int) positionChip.x, (int) positionChip.y] = 0;
                Destroys((int) positionChip.x, (int) positionChip.y);
                var anim = GameObject.Instantiate(_winAnimation, new UnityEngine.Vector3(positionChip.x, positionChip.y-0.9f, positionChip.z-5),
                    Quaternion.identity);
                GameObject.Destroy(anim, 3.0f);
            }
        }
        
        private void Reward(byte cell, Code.BonusGame.Model.Vector3 position)
        {
            _position = position;
            _item = GetItem(cell, _item);
            _timeRemaining.AddTimeRemaining();
            foreach (var VARIABLE in _itemObj)
            {
                if (VARIABLE.Name == _item) VARIABLE.Add(1);
            }
            ListOfItem.SetItem(_itemObj);
        }

        private static string GetItem(byte cell, string item)
        {
           int a; 
            switch (cell)
            {
                case 1:
                    item = "Energy";
                    break;
                case 2:
                    a = Random.Range(1, 7);
                    switch (a)
                    {
                        case 1:
                            item = "Air";
                            break;
                        case 2:
                            item = "Water";
                            break;
                        case 3:
                            item = "Fire";
                            break;
                        case 4:
                            item = "Ground";
                            break;
                        case 5:
                            item = "Dark";
                            break;
                        case 6:
                            item = "Shine";
                            break;
                    }

                    break;
                case 3:
                    a = Random.Range(1, 7);
                    switch (a)
                    {
                        case 1:
                            item = "SoulAir";
                            break;
                        case 2:
                            item = "SoulWater";
                            break;
                        case 3:
                            item = "SoulFire";
                            break;
                        case 4:
                            item = "SoulGround";
                            break;
                        case 5:
                            item = "SoulDark";
                            break;
                        case 6:
                            item = "SoulShine";
                            break;
                    }

                    break;
            }

            return item;
        }

        private void CreateItem()
        {
            foreach (var VARIABLE in ListOfItem.GetList())
            {
                if (VARIABLE.Name== _item)
                {
                    var item = new GameObject("anim", typeof(SpriteRenderer));
                    item.GetComponent<SpriteRenderer>().sprite = VARIABLE.Icon;
                    item.transform.position = new UnityEngine.Vector3(_position.x, _position.y, _position.z - 1);
                    item.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                    GameObject.Destroy(item, 2f);
                }
            }
        }
        
        private void Destroys(int i, int j)
        {
            if (_cells[i, j] == 0)
            {
                var del =GameObject.Find("cell-" + i + "-" + j);
                del.transform.position -= new UnityEngine.Vector3(0, 0, 3);
                Object.Destroy(del, 3.0f);
            }
        }
    }
}