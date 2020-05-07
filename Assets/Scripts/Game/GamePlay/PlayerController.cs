using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IMenuController _menuController;
    private IWorldPlaceholder _worldPlaceholder;

    private GameObject _selectedBuilding;
    private GameObject _selectedBuildingView;
    private Camera _camera;
    private List<GameObject> _selectableBuildings = new List<GameObject>();

    private bool _selectionComplited;

    [Inject]
    private void Construct(Camera camera, IMenuController menuController, IWorldPlaceholder worldPlaceholder)
    {
        _camera = camera;
        _menuController = menuController;
        _worldPlaceholder = worldPlaceholder;
    }

    private void Update()
    {
        if (_selectionComplited && _selectedBuilding != null)
        {
            OnMouseDrag();
            CheckClickForBuilding();
        }
        else
        {
            CheckClickForInformation();
        }
    }

    public void StartPlayerBuilding(Building buildType)
    {
        _menuController.CloseMenu();

        var newPosition = new Vector3(0, buildType.gameObject.GetComponent<MeshRenderer>().bounds.size.y / 2, 0);

        if (!CheckIsBuildingInList(buildType))
        {
            _selectedBuildingView = Instantiate(buildType, newPosition, Quaternion.identity).gameObject;
        }

        _selectedBuilding = buildType.gameObject;
        _selectionComplited = true;
    }

    private void OnMouseDrag()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            var mousePosition = hit.point;
            _selectedBuildingView.transform.position = new Vector3(mousePosition.x - 1, _selectedBuildingView.transform.position.y,
               mousePosition.z - 1);
        }
    }

    private void CheckClickForBuilding()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.GetComponent<Cell>() != null)
                {
                    hit.collider.GetComponent<Cell>().Building = _selectedBuilding;

                    var check = _worldPlaceholder.SearchCell(hit.collider.GetComponent<Cell>());

                    if (check)
                    {
                        _selectedBuilding = null;
                        _selectionComplited = false;
                        _selectableBuildings.Add(_selectedBuildingView);
                        _selectedBuildingView.SetActive(false);
                    }
                }
            }
        }
    }

    private bool CheckIsBuildingInList(Building buildType)
    {
        for (int i = 0; i < _selectableBuildings.Count; i++)
        {
            if (_selectableBuildings[i].gameObject.name == buildType.gameObject.name + "(Clone)")
            {
                _selectedBuildingView = _selectableBuildings[i].gameObject;
                _selectedBuildingView.SetActive(true);
                return true;
            }
        }
        return false;
    }

    private void CheckClickForInformation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.GetComponent<Building>() != null)
                {
                    var building = hit.collider.GetComponent<Building>();

                    Debug.Log(building.name + " - " + building.NumberOfOccupiedCellsX + "x" + building.NumberOfOccupiedCellsZ +
                         " ID - " + building.SessionID);
                }
            }
        }
    }
}