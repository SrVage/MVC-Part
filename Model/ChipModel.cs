using Random = System.Random;

namespace Code.BonusGame.Model
{
    public class ChipModel
    {
        private Vector3 _position;
        private Vector3 _offset;
        
        public Vector3 Position => _position;

        public ChipModel()
        {
            Random rnd = new Random();
            _position = new Vector3(rnd.Next(0,99), rnd.Next(0,99), -4);
            _offset = new Vector3(0,0,0);
        }

        public void MoveChip(byte direction, int planeOfDice)
        {
            switch (direction)
            {
                case 1:
                {
                    _offset.Set(planeOfDice, 0, 0);
                    _position -= _offset;
                    if (_position.x < 0)
                        _position.Set(_position.x + 100, _position.y, _position.z);
                }
                    break;
                case 2:
                {
                    _offset.Set(planeOfDice, 0, 0);
                    _position += _offset;
                    if (_position.x > 99)
                        _position.Set(_position.x - 100, _position.y, _position.z);
                }
                    break;
                case 3:
                {
                    _offset.Set(0, planeOfDice, 0);
                    _position += _offset;
                    if (_position.y > 99)
                        _position.Set(_position.x, _position.y - 100, _position.z);
                }
                    break;
                case 4:
                {
                    _offset.Set(0, planeOfDice, 0);
                    _position -= _offset;
                    if (_position.y < 0)
                        _position.Set(_position.x, _position.y + 100, _position.z);
                }
                    break;
            }
        }
    }
}