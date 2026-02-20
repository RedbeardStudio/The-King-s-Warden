using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadScene(SceneAsset _scene) 
   {
      SceneManager.LoadScene(_scene.name);
   }
}
