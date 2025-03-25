using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public string npcName;
    
    [SerializeField]  
    private AudioClip sound; 
    protected int clickCount = 0;

    public abstract void Move();

    public virtual void Interact()
    {
        clickCount++;
        Debug.Log($"{npcName} clicked {clickCount} times!");
        PlaySound();
    }

    void OnMouseDown()
    {
        Interact();
    }

    private void PlaySound()
    {
        if (sound != null)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
        else
        {
            Debug.LogWarning($"{npcName} has no sound assigned!");
        }
    }
}