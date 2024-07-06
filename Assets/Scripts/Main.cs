using Assets.Scripts;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private RaycastDrawer _raycastDrawer;
    [SerializeField] private FigurCreater _figurCreater;

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
        if (objectHit.TryGetComponent(out Explosion explosion))
        {
            explosion.ExplodeObject(_figurCreater);
        }
    }
}
