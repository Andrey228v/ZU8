using Assets.Scripts;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _particleExplosion;

    [SerializeField] private int _chansDivision = 100;

    private int _minRandomParticles = 2;
    private int _maxRandomParticles = 6;
    private int _minChans = 0;
    private int _maxChans = 100;

    private float _radiusOverlapSphere = 1f;

    private Vector3 _explosionPos;

    public void ExplodeObject(FigurCreater figurCreater)
    {
        Destroy(gameObject);

        int _chans = Utilities.GenerateRandomNumber(_minChans, _maxChans);

        if(_chans < _chansDivision)
        {
            _chansDivision /= 2;

            CreateParticleExplosion(figurCreater);
        }
    }

    private void CreateParticleExplosion(FigurCreater figurCreater)
    {
        _explosionPos = transform.position;

        int countParticle = Utilities.GenerateRandomNumber(_minRandomParticles, _maxRandomParticles);

        for (int i = 0; i < countParticle; i++)
        {
            GameObject partExplode = figurCreater.CreateFigur(gameObject.transform.position, gameObject.transform.localScale / 2, _particleExplosion);

            partExplode.GetComponent<Explosion>().SetChanseDivision(_chansDivision);
        }
    }

    public void SetChanseDivision(int chans)
    {
        _chansDivision = chans;
    }

    private void OnDrawGizmos()
    {
        _explosionPos = transform.position;
        Gizmos.DrawWireSphere(_explosionPos, _radiusOverlapSphere);
    }
}
