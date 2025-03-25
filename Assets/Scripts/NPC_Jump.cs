using UnityEngine;

public class NPC_Jump : NPC
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float minJumpInterval = 2f; 
    [SerializeField] private float maxJumpInterval = 10f;
    private bool isJumping = false;
    private float jumpTimer = 0f;
    private Vector3 startPos;

    private void Start()
    {
        jumpTimer = Random.Range(minJumpInterval, maxJumpInterval);
        startPos = transform.position;
    }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        // Handle jumping
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0f && !isJumping)
        {
            StartCoroutine(JumpCoroutine());
            // Reset the jump timer to a new random value between min and max
            jumpTimer = Random.Range(minJumpInterval, maxJumpInterval);
        }
    }

    private System.Collections.IEnumerator JumpCoroutine()
    {
        isJumping = true;

        // Play jump sound
        if (jumpSound != null)
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);

        // Total time for jump (up + down)
        float jumpDuration = 0.8f;
        float elapsedTime = 0f;

        while (elapsedTime < jumpDuration)
        {
            // Calculate jump progress (up then down)
            float jumpProgress = Mathf.Sin((elapsedTime / jumpDuration) * Mathf.PI);
            float newY = startPos.y + jumpHeight * jumpProgress;

            // Apply movement (keep X and Z the same)
            transform.position = new Vector3(
                transform.position.x,
                newY,
                transform.position.z
            );

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset to exact starting Y position
        transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        isJumping = false;
    }
}