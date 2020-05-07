
public class MeshManager : IMeshManager
{
    private IWorldPlaceholder _worldPlaceholder;

    private bool _visible;

    public MeshManager(IWorldPlaceholder worldPlaceholder)
    {
        _worldPlaceholder = worldPlaceholder;
        _visible = true;
    }

    public void ShowMesh()
    {
        if (_visible)
            _visible = false;
        else
            _visible = true;

        for (int i = 0; i < _worldPlaceholder.PlayableCells.GetLength(0); i++)
        {
            for (int j = 0; j < _worldPlaceholder.PlayableCells.GetLength(1); j++)
            {
                _worldPlaceholder.PlayableCells[i, j].gameObject.GetComponent<UnityEngine.SpriteRenderer>().enabled = _visible;
            }
        }
    }
}
