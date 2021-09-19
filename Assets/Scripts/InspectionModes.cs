using UnityEngine;

public class InspectionModes : MonoBehaviour
{
    [SerializeField] string nameObjectHit;
    [SerializeField] float speedCamera;

    Camera mainCamera;
    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }
    private void Update()
    {
        RayCast();
        if(nameObjectHit == "Table")
        {
            if (mainCamera.orthographicSize >= 8)
            {
                mainCamera.orthographicSize -= Time.deltaTime * speedCamera;
                GameController.instance.viewTable = true;
            }
        }
        if (nameObjectHit == "Environment")
        {
            if (mainCamera.orthographicSize <= 15)
            {
                mainCamera.orthographicSize += Time.deltaTime * speedCamera;
                GameController.instance.viewTable = false;
            }
        }

    }
    void RayCast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                nameObjectHit = hit.collider.name;
                GameController.instance.nameObject = nameObjectHit;
            }
        }
    }
}
