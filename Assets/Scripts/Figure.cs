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

            return _chance < _chanceDivision;
        }

        public int GetChanceDivision()
        {
            return _chanceDivision;
        }

        public void SetChanceDivision(int chance)
        {
            _chanceDivision = Mathf.Max(_minChance, chance);
        }
    }
}
