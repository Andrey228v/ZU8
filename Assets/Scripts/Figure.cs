using UnityEngine;

namespace Assets.Scripts
{
    public class Figure : MonoBehaviour
    {
        [SerializeField] private int _chanceDivision = 100;

        private int _minChance = 0;
        private int _maxChance = 100;

        public bool IsDivision()
        {
            int _chance = Random.Range(_minChance, _maxChance);

            bool isDivision = (_chance < _chanceDivision);

            return isDivision;
        }

        public int GetChanceDivision()
        {
            return _chanceDivision;
        }

        public void SetChanceDivision(int chance)
        {
            if(_minChance <= chance)
            {
                _chanceDivision = chance;
            }
            else
            {
                _chanceDivision = _minChance;
            }
        }
    }
}
