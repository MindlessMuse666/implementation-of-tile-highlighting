using UnityEngine;

public class TileSelectionController : MonoBehaviour
{
    private Camera _camera;
    private HighlightableObject _lastHighlightedObject;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        SelectingObject();
    }

    private void SelectingObject()
    {
        var currentHighlightedObject = GetSelectedHighlightableObject();

        var isNewObject = currentHighlightedObject != _lastHighlightedObject;

        if (isNewObject)
        {
            if (_lastHighlightedObject != null)
            {
                _lastHighlightedObject.ResetColor();
            }

            if (currentHighlightedObject != null)
            {
                currentHighlightedObject.Highlight();
            }

            _lastHighlightedObject = currentHighlightedObject;
        }
    }

    private HighlightableObject GetSelectedHighlightableObject()
    {
        var mousePosition = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(mousePosition);

        return Physics.Raycast(ray, out var hitInfo) ? hitInfo.collider.GetComponent<HighlightableObject>() : null;
    }
}