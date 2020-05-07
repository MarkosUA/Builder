using UnityEngine;

[CreateAssetMenu(fileName = "DataBuildingsSettings", menuName = "Data/DataBuildingsSettings")]
public class DataBuildingsSettings : ScriptableObject
{
    public int StoneNumberOfOccupiedCellsX;
    public int StoneNumberOfOccupiedCellsZ;
    public int TreeNumberOfOccupiedCellsX;
    public int TreeNumberOfOccupiedCellsZ;
}