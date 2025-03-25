using UnityEngine;

public class NPC_Walk : NPC
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 5f; 
    private Vector3 targetPosition;
    
    void Start()
    {
        SetRandomTargetPosition();
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction != Vector3.zero) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    private void SetRandomTargetPosition()
    {
        targetPosition = new Vector3(Random.Range(0f, 7f), transform.position.y, Random.Range(-7f, 0f));
    }
}