using Assets.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private RaycastDrawer _raycastDrawer;
    [SerializeField] private FigurCreater _figurCreater;
    [SerializeField] private Explosion _explosion;

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
        if (objectHit.GetComponent<Figure>())
        {
            _explosion.ExplodeObject(_figurCreater, objectHit);
        }
    }
}
