using System.Collections.Generic;
using Code.BonusGame.Model;
using Code.BonusGame.TimeRemaining;
using UnityEngine;
using Code.Character_Selection_Scene.Model;

namespace Code.BonusGame.Controllers
{
    public sealed class GameInitialization
    {
        private Camera camera;
        private Controllers _controllers;
        private List<Item> _itemObj = new List<Item>();

        public GameInitialization(Controllers controllers, List<Sprite> cell, GameObject winAnimation)
        {
            camera = Camera.main;
            _controllers = controllers;
            _itemObj = ListOfItem.GetItem();
            var cellFactory = new CellFactory(cell);
            var checkController = new CheckController(_itemObj);
            var chipController = new ChipController(camera, checkController);
            var cameraController = new CameraController(camera.gameObject.transform);
            var eventsController = new EventsController(checkController, chipController);
            var cellController = new CellController(cellFactory.Cells(), eventsController, winAnimation, _itemObj);
            var timeRemainingController = new TimeRemainingController();
            _controllers.Add(chipController);
            _controllers.Add(cameraController);
            _controllers.Add(checkController);
            _controllers.Add(cellController);
            _controllers.Add(eventsController);
            _controllers.Add(timeRemainingController);
        }
    }
}