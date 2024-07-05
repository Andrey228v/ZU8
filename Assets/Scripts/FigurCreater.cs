using UnityEngine;

namespace Assets.Scripts
{
    public class FigurCreater : MonoBehaviour
    {
        private Material[] _materials;
        private int _minRandomMaterial = 0;
        private int _maxRandomMaterial = 6;
        private GameObject _figure;

        private void Start() 
        {
            _materials = Resources.LoadAll<Material>("CubeColor");
            _figure = new GameObject();
        }

        public GameObject CreateFigur(Vector3 position, Vector3 scale, GameObject particleExlosion)
        {
            int material = Utilities.GenerateRandomNumber(_minRandomMaterial, _maxRandomMaterial);

            _figure = Instantiate(particleExlosion);

            _figure.transform.position = position;
            _figure.transform.localScale = scale;
            _figure.GetComponent<MeshRenderer>().material = _materials[material];

            return _figure;
        }
    }
}
