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

using UnityEditor;

namespace BoingKit
{
  [CustomEditor(typeof(BoingBones))]
  [CanEditMultipleObjects]
  public class BoingBonesEditor : BoingReactorEditor
  {
    private SerializedProperty BoneChains;
    private SerializedProperty MaxCollisionResolutionSpeed;
    private SerializedProperty BoingColliders;
    private SerializedProperty UnityColliders;

    private SerializedProperty DebugDrawRawBones;
    private SerializedProperty DebugDrawTargetBones;
    private SerializedProperty DebugDrawBoingBones;
    private SerializedProperty DebugDrawFinalBones;
    private SerializedProperty DebugDrawColliders;
    private SerializedProperty DebugDrawBoneNames;
    private SerializedProperty DebugDrawLengthFromRoot;
    private SerializedProperty DebugDrawChainBounds;

    public override void OnEnable()
    {
      base.OnEnable();

      BoneChains = serializedObject.FindProperty("BoneChains");
      MaxCollisionResolutionSpeed = serializedObject.FindProperty("MaxCollisionResolutionSpeed");
      BoingColliders = serializedObject.FindProperty("BoingColliders");
      UnityColliders = serializedObject.FindProperty("UnityColliders");

      DebugDrawRawBones = serializedObject.FindProperty("DebugDrawRawBones");
      DebugDrawTargetBones = serializedObject.FindProperty("DebugDrawTargetBones");
      DebugDrawBoingBones = serializedObject.FindProperty("DebugDrawBoingBones");
      DebugDrawFinalBones = serializedObject.FindProperty("DebugDrawFinalBones");
      DebugDrawColliders = serializedObject.FindProperty("DebugDrawColliders");
      DebugDrawChainBounds = serializedObject.FindProperty("DebugDrawChainBounds");
      DebugDrawBoneNames = serializedObject.FindProperty("DebugDrawBoneNames");
      DebugDrawLengthFromRoot = serializedObject.FindProperty("DebugDrawLengthFromRoot");
    }

    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();


      serializedObject.Update();


      Header("Bones");
      {
        Property(BoneChains, 
          "Bone Chains", 
              "Each bone chain builds a chain (or tree if a bone has multiple children) of bouncy bones starting from the specified roots.\n\n" 
            + "Each root is a Transform object. It can be that of a game object or of a bone." 
        );

        Property(BoingColliders, 
          "Boing Colliders", 
              "List of Boing Colliders, Boing Kit's own implementation of lightweight colliders, that collide with bones."
        );

        Property(UnityColliders, 
          "Unity Colliders", 
              "List of Unity colliders that collide with bones."
        );

        Property(MaxCollisionResolutionSpeed,
          "Max Collision Resolution Speed",
              "Maximum speed of pushing bones outside of colliders (distance units per second)."
        );
      }


      Header("Debug Draw");
      {
        Property(DebugDrawRawBones,       "Raw Bones"                     , "Draw bones before any effects applied.");
        Property(DebugDrawTargetBones,    "Target Bones (Play Mode Only)" , "Draw target bones of boing bones are sprung to.");
        Property(DebugDrawBoingBones,     "Boing Bones (Play Mode Only)"  , "Draw internal boing bones.");
        Property(DebugDrawFinalBones,     "Final Bones (Play Mode Only)"  , "Draw final bones after animation blend.");
        Property(DebugDrawColliders,      "Colliders"                     , "Draw final bones after animation blend.");
        Property(DebugDrawChainBounds,    "Chain Bounds (Play Mode Only)" , "Draw AABB bounds of bone chains.");
        Property(DebugDrawBoneNames,      "Bone Names"                    , "Draw bone names.");
        Property(DebugDrawLengthFromRoot, "Chain Length From Root"        , "Draw chain length to each bone.");
      }

      serializedObject.ApplyModifiedProperties();
    }
  }

}
