using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "InputFieldPreset", menuName = "UI/Input Field Preset")]
public class InputFieldPreset : ScriptableObject
{
    [Header("Heading Defaults")]
    public string defaultHeadingText = "Title";
    public TMP_FontAsset defaultHeadingFont;
    public float defaultHeadingFontSize = 28f;
    public Color defaultHeadingColor = Color.white;
    public Vector2 defaultHeadingSize = new Vector2(400, 60);

    [Header("Input Defaults")]
    public string defaultPlaceholderText = "Enter text...";
    public TMP_FontAsset defaultInputFont;
    public float defaultInputFontSize = 24f;
    public Color defaultInputColor = Color.white;
    public Color defaultPlaceholderColor = Color.gray;
    public Vector2 defaultInputSize = new Vector2(500, 70);
    public Sprite defaultSprite;
}