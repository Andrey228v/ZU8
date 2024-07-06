using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Figure))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _particle;

    private Figure _figure;
    private int _minRandomParticles = 2;
    private int _maxRandomParticles = 6;

    private void Start()
    {
        _figure = GetComponent<Figure>();
    }

    public void ExplodeObject(FigurCreater figurCreater)
    {
        if (_figure.Division())
        {
            CreateParticleExplosion(figurCreater);
        }

        Destroy(gameObject);
    }

    private void CreateParticleExplosion(FigurCreater figurCreater)
    {
        int countParticle = Utilities.GenerateRandomNumber(_minRandomParticles, _maxRandomParticles);
        int chansDivision = _figure.GetChanceDivision() / 2;

        for (int i = 0; i < countParticle; i++)
        {
            GameObject partExplode = figurCreater.CreateFigur(gameObject.transform.position, gameObject.transform.localScale / 2, _particle);

            partExplode.GetComponent<Figure>().SetChanceDivision(chansDivision);
        }
    }
}
