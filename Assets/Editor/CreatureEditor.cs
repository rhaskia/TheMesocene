using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity;
using UnityEngine.UI;
using System.Globalization;

[CustomEditor(typeof(Creature))]
public class CreatureEditor : Editor
{

    bool[] Sbools = new bool[15];
    bool AnimationsOpen;
    bool DataOpen;
    Creature script;

    public override void OnInspectorGUI()
    {

        //Get script
        script = (Creature)target;

        serializedObject.Update();

        //Data
        DataOpen = EditorGUILayout.Foldout(DataOpen, "Data");

        if (DataOpen)
        {
            script.sneakSpeed = EditorGUILayout.FloatField("Sneak Speed:", script.sneakSpeed);
            script.walkSpeed = EditorGUILayout.FloatField("Walk Speed:", script.walkSpeed);
            script.runSpeed = EditorGUILayout.FloatField("Run Speed:", script.runSpeed);
            EditorUtility.SetDirty(script);
        }

        //Animations
        AnimationsOpen = EditorGUILayout.Foldout(AnimationsOpen, "Animations");

        if (AnimationsOpen)
        {
            drawArray("idleAnim", 13);

            drawArray("walkAnim", 0);
            drawArray("runAnim", 1);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            script.canJump = EditorGUILayout.Toggle("Can Jump", script.canJump);
            script.canGlide = EditorGUILayout.Toggle("Can Glide", script.canGlide);
            script.canFly = EditorGUILayout.Toggle("Can Fly", script.canFly);

            if (script.canJump) { drawArray("jumpAnim", 2); }
            if (script.canGlide) { drawArray("glideAnim", 3); }
            if (script.canFly) { drawArray("flyAnim", 4); }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            drawArray("restAnim", 5);
            drawArray("sleepAnim", 6);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            drawArray("eatAnim", 7);
            drawArray("drinkAnim", 8);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            drawArray("LMBAnim", 9);
            drawArray("RMBAnim", 10);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            drawArray("limpAnim", 11);
            drawArray("deathAnim", 12);
        }

        EditorUtility.SetDirty(script);
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
                    script.walkAnimSpeed = EditorGUILayout.FloatField(script.walkAnimSpeed);
                    break;
                case 1:
                    script.runAnimSpeed = EditorGUILayout.FloatField(script.runAnimSpeed);
                    break;
                case 2:
                    script.jumpAnimSpeed = EditorGUILayout.FloatField(script.jumpAnimSpeed);
                    break;
                case 3:
                    script.glideAnimSpeed = EditorGUILayout.FloatField(script.glideAnimSpeed);
                    break;
                case 4:
                    script.flyAnimSpeed = EditorGUILayout.FloatField(script.flyAnimSpeed);
                    break;
                case 5:
                    script.restAnimSpeed = EditorGUILayout.FloatField(script.restAnimSpeed);
                    break;
                case 6:
                    script.sleepAnimSpeed = EditorGUILayout.FloatField(script.sleepAnimSpeed);
                    break;
                case 7:
                    script.eatAnimSpeed = EditorGUILayout.FloatField(script.eatAnimSpeed);
                    break;
                case 8:
                    script.drinkAnimSpeed = EditorGUILayout.FloatField(script.drinkAnimSpeed);
                    break;
                case 9:
                    script.LMBAnimSpeed = EditorGUILayout.FloatField(script.LMBAnimSpeed);
                    break;
                case 10:
                    script.RMBAnimSpeed = EditorGUILayout.FloatField(script.RMBAnimSpeed);
                    break;
                case 11:
                    script.limpAnimSpeed = EditorGUILayout.FloatField(script.limpAnimSpeed);
                    break;
                case 12:
                    script.deathAnimSpeed = EditorGUILayout.FloatField(script.deathAnimSpeed);
                    break;
                case 13:
                    script.idleAnimSpeed = EditorGUILayout.FloatField(script.idleAnimSpeed);
                    break;
            }

        }
        EditorGUI.indentLevel = 0;
    }
}

