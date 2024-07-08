using Assets.Scripts;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    private int _minRandomParticles = 2;
    private int _maxRandomParticles = 7;
    private int _multiplicityDivision = 2;

    public void ExplodeObject(FigurCreater figurCreater, Figure explosionFigure)
    {
        if (explosionFigure.IsDivision())
        {
            CreateParticleExplosion(figurCreater, explosionFigure);
        }
        else
        {
            CreateExplosion(explosionFigure);
        }

        Destroy(explosionFigure.gameObject);
    }

    private void CreateExplosion(Figure explosionFigure)
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(explosionFigure.transform.position, _radius);

        float scaleX = explosionFigure.transform.localScale.x;

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_force, explosionFigure.transform.position / scaleX, _radius / scaleX);
            }
        }
    }

    private void CreateParticleExplosion(FigurCreater figurCreater, Figure explosionFigure)
    {
        int countParticle = Random.Range(_minRandomParticles, _maxRandomParticles);
        int chansDivision = explosionFigure.GetChanceDivision() / _multiplicityDivision;

        for (int i = 0; i < countParticle; i++)
        {
            Figure partExplode = figurCreater.CreateFigur(explosionFigure.transform.position, explosionFigure.transform.localScale / _multiplicityDivision);

            partExplode.SetChanceDivision(chansDivision);
        }
    }
}
