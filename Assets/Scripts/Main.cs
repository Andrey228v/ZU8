using Assets.Scripts;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private RaycastDrawer _raycastDrawer;
    [SerializeField] private FigurCreater _figurCreater;

    private Explosion _explosion;

    private void Start()
    {
        _raycastDrawer.ObjectHited += DestoyObject; 
    }

    private void OnDestroy()
    {
        _raycastDrawer.ObjectHited -= DestoyObject;
    }

    public void DestoyObject(GameObject objectHit)
    {
        _explosion = objectHit.GetComponent<Explosion>();

        if (_explosion)
        {
            _explosion.ExplodeObject(_figurCreater);
        }
    }
}
