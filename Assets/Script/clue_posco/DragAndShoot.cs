using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    public GameObject trashBinBottom;
    private Rigidbody rb;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInt = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInt.x, forceInt.y, forceInt.y)) * forceMultiplier;

        if (!isShoot) {
            DrawTarjectory.Instance.UpdataTarjectory(forceV, rb, transform.position);
        }
    }

    private void OnMouseUp()
    {
        DrawTarjectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos - mousePressDownPos);
    }

    [SerializeField]
    private float forceMultiplier = 10;
    void Shoot(Vector3 force)
    {

        rb.isKinematic = false;
        if (isShoot)
            return;

        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        isShoot = true;
        Spawner.Instance.NewSpawnRequest();
    }


}