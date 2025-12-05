using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InputFieldCustamize_RS))]
public class InputFieldCustamize_RS_Editor : Editor
{
    private SerializedObject so;
    private InputFieldCustamize_RS s;

    // foldouts
    bool foldHeading = true;
    bool foldInput = true;

    // Colors
    Color headerColor = new Color(0.18f, 0.24f, 0.35f);
    Color sectionColor = new Color(0.2f, 0.2f, 0.2f);
    Color overrideColor = new Color(0.3f, 0.3f, 0.3f);
    Color outlineColor = new Color(0.3f, 0.45f, 0.8f);

    private void OnEnable()
    {
        so = serializedObject;
        s = (InputFieldCustamize_RS)target;
    }

    public override void OnInspectorGUI()
    {
        so.Update();

        DrawHeader();

        GUILayout.Space(10);

        DrawPresetSection();

        GUILayout.Space(5);

        DrawHeadingSection();

        GUILayout.Space(5);

        DrawInputFieldSection();

        GUILayout.Space(15);

        DrawActionButtons();

        so.ApplyModifiedProperties();
    }

    // ============== HEADER ================

    void DrawHeader()
    {
        GUIStyle header = new GUIStyle(EditorStyles.boldLabel);
        header.fontSize = 18;
        header.normal.textColor = Color.white;
        header.alignment = TextAnchor.MiddleCenter;

        GUI.backgroundColor = headerColor;
        GUILayout.BeginVertical("box");
        GUI.backgroundColor = Color.white;
        GUILayout.Label("📝 INPUT FIELD CUSTOMIZER", header);
        GUILayout.EndVertical();
    }

    // ============== PRESET SECTION ================

    void DrawPresetSection()
    {
        DrawColoredBox(sectionColor, () =>
        {
            GUILayout.Label("📦 Preset Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(so.FindProperty("preset"));
        });
    }

    // ============== HEADING SECTION ================

    void DrawHeadingSection()
    {
        DrawColoredBox(sectionColor, () =>
        {
            foldHeading = EditorGUILayout.Foldout(foldHeading, "Heading Options", true, EditorStyles.foldoutHeader);

            if (foldHeading)
            {
                GUILayout.Space(5);

                DrawProp("headingRect", "Heading Rect");
                GUILayout.Space(2);
                DrawProp("heading", "Heading Text");
                GUILayout.Space(5);
                DrawToggleGroup("override_HeadingVisibility", "Enable Heading", null);

                DrawToggleGroup("override_HeadingText", "Override Heading Text", () =>
                {
                    DrawProp("customHeadingText");
                });

                DrawToggleGroup("override_HeadingFont", "Override Font Asset", () =>
                {
                    DrawProp("customHeadingFont");
                });

                DrawToggleGroup("override_HeadingFontSize", "Override Font Size", () =>
                {
                    DrawProp("customHeadingFontSize");
                });

                DrawToggleGroup("override_HeadingColor", "Override Heading Color", () =>
                {
                    DrawProp("customHeadingColor");
                });

                DrawToggleGroup("override_HeadingSize", "Override Heading Size", () =>
                {
                    DrawProp("customHeadingSize");
                });
            }
        });
    }

    // ============== INPUT FIELD SECTION ================

    void DrawInputFieldSection()
    {
        DrawColoredBox(sectionColor, () =>
        {
            foldInput = EditorGUILayout.Foldout(foldInput, "Input Field Options", true, EditorStyles.foldoutHeader);

            if (foldInput)
            {
                GUILayout.Space(5);

                DrawProp("inputRect");
                GUILayout.Space(2);
                DrawProp("inputText");
                GUILayout.Space(2);
                DrawProp("placeholder");
                GUILayout.Space(2);
                DrawProp("inputBackground");

                GUILayout.Space(5);
                DrawToggleGroup("override_PlaceholderText", "Override Placeholder Text", () =>
                {
                    DrawProp("customPlaceholderText");
                });

                DrawToggleGroup("override_InputFont", "Override Font Asset", () =>
                {
                    DrawProp("customInputFont");
                });

                DrawToggleGroup("override_InputFontSize", "Override Font Size", () =>
                {
                    DrawProp("customInputFontSize");
                });

                DrawToggleGroup("override_InputColor", "Override Text Colors", () =>
                {
                    DrawProp("customInputColor");
                    DrawProp("customPlaceholderColor");
                });

                DrawToggleGroup("override_InputSize", "Override Input Size", () =>
                {
                    DrawProp("customInputSize");
                });

                DrawToggleGroup("override_BackgroundSprite", "Override Sprite", () =>
                {
                    DrawProp("customSprite");
                });
            }
        });
    }

    // ============== BUTTONS ================

    void DrawActionButtons()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("APPLY", GUILayout.Height(30)))
        {
            s.ApplyChanges();
            EditorUtility.SetDirty(s);
        }

        if (GUILayout.Button("RESET DEFAULTS", GUILayout.Height(30)))
        {
            s.ResetToDefault();
            EditorUtility.SetDirty(s);
        }

        GUILayout.EndHorizontal();
    }

    // ============== UTILS ================

    void DrawProp(string prop, string label = null)
    {
        if (label == null)
            EditorGUILayout.PropertyField(so.FindProperty(prop));
        else
            EditorGUILayout.PropertyField(so.FindProperty(prop), new GUIContent(label));
    }

    void DrawColoredBox(Color color, System.Action content)
    {
        GUI.backgroundColor = color;
        GUILayout.BeginVertical("box");
        GUI.backgroundColor = Color.white;
        GUILayout.Space(4);
        content.Invoke();
        GUILayout.Space(4);
        GUILayout.EndVertical();
    }

    void DrawToggleGroup(string boolProp, string label, System.Action drawer)
    {
        SerializedProperty p = so.FindProperty(boolProp);
        p.boolValue = EditorGUILayout.ToggleLeft($"    {label}", p.boolValue);

        if (p.boolValue && drawer != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(25);
            GUILayout.BeginVertical("box");
            GUI.backgroundColor = overrideColor;
            GUI.backgroundColor = Color.white;

            drawer.Invoke();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
    }
}