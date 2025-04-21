using UnityEngine;

[CreateAssetMenu(fileName = "DesktopIcon", menuName = "Scriptable Objects/DesktopIcon")]
public class DesktopIcon : ScriptableObject
{
    public string IconName;
    public Sprite IconSprite;
    public string Content;
}
