using UnityEngine;

namespace Assets.Scripts
{
    public class FigurCreater : MonoBehaviour
    {
        [SerializeField] private Figure _particlePrefab;

        private Material[] _materials;
        private int _minRandomMaterial = 0;
        private int _maxRandomMaterial = 6;

        private void Start() 
        {
            _materials = Resources.LoadAll<Material>("CubeColor");
        }

        public Figure CreateFigur(Vector3 position, Vector3 scale)
        {
            int material = Random.Range(_minRandomMaterial, _maxRandomMaterial);

            Figure figure = Instantiate(_particlePrefab);

            figure.transform.position = position;
            figure.transform.localScale = scale;
            figure.GetComponent<MeshRenderer>().material = _materials[material];

            return figure;
        }
    }
}
