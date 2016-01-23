using System;
using UnityEngine;
using System.Collections;
//using UnityEditor;
using LocalConfig = Config.Entities.Astronaut;

public class ModifyImmortalityParticle : MonoBehaviourEx, IHandle<AstronautImmortalityMessage>
{
    //private SerializedObject so;
    public void Start()
    {
       // so = new SerializedObject(GetComponent<ParticleSystem>());

        //Tell all variables of the SerializedObject
        /*SerializedProperty it = so.GetIterator();
        while (it.Next(true))
            Debug.Log(it.propertyPath);*/
    }

    private IEnumerator AlertImmortalityEnd()
    {
        //yield return new WaitForSeconds(LocalConfig.ImmortalityTime - 3);
        ////so.FindProperty("InitialModule.minColor").vector4Value = new Vector4(0, 139, 255, 255);
        //so.FindProperty("InitialModule.startColor.maxColor").colorValue = Color.red;
        //so.FindProperty("InitialModule.startColor.minColor").colorValue = Color.red;
        //so.FindProperty("InitialModule.startLifetime.scalar").floatValue = 0.15f;
        //so.ApplyModifiedProperties();

        //yield return new WaitForSeconds(3f);
        //so.FindProperty("InitialModule.startColor.maxColor").colorValue = new Color(0f, 139f, 255f, 255f);
        //so.FindProperty("InitialModule.startColor.minColor").colorValue = new Color(122f, 211f, 255f, 255f);
        //so.FindProperty("InitialModule.startLifetime.scalar").floatValue = 0.5f;
        //so.ApplyModifiedProperties();
        //so.ApplyModifiedProperties();
        yield return null;
    }

    public void Handle(AstronautImmortalityMessage message)
    {
        StartCoroutine(AlertImmortalityEnd());
    }
}
