using UnityEngine;
using Zenject;

public class Cell : MonoBehaviour
{
    private GameObject _building;

    [SerializeField]
    private bool _occupied;

    public bool Occupied
    {
        get { return _occupied; }
        set { _occupied = value; }
    }
    
    public GameObject Building
    {
        get { return _building; }
        set { _building = value; }
    }

    public class Factory : PlaceholderFactory<Cell>
    {

    }

    public void DeleteObj()
    {
        Destroy(gameObject);
    }
}
