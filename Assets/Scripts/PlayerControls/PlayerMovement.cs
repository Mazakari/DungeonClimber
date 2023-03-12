using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        MoveLauncher();
        //ClampInsideView();
    }

    private void MoveLauncher()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector2 (mousePos.x, transform.position.y);

    }

    private void ClampInsideView()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos = Camera.main.ViewportToWorldPoint(pos);

        transform.position = pos;
    }
}
