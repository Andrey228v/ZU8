using UnityEngine;

namespace Assets.Scripts
{
    public class FigurCreater : MonoBehaviour
    {
        private Material[] _materials;
        private int _minRandomMaterial = 0;
        private int _maxRandomMaterial = 6;

        private void Start() 
        {
            _materials = Resources.LoadAll<Material>("CubeColor");
        }

        public GameObject CreateFigur(Vector3 position, Vector3 scale, GameObject particleExlosion)
        {
            int material = Utilities.GenerateRandomNumber(_minRandomMaterial, _maxRandomMaterial);

            GameObject figure = Instantiate(particleExlosion);

            figure.transform.position = position;
            figure.transform.localScale = scale;
            figure.GetComponent<MeshRenderer>().material = _materials[material];

            return figure;
        }
    }
}
