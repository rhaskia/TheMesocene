using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(Creature))]
public class CreatureEditor : Editor
{

    bool[] Sbools = new bool[15];
    Creature script;

    public override void OnInspectorGUI()
    {

        //Get script
        script = (Creature)target;

        serializedObject.Update();

        //Small icon
        if (script.Icon != null)
        {
            Texture2D texture = textureFromSprite(script.Icon);
            texture.filterMode = FilterMode.Point;
            EditorGUI.DrawPreviewTexture(new Rect((Screen.width / 2) - Mathf.RoundToInt(texture.width * 1.5f), 10, texture.width * 3, texture.height * 3), texture);
            int spaces = Mathf.RoundToInt(texture.height * 3f / 5f);
            for (int i = 0; i < spaces + 1; i++)
            {
                EditorGUILayout.Space();
            }

        }

        script.Icon = (Sprite)EditorGUILayout.ObjectField(script.Icon, typeof(Sprite), true);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //Animations
        EditorGUILayout.LabelField("Animations", EditorStyles.boldLabel);

        drawArray("IdleAnim", 13);

        drawArray("WalkAnim", 0);
        drawArray("RunAnim", 1);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        script.canJump = EditorGUILayout.Toggle("Can Jump", script.canJump);
        script.canGlide = EditorGUILayout.Toggle("Can Glide", script.canGlide);
        script.canFly = EditorGUILayout.Toggle("Can Fly", script.canFly);

        if (script.canJump) { drawArray("JumpAnim", 2); }
        if (script.canGlide) { drawArray("GlideAnim", 3); }
        if (script.canFly) { drawArray("FlyAnim", 4); }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        drawArray("RestAnim", 5);
        drawArray("SleepAnim", 6);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        drawArray("EatAnim", 7);
        drawArray("DrinkAnim", 8);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        drawArray("LMBAnim", 9);
        drawArray("RMBAnim", 10);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        drawArray("LimpAnim", 11);
        drawArray("DeathAnim", 12);

        serializedObject.ApplyModifiedProperties();


    }

    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }


    public void drawArray(string arrayName, int num)
    {
        Sbools[num] = EditorGUILayout.Foldout(Sbools[num], arrayName + "ations");
        if (Sbools[num])
        {
            EditorGUI.indentLevel = 1;

            EditorGUILayout.PropertyField(serializedObject.FindProperty(arrayName + "Side"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(arrayName + "Front"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(arrayName + "Back"), true);

            switch (num)
            {
                case 0:
                    script.WalkAnimSpeed = EditorGUILayout.FloatField(script.WalkAnimSpeed);
                    break;
                case 1:
                    script.RunAnimSpeed = EditorGUILayout.FloatField(script.RunAnimSpeed);
                    break;
                case 2:
                    script.JumpAnimSpeed = EditorGUILayout.FloatField(script.JumpAnimSpeed);
                    break;
                case 3:
                    script.GlideAnimSpeed = EditorGUILayout.FloatField(script.GlideAnimSpeed);
                    break;
                case 4:
                    script.FlyAnimSpeed = EditorGUILayout.FloatField(script.FlyAnimSpeed);
                    break;
                case 5:
                    script.RestAnimSpeed = EditorGUILayout.FloatField(script.RestAnimSpeed);
                    break;
                case 6:
                    script.SleepAnimSpeed = EditorGUILayout.FloatField(script.SleepAnimSpeed);
                    break;
                case 7:
                    script.EatAnimSpeed = EditorGUILayout.FloatField(script.EatAnimSpeed);
                    break;
                case 8:
                    script.DrinkAnimSpeed = EditorGUILayout.FloatField(script.DrinkAnimSpeed);
                    break;
                case 9:
                    script.LMBAnimSpeed = EditorGUILayout.FloatField(script.LMBAnimSpeed);
                    break;
                case 10:
                    script.RMBAnimSpeed = EditorGUILayout.FloatField(script.RMBAnimSpeed);
                    break;
                case 11:
                    script.LimpAnimSpeed = EditorGUILayout.FloatField(script.LimpAnimSpeed);
                    break;
                case 12:
                    script.DeathAnimSpeed = EditorGUILayout.FloatField(script.DeathAnimSpeed);
                    break;
                case 13:
                    script.IdleAnimSpeed = EditorGUILayout.FloatField(script.IdleAnimSpeed);
                    break;
            }

        }
        EditorGUI.indentLevel = 0;
    }
}

