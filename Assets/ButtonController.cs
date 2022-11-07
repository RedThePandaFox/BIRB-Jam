using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    
    private SpriteRenderer renderer;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public float xSize, ySize;
    public RhythmManager manager;

    public KeyCode key;
    [SerializeField] LayerMask mask;
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = defaultImage;

    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            renderer.sprite = pressedImage;
            CheckForNote();
        }
        if (Input.GetKeyUp(key))
        {
            renderer.sprite = defaultImage;
        }
        
    }

    public void CheckForNote()
    {
        Debug.Log("Checked for Note");
        Collider2D results=
        Physics2D.OverlapBox(transform.position, new Vector2(xSize, ySize), 0f, mask);
        if (results != null)
        {
            manager.cardHit();
            results.gameObject.SetActive(false);

        }
        else
        {
            manager.cardMissed();
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(xSize, ySize,1));
    }

}
