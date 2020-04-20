/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

/*
  Project   - Boing Kit
  Publisher - Long Bunny Labs
              http://LongBunnyLabs.com
  Author    - Ming-Lun "Allen" Chou
              http://AllenChou.net
*/
/******************************************************************************/

using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace BoingKit
{
  public class BoingEditorBase : Editor
  {
    internal static void Header(string label)
    {
      EditorGUILayout.LabelField
      (
        new GUIContent() { text = label }, 
        new GUIStyle() { fontStyle = FontStyle.Bold }
      );
    }

    internal static void Space()
    {
      EditorGUILayout.Space();
    }

    internal static void Property(SerializedProperty prop, string label, string tooltip = "")
    {
      EditorGUILayout.PropertyField
      (
        prop, 
        new GUIContent() { text = "  " + label, tooltip = tooltip }, 
        true
      );
    }

    private Dictionary<SerializedProperty, ReorderableList> m_listMap = new Dictionary<SerializedProperty, ReorderableList>();

    internal void Array(SerializedProperty prop, string label)
    {
      ReorderableList list = null;
      if (!m_listMap.TryGetValue(prop, out list))
      {
        list = new ReorderableList(prop.serializedObject, prop, true, true, true, true);

        if (label.Length > 0)
        {
          list.drawHeaderCallback = (Rect rect) =>
          {
            EditorGUI.LabelField(rect, label);
          };
        }
        else
        {
          list.headerHeight = 3.0f;
        }

        list.elementHeightCallback = (int index) =>
        {
          var elementProp = prop.GetArrayElementAtIndex(index);
          return EditorGUI.GetPropertyHeight(elementProp, new GUIContent() { text = "" });
        };

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
          var elementProp = prop.GetArrayElementAtIndex(index);
          string elementLabel = " [" + index + "]";
          EditorGUI.LabelField(rect, elementLabel);
          rect.x += 30.0f;
          rect.width -= 30.0f;

          EditorGUI.PropertyField(rect, elementProp, new GUIContent() { text = "" });
        };

        m_listMap.Add(prop, list);
      }

      list.DoLayoutList();
    }
  }
}
