using UnityEngine;

namespace Assets.Scripts
{
    public class FigurCreater : MonoBehaviour
    {
        private Material[] _materials;

        private int _minRandomMaterial = 0;
        private int _maxRandomMaterial = 5;

        private void Start() 
        {
            _materials = Resources.LoadAll<Material>("CubeColor");
        }

        public GameObject CreateFigur(Vector3 position, Vector3 scale, GameObject particleExlosion)
        {
            int material = Utilities.GenerateRandomNumber(_minRandomMaterial, _maxRandomMaterial);
            GameObject figure = Instantiate(particleExlosion);

            figure.GetComponent<Transform>().position = position;
            figure.GetComponent<Transform>().localScale = scale;
            figure.GetComponent<MeshRenderer>().material = _materials[material];

            return figure;
        }
    }
}
