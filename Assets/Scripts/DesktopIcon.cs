using UnityEngine;

[CreateAssetMenu(fileName = "DesktopIcon", menuName = "Scriptable Objects/DesktopIcon")]
public class DesktopIcon : ScriptableObject
{
    public string IconName;
    public Sprite IconSprite;
    [TextArea(3, 10)]
    public string Content;
    [TextArea(3, 10)]
    public string ErrorMessage;
}
