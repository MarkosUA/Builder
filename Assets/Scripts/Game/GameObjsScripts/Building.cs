using UnityEngine;

public class Building : MonoBehaviour
{
    public int SessionID { get; set; }

    protected int numberOfOccupiedCellsX;
    protected int numberOfOccupiedCellsZ;
    protected int sessionId;

    public int NumberOfOccupiedCellsX
    {
        get { return numberOfOccupiedCellsX; }
    }

    public int NumberOfOccupiedCellsZ
    {
        get { return numberOfOccupiedCellsZ; }
    }

}
