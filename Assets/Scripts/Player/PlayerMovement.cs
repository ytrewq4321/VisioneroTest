using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour 
{
    private NavMeshAgent agent;
    private bool isUnitSelected;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (isUnitSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Move();
                isUnitSelected = false;
            }
        }
    }

    private void Move()
    {
        Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
           agent.SetDestination(hit.point);
    }

    private void OnMouseUp()
    {
        isUnitSelected = true;
    }
}
