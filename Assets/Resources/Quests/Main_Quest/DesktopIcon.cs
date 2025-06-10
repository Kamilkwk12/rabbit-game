using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DesktopIcon", menuName = "Scriptable Objects/DesktopIcon")]
public class DesktopIcon : ScriptableObject
{
    public Sprite iconSprite;

    public string iconContent;
}
