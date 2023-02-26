using UnityEngine;

public class SystemSettingsService
{
    //public SystemSettingsService() => 
    //    Cursor.lockState = CursorLockMode.Confined;

    public void HideMouseCursor() => 
        Cursor.visible = false;

    public void ShowMouseCursor() => 
        Cursor.visible = true;
}
