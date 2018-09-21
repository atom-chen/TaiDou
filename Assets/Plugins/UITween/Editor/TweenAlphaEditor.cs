//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TweenAlpha))]
public class TweenAlphaEditor : UITweenerEditor
{
	public override void OnInspectorGUI ()
	{
		GUILayout.Space(6f);
		NGUIEditorTools.SetLabelWidth(120f);

		TweenAlpha tw = target as TweenAlpha;
		GUI.changed = false;

		float from = EditorGUILayout.Slider("From", tw.from, 0f, 1f);
		float to = EditorGUILayout.Slider("To", tw.to, 0f, 1f);
        bool ic = EditorGUILayout.Toggle("Include Children", tw.includeChildren);
        bool ac = EditorGUILayout.Toggle("Auto Children", tw.autoChildren);

        if (GUI.changed)
		{
			NGUIEditorTools.RegisterUndo("Tween Change", tw);
			tw.from = from;
			tw.to = to;
            tw.includeChildren = ic;
            tw.autoChildren = ac;
            NGUITools.SetDirty(tw);
		}

		DrawCommonProperties();
	}
}
