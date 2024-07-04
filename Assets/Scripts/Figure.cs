using UnityEngine;

namespace Assets.Scripts
{
    public class Figure : MonoBehaviour
    {
        [SerializeField] private int _chansDivision = 100;

        private int _minChans = 0;
        private int _maxChans = 100;

        public bool Division()
        {
            bool isDivision = false;

            int _chans = Utilities.GenerateRandomNumber(_minChans, _maxChans);

            if (_chans < _chansDivision)
            {
                isDivision = true;
            }

            return isDivision;
        }

        public int GetChansDivision()
        {
            return _chansDivision;
        }

        public void SetChansDivision(int chans)
        {
            _chansDivision = chans;
        }
    }
}
