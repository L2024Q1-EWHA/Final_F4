using UnityEngine;
using System.Collections;

public class FinalAnimal : MonoBehaviour
{
    private Animator animator;
    private float timer;
    private float changeInterval = 4.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        timer = changeInterval;
        animator.SetTrigger("jump");
        StartCoroutine(ActivateObjectAfterDelay(1.5f));
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ChangeStateRandomly();
            timer = changeInterval;
        }

        if (IsTouched())
        {
            animator.SetTrigger("jump");
        }
    }

    void ChangeStateRandomly()
    {
        animator.SetTrigger("stun");
        Vector3 offset = new Vector3(0, 3, -3);
    }

    IEnumerator ActivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    bool IsTouched()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    return true;
                }
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}