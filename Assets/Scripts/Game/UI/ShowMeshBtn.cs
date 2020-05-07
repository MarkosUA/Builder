using UnityEngine;
using Zenject;

public class ShowMeshBtn : MonoBehaviour
{
    private IMeshManager _meshManager;

    [Inject]
    private void Construct(IMeshManager meshManager)
    {
        _meshManager = meshManager;
    }

    public void ShowMesh()
    {
        _meshManager.ShowMesh();
    }
}
