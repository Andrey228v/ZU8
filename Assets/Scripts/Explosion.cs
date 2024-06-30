using Assets.Scripts;
using UnityEngine;


public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _chansDivision = 100;

    private FigurCreater _figurCreater;

    private System.Random _random;
    
    private int _minRandomParticles = 2;
    private int _maxRandomParticles = 6;
    private int _minChans = 0;
    private int _maxChans = 100;

    private float _radiusOverlapSphere = 1f;
    private float _forceExplosion = 200f;
    private float _radiusExplosion = 1f;

    private Vector3 _explosionPos;

    private void Start()
    {
        _figurCreater = new FigurCreater(_container);
        _random = new System.Random();
    }

    public void ExplodeObject()
    {
        Destroy(gameObject);

        int _chans = _random.Next(_minChans, _maxChans);

        if(_chans < _chansDivision)
        {
            _chansDivision /= 2;

            CreateParticleExplosion();
        }
    }

    public void CreateParticleExplosion()
    {
        _explosionPos = transform.position;

        int countParticle = _random.Next(_minRandomParticles, _maxRandomParticles);

        for (int i = 0; i < countParticle; i++)
        {
            GameObject partExplode = _figurCreater.CreateFigur(gameObject.transform.position, gameObject.transform.localScale / 2);

            partExplode.GetComponent<Transform>().parent = _container.transform;
            partExplode.GetComponent<Explosion>().SetChanseDivision(_chansDivision);
        }

        Collider[] colliders = Physics.OverlapSphere(_explosionPos, _radiusOverlapSphere);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(_forceExplosion, _explosionPos, _radiusExplosion);
        }
    }

    public void SetContainer(GameObject parent)
    {
        _container = parent;
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
