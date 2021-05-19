using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{

    [SerializeField]
    float rotationSpeed = 10.0f;

    [SerializeField]
    float moveSpeed = 5.0f;

    Vector2 direction;

    Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        SetTarget(FindObjectOfType<PlayerMovement>().transform);
    }

    // Update is called once per frame
    void Update()
    {
        direction = targetTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform trans)
    {
        targetTransform = trans;
    }
}
