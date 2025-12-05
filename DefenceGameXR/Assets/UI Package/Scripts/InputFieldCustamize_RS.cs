using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldCustamize_RS : MonoBehaviour
{
    public InputFieldPreset preset;

    [Header("UI References")]
    public RectTransform headingRect;
    public TMP_Text heading;
    public RectTransform inputRect;
    public TMP_Text inputText;
    public TMP_Text placeholder;
    public Image inputBackground;

    // ============================
    // OVERRIDE SWITCHES
    // ============================

    [Header("Heading Overrides")]
    public bool override_HeadingVisibility = true;
    public bool override_HeadingText;
    public bool override_HeadingFont;
    public bool override_HeadingFontSize;
    public bool override_HeadingColor;
    public bool override_HeadingSize;

    [Header("InputField Overrides")]
    public bool override_PlaceholderText;
    public bool override_InputFont;
    public bool override_InputFontSize;
    public bool override_InputColor;
    public bool override_InputSize;
    public bool override_BackgroundSprite;

    // ============================
    // OVERRIDE VALUES
    // ============================

    [Header("Heading Values")]
    public string customHeadingText;
    public TMP_FontAsset customHeadingFont;
    public float customHeadingFontSize;
    public Color customHeadingColor;
    public Vector2 customHeadingSize;

    [Header("Input Values")]
    public string customPlaceholderText;
    public TMP_FontAsset customInputFont;
    public float customInputFontSize;
    public Color customInputColor;
    public Color customPlaceholderColor;
    public Vector2 customInputSize;
    public Sprite customSprite;

    public void ApplyChanges()
    {
        if (!preset) return;

        // ---------------------------------------
        // HEADING
        // ---------------------------------------

        headingRect.gameObject.SetActive(override_HeadingVisibility);

        if (override_HeadingText)
            heading.text = customHeadingText;
        else
            heading.text = preset.defaultHeadingText;

        if (override_HeadingFont)
            heading.font = customHeadingFont;
        else
            heading.font = preset.defaultHeadingFont;

        if (override_HeadingFontSize)
            heading.fontSize = customHeadingFontSize;
        else
            heading.fontSize = preset.defaultHeadingFontSize;

        if (override_HeadingColor)
            heading.color = customHeadingColor;
        else
            heading.color = preset.defaultHeadingColor;

        if (override_HeadingSize)
            headingRect.sizeDelta = customHeadingSize;
        else
            headingRect.sizeDelta = preset.defaultHeadingSize;

        // ---------------------------------------
        // INPUT FIELD
        // ---------------------------------------

        if (override_PlaceholderText)
            placeholder.text = customPlaceholderText;
        else
            placeholder.text = preset.defaultPlaceholderText;

        if (override_InputFont)
        {
            placeholder.font = customInputFont;
            inputText.font = customInputFont;
        }
        else
        {
            placeholder.font = preset.defaultInputFont;
            inputText.font = preset.defaultInputFont;
        }

        if (override_InputFontSize)
        {
            placeholder.fontSize = customInputFontSize;
            inputText.fontSize = customInputFontSize;
        }
        else
        {
            placeholder.fontSize = preset.defaultInputFontSize;
            inputText.fontSize = preset.defaultInputFontSize;
        }

        if (override_InputColor)
        {
            placeholder.color = customPlaceholderColor;
            inputText.color = customInputColor;
        }
        else
        {
            placeholder.color = preset.defaultPlaceholderColor;
            inputText.color = preset.defaultInputColor;
        }

        if (override_InputSize)
            inputRect.sizeDelta = customInputSize;
        else
            inputRect.sizeDelta = preset.defaultInputSize;

        if (override_BackgroundSprite)
            inputBackground.sprite = customSprite;
        else
            inputBackground.sprite = preset.defaultSprite;
    }

    public void ResetToDefault()
    {
        override_HeadingText = false;
        override_HeadingFont = false;
        override_HeadingFontSize = false;
        override_HeadingColor = false;
        override_HeadingSize = false;

        override_PlaceholderText = false;
        override_InputFont = false;
        override_InputFontSize = false;
        override_InputColor = false;
        override_InputSize = false;
        override_BackgroundSprite = false;

        ApplyChanges();
    }
}
