using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Figure))]
public class Explosion : MonoBehaviour
{
    private Figure _figure;
    private int _minRandomParticles = 2;
    private int _maxRandomParticles = 7;
    private int _multiplicityDivision = 2;

    public void ExplodeObject(FigurCreater figurCreater, GameObject explosionObject)
    {
        _figure = explosionObject.GetComponent<Figure>();

        if (_figure.IsDivision())
        {
            CreateParticleExplosion(figurCreater, explosionObject);
        }

        Destroy(explosionObject);
    }

    private void CreateParticleExplosion(FigurCreater figurCreater, GameObject explosionObject)
    {
        int countParticle = Random.Range(_minRandomParticles, _maxRandomParticles);
        int chansDivision = _figure.GetChanceDivision() / _multiplicityDivision;

        for (int i = 0; i < countParticle; i++)
        {
            Figure partExplode = figurCreater.CreateFigur(explosionObject.transform.position, explosionObject.transform.localScale / _multiplicityDivision);

            partExplode.SetChanceDivision(chansDivision);
        }
    }
}
