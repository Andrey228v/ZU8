using UnityEngine;

namespace Assets.Scripts
{
    public class FigurCreater
    {
        private GameObject _container;

        private Material[] _materials;

        private System.Random _random;
        private int _minRandomMaterial = 0;
        private int _maxRandomMaterial = 5;

        public FigurCreater(GameObject container) 
        {
            _materials = Resources.LoadAll<Material>("CubeColor");
            _container = container;
            _random = new System.Random();
        }

        public GameObject CreateFigur(Vector3 position, Vector3 scale)
        {
            int material = _random.Next(_minRandomMaterial, _maxRandomMaterial);

            GameObject figure = GameObject.CreatePrimitive(PrimitiveType.Cube);
            figure.AddComponent<Rigidbody>();
            figure.AddComponent<Explosion>().SetContainer(_container);
            figure.GetComponent<Transform>().position = position;
            figure.GetComponent<Transform>().localScale = scale;
            figure.GetComponent<MeshRenderer>().material = _materials[material];

            return figure;
        }
    }
}
