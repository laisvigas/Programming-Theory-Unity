using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public string npcName; // ENCAPSULATION
    
    [SerializeField]  
    private AudioClip sound; // ENCAPSULATION
    protected int clickCount = 0; // ENCAPSULATION

    public abstract void Move(); // ABSTRACTION

    public virtual void Interact() // ABSTRACTION
    {
        clickCount++;
        Debug.Log($"{npcName} clicked {clickCount} times!");
        PlaySound();
    }

    void OnMouseDown()
    {
        Interact();
    }

    private void PlaySound() // ENCAPSULATION
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