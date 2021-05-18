using Code.BonusGame.View;
using UnityEngine;

namespace Code.BonusGame.Controllers
{
    public class CameraController:IExecute, IInitialization
    {
        private Transform _camera;
        private Transform _chip;
        private Vector3 _offset = new Vector3(0, 0, 4); 

        public CameraController(Transform camera)
        {
            _camera = camera;
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetMouseButton(0))
            {
                _camera.position -= new Vector3(Input.GetAxis("Mouse X")/6, Input.GetAxis("Mouse Y")/6, 0);
                _camera.position = new Vector3(Mathf.Clamp(_camera.position.x,_chip.position.x - 6, _chip.position.x + 6),
                    Mathf.Clamp(_camera.position.y, _chip.position.y - 3, _chip.position.y + 3), -10);
                _camera.position = new Vector3(Mathf.Clamp(_camera.position.x, 5.25f, 95.5f),
                    Mathf.Clamp(_camera.position.y, 2.5f, 96.5f), -10);
                
            }
            else
            {
                _camera.position = Vector3.Lerp(_camera.position, _chip.position - _offset, 2 * deltaTime);
                _camera.position = new Vector3(Mathf.Clamp(_camera.position.x, 5.25f, 95.5f),
                    Mathf.Clamp(_camera.position.y, 2.5f, 96.5f), -10);
            }
        }

        public void Initialization()
        {
            _chip = Object.FindObjectOfType<ChipView>().transform;
        }
    }
}