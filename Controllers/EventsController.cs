using System;
using Code.BonusGame.Model;

namespace Code.BonusGame.Controllers
{
    public class EventsController:IInitialization
    {
        public event Action<Vector3> ChooseCell;

        private CheckController _checkController;
        private ChipController _chipController;

        public EventsController(CheckController checkController, ChipController chipController)
        {
            _checkController = checkController;
            _chipController = chipController;
        }
        public void Initialization()
        {
            _chipController.ChipPosition += ChipPosition;
        }

        private void ChipPosition(Vector3 position)
        {
            ChooseCell(position);
        }
    }
}