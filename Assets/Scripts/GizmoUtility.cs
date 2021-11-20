using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public static class GizmoUtility
{
    [DidReloadScripts]
    private static void GizmoIconUtility()
    {
        EditorApplication.projectWindowItemOnGUI = ItemOnGUI;
    }

    private static void ItemOnGUI(string guid, Rect rect)
    {
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);

        Creature instance = AssetDatabase.LoadAssetAtPath(
            assetPath,
            typeof(Creature)) as Creature;

        if (instance != null && instance.Icon != null)
        {
            float initialWidth = rect.width;

            rect.width = Mathf.Min(rect.height, rect.width);
            rect.height = Mathf.Min(rect.height, rect.width);

            rect.position = new Vector2(
                rect.position.x + (initialWidth - rect.width) / 2f,
                rect.position.y);

            GUI.DrawTexture(
                rect,
                instance.Icon.texture);
        }
    }
}