using UnityEngine;
using Zenject;

public class GameZone : MonoBehaviour
{
    public class Factory : PlaceholderFactory<GameZone>
    {

    }
}
