using UnityEngine;

public class NPC_Rotate : NPC
{
    public float rotationSpeed = 20f;  
    public float rotationAngle = 10f;  
    private float rotationDirection = 1f; 
    private float currentRotation = 0f;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        currentRotation += rotationSpeed * rotationDirection * Time.deltaTime;
        if (Mathf.Abs(currentRotation) >= rotationAngle)
        {
            rotationDirection *= -1;
        }
        transform.rotation = initialRotation * Quaternion.Euler(0, 0, currentRotation);
    }
}