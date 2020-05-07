using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Data/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    public int WidthBorder;
    public float CameraSpeed;
    public float ZoomSensitivity;
}
