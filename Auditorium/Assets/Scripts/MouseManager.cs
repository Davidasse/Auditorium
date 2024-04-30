using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public Texture2D centerIcon;
    public Texture2D outerIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerMove( InputAction.CallbackContext context )
    {
        Vector2 pointerPosition = context.ReadValue<Vector2>();

        _ray = Camera.main.ScreenPointToRay( pointerPosition );
        RaycastHit2D hit = Physics2D.GetRayIntersection(_ray);

        //si j'ai touché quelques chose
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("CenterZone"))
                {
                // j'ai touché la fleche
                Debug.Log("dedans");
                Cursor.SetCursor(centerIcon, new Vector2(256, 256), CursorMode.Auto);
                }
                else if (hit.collider.CompareTag("OuterZone"))
                {
                    // j'ai touché le cercle
                    Debug.Log("dehors");
                Cursor.SetCursor(outerIcon, new Vector2(256, 256), CursorMode.Auto);
            }
            
        }
        else
            {
                //notre pointer survole rien, on remet le curseur a sa forme par defaut
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
             }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay( _ray.origin, _ray.direction * 1000f);

    }
    private Ray _ray;  
   
}
