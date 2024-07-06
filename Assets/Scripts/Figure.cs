using UnityEngine;

namespace Assets.Scripts
{
    public class Figure : MonoBehaviour
    {
        [SerializeField] private int _chanceDivision = 100;

        private int _minChance = 0;
        private int _maxChance = 100;

        public bool Division()
        {
            int _chance = Utilities.GenerateRandomNumber(_minChance, _maxChance);

            bool isDivision = (_chance < _chanceDivision)? true : false;

            return isDivision;
        }

        public int GetChanceDivision()
        {
            return _chanceDivision;
        }

        public void SetChanceDivision(int chance)
        {
            _chanceDivision = chance;
        }
    }
}
