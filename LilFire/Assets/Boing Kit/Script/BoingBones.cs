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

using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BoingKit
{
  public class BoingBones : BoingReactor
  {
    [Serializable]
    public class Bone
    {
      internal BoingWork.Params.InstanceData Instance;
      internal Transform Transform;
      internal Vector3 GlobalScale;
      internal Vector3 CachedScale;
      internal Vector3 BlendedPosition;
      internal Vector3 BlendedScale;
      internal Vector3 CachedPosition;
      internal Bounds Bounds;
      internal Quaternion RotationInverse;
      internal Quaternion SpringRotation;
      internal Quaternion SpringRotationInverse;
      internal Quaternion CachedRotation;
      internal Quaternion BlendedRotation;
      internal Quaternion RotationBackPropDeltaPs;
      internal int ParentIndex;
      internal int [] ChildIndices;
      internal float LengthFromRoot;
      internal float AnimationBlend;
      internal float LengthStiffness;
      internal float PoseStiffness;
      internal float BendAngleCap;
      internal float CollisionRadius;
      internal float SquashAndStretch;

      internal void UpdateBounds()
      {
        Bounds = new Bounds(Instance.PositionSpring.Value, 2.0f * CollisionRadius * Vector3.one);
      }

      internal Bone
      (
        Transform transform, 
        int iParent, 
        float lengthFromRoot
      )
      {
        Transform = transform;
        RotationInverse = Quaternion.identity;
        ParentIndex = iParent;
        LengthFromRoot = lengthFromRoot;
        Instance.Reset();
        CachedPosition = transform.position;
        CachedRotation = transform.rotation;
        CachedScale = transform.localScale;
        AnimationBlend = 0.0f;
        LengthStiffness = 0.0f;
        PoseStiffness = 0.0f;
        BendAngleCap = 180.0f;
        CollisionRadius = 0.0f;
      }
    }
    [SerializeField] internal Bone [][] BoneData;

    [Serializable]
    public class Chain
    {
      public enum CurveType
      {
        FlatOne, 
        FlatHalf, 
        FlatZero, 
        RootOneTailHalf, 
        RootOneTailZero, 
        RootHalfTailOne, 
        RootZeroTailOne, 
        Custom, 
      }

      [Tooltip("Root Transform object from which to build a chain (or tree if a bone has multiple children) of bouncy boing bones.")]
      public Transform Root;

      [Tooltip("List of Transform objects to exclude from chain building.")]
      public Transform [] Exclusion;

      [Tooltip("Enable to allow reaction to boing effectors.")]
      public bool EffectorReaction = true;

      [Tooltip(
           "Enable to allow root Transform object to be sprung around as well. " 
         + "Otherwise, no effects will be applied to the root Transform object." 
      )]
      public bool LooseRoot = false;

      [Tooltip(
           "Assign a SharedParamsOverride asset to override the parameters for this chain. " 
         + "Useful for chains using different parameters than that of the BoingBones component."
      )]
      public SharedBoingParams ParamsOverride;

      [ConditionalField(
        Label = "Animation Blend", 
        Tooltip = 
            "Animation blend determines each bone's final transform between the original raw transform and its corresponding boing bone. " 
           + "1.0 means 100% contribution from raw (or animated) transform. 0.0 means 100% contribution from boing bone.\n\n" 
           + "Each curve type provides a type of mapping for each bone's percentage down the chain (0.0 at root & 1.0 at maximum chain length) to the bone's animation blend:\n\n"
           + " - Flat One: 1.0 all the way.\n" 
           + " - Flat Half: 0.5 all the way.\n" 
           + " - Flat Zero: 0.0 all the way.\n" 
           + " - Root One Tail Half: 1.0 at 0% chain length and 0.5 at 100% chain length.\n" 
           + " - Root One Tail Zero: 1.0 at 0% chain length and 0.0 at 100% chain length.\n" 
           + " - Root Half Tail One: 0.5 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Root Zero Tail One: 0.0 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Custom: Custom curve."
      )]
      public CurveType AnimationBlendCurveType = CurveType.RootOneTailZero;
      [ConditionalField("AnimationBlendCurveType", CurveType.Custom, 
        Label = "  Custom Curve"
      )]
      public AnimationCurve AnimationBlendCustomCurve = AnimationCurve.Linear(0.0f, 1.0f, 1.0f, 0.0f);

      [ConditionalField(
        Label = "Length Stiffness", 
        Tooltip = 
             "Length stiffness determines how much each target bone (target transform each boing bone is sprung towards) tries to maintain original distance from its parent. " 
           + "1.0 means 100% distance maintenance. 0.0 means 0% distance maintenance.\n\n" 
           + "Each curve type provides a type of mapping for each bone's percentage down the chain (0.0 at root & 1.0 at maximum chain length) to the bone's length stiffness:\n\n" 
           + " - Flat One: 1.0 all the way.\n" 
           + " - Flat Half: 0.5 all the way.\n" 
           + " - Flat Zero: 0.0 all the way.\n" 
           + " - Root One Tail Half: 1.0 at 0% chain length and 0.5 at 100% chain length.\n" 
           + " - Root One Tail Zero: 1.0 at 0% chain length and 0.0 at 100% chain length.\n" 
           + " - Root Half Tail One: 0.5 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Root Zero Tail One: 0.0 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Custom: Custom curve."
      )]
      public CurveType LengthStiffnessCurveType = CurveType.FlatOne;
      [ConditionalField("LengthStiffnessCurveType", CurveType.Custom, 
        Label = "  Custom Curve"
      )]
      public AnimationCurve LengthStiffnessCustomCurve = AnimationCurve.Linear(0.0f, 1.0f, 1.0f, 1.0f);

      [ConditionalField(
        Label = "Pose Stiffness", 
        Tooltip = 
            "Pose stiffness determines how much each target bone (target transform each boing bone is sprung towards) tries to maintain original transform. " 
           + "1.0 means 100% original transform maintenance. 0.0 means 0% original transform maintenance.\n\n" 
           + "Each curve type provides a type of mapping for each bone's percentage down the chain (0.0 at root & 1.0 at maximum chain length) to the bone's pose stiffness:\n\n" 
           + " - Flat One: 1.0 all the way.\n" 
           + " - Flat Half: 0.5 all the way.\n" 
           + " - Flat Zero: 0.0 all the way.\n" 
           + " - Root One Tail Half: 1.0 at 0% chain length and 0.5 at 100% chain length.\n" 
           + " - Root One Tail Zero: 1.0 at 0% chain length and 0.0 at 100% chain length.\n" 
           + " - Root Half Tail One: 0.5 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Root Zero Tail One: 0.0 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Custom: Custom curve."
      )]
      public CurveType PoseStiffnessCurveType = CurveType.FlatOne;
      [ConditionalField("PoseStiffnessCurveType", CurveType.Custom, 
        Label = "  Custom Curve"
      )]
      public AnimationCurve PoseStiffnessCustomCurve = AnimationCurve.Linear(0.0f, 1.0f, 1.0f, 1.0f);

      [ConditionalField(
        Label = "Bend Angle Cap", 
        Tooltip = "Maximum bone bend angle cap.", 
        Min = 0.0f, 
        Max = 180.0f
      )]
      public float MaxBendAngleCap = 180.0f;
      [ConditionalField(
        Label = "  Curve Type", 
        Tooltip = 
             "Percentage(0.0 = 0 %; 1.0 = 100 %) of maximum bone bend angle cap." 
           + "Bend angle cap limits how much each bone can bend relative to the root (in degrees). " 
           + "1.0 means 100% maximum bend angle cap. 0.0 means 0% maximum bend angle cap.\n\n" 
           + "Each curve type provides a type of mapping for each bone's percentage down the chain (0.0 at root & 1.0 at maximum chain length) to the bone's pose stiffness:\n\n" 
           + " - Flat One: 1.0 all the way.\n" 
           + " - Flat Half: 0.5 all the way.\n" 
           + " - Flat Zero: 0.0 all the way.\n" 
           + " - Root One Tail Half: 1.0 at 0% chain length and 0.5 at 100% chain length.\n" 
           + " - Root One Tail Zero: 1.0 at 0% chain length and 0.0 at 100% chain length.\n" 
           + " - Root Half Tail One: 0.5 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Root Zero Tail One: 0.0 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Custom: Custom curve."
      )]
      public CurveType BendAngleCapCurveType = CurveType.FlatOne;
      [ConditionalField("BendAngleCapCurveType", CurveType.Custom, 
        Label = "    Custom Curve"
      )]
      public AnimationCurve BendAngleCapCustomCurve = AnimationCurve.Linear(0.0f, 1.0f, 1.0f, 1.0f);

      [ConditionalField(
        Label = "Collision Radius", 
        Tooltip = "Maximum bone collision radius."
      )]
      public float MaxCollisionRadius = 0.1f;
      [ConditionalField(
        Label = "  Curve Type", 
        Tooltip = 
             "Percentage (0.0 = 0%; 1.0 = 100%) of maximum bone collision radius.\n\n" 
           + "Each curve type provides a type of mapping for each bone's percentage down the chain (0.0 at root & 1.0 at maximum chain length) to the bone's collision radius:\n\n" 
           + " - Flat One: 1.0 all the way.\n" 
           + " - Flat Half: 0.5 all the way.\n" 
           + " - Flat Zero: 0.0 all the way.\n" 
           + " - Root One Tail Half: 1.0 at 0% chain length and 0.5 at 100% chain length.\n" 
           + " - Root One Tail Zero: 1.0 at 0% chain length and 0.0 at 100% chain length.\n" 
           + " - Root Half Tail One: 0.5 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Root Zero Tail One: 0.0 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Custom: Custom curve."
      )]
      public CurveType CollisionRadiusCurveType = CurveType.FlatOne;
      [ConditionalField("CollisionRadiusCurveType", CurveType.Custom, 
        Label = "    Custom Curve"
      )]
      public AnimationCurve CollisionRadiusCustomCurve = AnimationCurve.Linear(0.0f, 1.0f, 1.0f, 1.0f);

      [ConditionalField(
        Label = "Boing Kit Collision", 
        Tooltip = "Enable to allow this chain to collide with Boing Kit's own implementation of lightweight colliders"
      )]
      public bool EnableBoingKitCollision = false;

      [ConditionalField(
        Label = "Unity Collision", 
        Tooltip = "Enable to allow this chain to collide with Unity colliders."
      )]
      public bool EnableUnityCollision = false;

      [ConditionalField(
        Label = "Inter-Chain Collision", 
        Tooltip = "Enable to allow this chain to collide with other chain (under the same BoingBones component) with inter-chain collision enabled."
      )]
      public bool EnableInterChainCollision = false;

      public Vector3 Gravity = Vector3.zero;
      internal Bounds Bounds;

      [ConditionalField(
        Label = "Squash & Stretch", 
        Tooltip = 
             "Percentage (0.0 = 0%; 1.0 = 100%) of each bone's squash & stretch effect. " 
           + "Squash & stretch is the effect of volume preservation by scaling bones based on how compressed or stretched the distances between bones become.\n\n" 
           + "Each curve type provides a type of mapping for each bone's percentage down the chain (0.0 at root & 1.0 at maximum chain length) to the bone's squash & stretch effect amount:\n\n" 
           + " - Flat One: 1.0 all the way.\n" 
           + " - Flat Half: 0.5 all the way.\n" 
           + " - Flat Zero: 0.0 all the way.\n" 
           + " - Root One Tail Half: 1.0 at 0% chain length and 0.5 at 100% chain length.\n" 
           + " - Root One Tail Zero: 1.0 at 0% chain length and 0.0 at 100% chain length.\n" 
           + " - Root Half Tail One: 0.5 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Root Zero Tail One: 0.0 at 0% chain length and 1.0 at 100% chain length.\n" 
           + " - Custom: Custom curve."
      )]
      public CurveType SquashAndStretchCurveType = CurveType.FlatZero;
      [ConditionalField("SquashAndStretchCurveType", CurveType.Custom, 
        Label = "  Custom Curve"
      )]
      public AnimationCurve SquashAndStretchCustomCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 0.0f);
      [ConditionalField(
        Label = "  Max Squash", 
        Tooltip = "Maximum squash amount. For example, 2.0 means a maximum scale of 200% when squashed.", 
        Min = 1.0f, Max = 5.0f
      )]
      public float MaxSquash = 1.1f;
      [ConditionalField(
        Label = "  Max Stretch", 
        Tooltip = "Maximum stretch amount. For example, 2.0 means a minimum scale of 50% when stretched (200% stretched).", 
        Min = 1.0f, Max = 5.0f
      )]
      public float MaxStretch = 2.0f;


      internal Transform m_scannedRoot;
      internal Transform [] m_scannedExclusion;

      internal float MaxLengthFromRoot = 0.0f;

      public static float EvaluateCurve(CurveType type, float t, AnimationCurve curve)
      {
        switch (type)
        {
        case CurveType.FlatOne:
          return 1.0f;

        case CurveType.FlatHalf:
          return 0.5f;

        case CurveType.FlatZero:
          return 0.0f;

        case CurveType.RootOneTailHalf:
            return 1.0f - 0.5f * Mathf.Clamp01(t);

        case CurveType.RootOneTailZero:
          return 1.0f - Mathf.Clamp01(t);

        case CurveType.RootHalfTailOne:
            return 0.5f + 0.5f * Mathf.Clamp01(t);

        case CurveType.RootZeroTailOne:
          return Mathf.Clamp01(t);

        case CurveType.Custom:
          return curve.Evaluate(t);
        }

        return 0.0f;
      }
    }
    public Chain[] BoneChains = new Chain[1];

    [Range(0.1f, 20.0f)] public float MaxCollisionResolutionSpeed = 3.0f;
    public BoingBoneCollider[] BoingColliders = new BoingBoneCollider[0];
    public Collider[] UnityColliders = new Collider[0];
    private GameObject m_colliderHolder;
    internal SphereCollider SharedSphereCollider { get { return m_colliderHolder ? m_colliderHolder.GetComponent<SphereCollider>() : null; } }

    public bool DebugDrawRawBones = false;
    public bool DebugDrawTargetBones = false;
    public bool DebugDrawBoingBones = false;
    public bool DebugDrawFinalBones = false;
    public bool DebugDrawColliders = false;
    public bool DebugDrawChainBounds = false;
    public bool DebugDrawBoneNames = false;
    public bool DebugDrawLengthFromRoot = false;

    private class RescanEntry
    {
      internal Transform Transform;
      internal int ParentIndex;
      internal float LengthFromRoot;

      internal RescanEntry(Transform transform, int iParent, float lengthFromRoot)
      {
        Transform = transform;
        ParentIndex = iParent;
        LengthFromRoot = lengthFromRoot;
      }
    }

    protected override void Register()
    {
      BoingManager.Register(this);
    }

    protected override void Unregister()
    {
      BoingManager.Unregister(this);
    }

    public void OnValidate()
    {
      RescanBoneChains();
      UpdateCollisionRadius();
    }

    public override void OnEnable()
    {
      base.OnEnable(); 

      RescanBoneChains();
      Reboot();

      string dummyColliderHolderName = "Boing Kit collider holder (don't delete)";
      var dummyChildTransform = transform.Find(dummyColliderHolderName);
      m_colliderHolder = dummyChildTransform != null ? dummyChildTransform.gameObject : null;
      if (m_colliderHolder == null)
      {
        m_colliderHolder = new GameObject(dummyColliderHolderName);
        m_colliderHolder.transform.SetParent(transform);
        m_colliderHolder.transform.localPosition = Vector3.zero;

        m_colliderHolder.AddComponent<SphereCollider>();
      }
    }

    public void RescanBoneChains()
    {
      if (BoneChains == null)
        return;

      int numChains = BoneChains.Length;
      if (BoneData == null || BoneData.Length != numChains)
      {
        var newBoneData = new Bone[numChains][];
        if (BoneData != null)
        {
          for (int iChain = 0, n = Mathf.Min(BoneData.Length, numChains); iChain < n; ++iChain)
            newBoneData[iChain] = BoneData[iChain];
        }
        BoneData = newBoneData;
      }

      var boneQueue = new Queue<RescanEntry>();
      for (int iChain = 0; iChain < numChains; ++iChain)
      {
        var chain = BoneChains[iChain];

        bool chainNeedsRescan = false;
        if (BoneData[iChain] == null)
        {
          chainNeedsRescan = true;
        }
        else if (chain.m_scannedRoot == null)
        {
          chainNeedsRescan = true;
        }
        else if (chain.m_scannedRoot != chain.Root)
        {
          chainNeedsRescan = true;
        }
        else if ((chain.m_scannedExclusion != null) != (chain.Exclusion != null))
        {
          chainNeedsRescan = true;
        }
        else if (chain.Exclusion != null)
        {
          if (chain.m_scannedExclusion.Length != chain.Exclusion.Length)
          {
            chainNeedsRescan = true;
          }
          else
          {
            for (int i = 0; i < chain.m_scannedExclusion.Length; ++i)
            {
              if (chain.m_scannedExclusion[i] == chain.Exclusion[i])
                continue;

              chainNeedsRescan = true;
              break;
            }
          }
        }

        if (!chainNeedsRescan)
          continue;

        var root = chain.Root;
        if (root == null)
        {
          BoneData[iChain] = null;
          continue;
        }

        chain.m_scannedRoot = chain.Root;
        chain.m_scannedExclusion = chain.Exclusion.ToArray();

        chain.MaxLengthFromRoot = 0.0f;

        var aBone = new List<Bone>();
        boneQueue.Enqueue(new RescanEntry(root, -1, 0.0f));
        while (boneQueue.Count > 0)
        {
          var entry = boneQueue.Dequeue();
          if (chain.Exclusion.Contains(entry.Transform))
            continue;

          int iBone = aBone.Count;

          var boneTransform = entry.Transform;
          var aChildIndex = new int[boneTransform.childCount];
          int numChildrenQueued = 0;
          for (int iChild = 0, numChildren = boneTransform.childCount; iChild < numChildren; ++iChild)
          {
            var childTransform = boneTransform.GetChild(iChild);
            if (chain.Exclusion.Contains(childTransform))
              continue;

            float lengthFromParent = Vector3.Distance(entry.Transform.position, childTransform.position);
            float lengthFromRoot = entry.LengthFromRoot + lengthFromParent;

            boneQueue.Enqueue(new RescanEntry(childTransform, iBone, lengthFromRoot));

            aChildIndex[iChild] = iBone + numChildrenQueued + 1;
            ++numChildrenQueued;  
          }

          chain.MaxLengthFromRoot = Mathf.Max(entry.LengthFromRoot, chain.MaxLengthFromRoot);

          var bone = new Bone(boneTransform, entry.ParentIndex, entry.LengthFromRoot);
          if (numChildrenQueued > 0)
            bone.ChildIndices = aChildIndex;

          aBone.Add(bone);
        }

        if (aBone.Count == 0)
          continue;

        // this is only for getting debug draw in editor mode
        float maxLenFromRootInv = MathUtil.InvSafe(chain.MaxLengthFromRoot);
        foreach (var bone in aBone)
        {
          float tBone = Mathf.Clamp01(bone.LengthFromRoot * maxLenFromRootInv);
          bone.CollisionRadius = chain.MaxCollisionRadius * Chain.EvaluateCurve(chain.CollisionRadiusCurveType, tBone, chain.CollisionRadiusCustomCurve);
        }

        BoneData[iChain] = aBone.ToArray();

        Reboot(iChain);
      }
    }

    private void UpdateCollisionRadius()
    {
      for (int iChain = 0; iChain < BoneData.Length; ++iChain)
      {
        var chain = BoneChains[iChain];
        var aBone = BoneData[iChain];

        if (aBone == null)
          continue;

        // this is only for getting debug draw in editor mode
        float maxLenFromRootInv = MathUtil.InvSafe(chain.MaxLengthFromRoot);
        foreach (var bone in aBone)
        {
          float tBone = Mathf.Clamp01(bone.LengthFromRoot * maxLenFromRootInv);
          bone.CollisionRadius = chain.MaxCollisionRadius * Chain.EvaluateCurve(chain.CollisionRadiusCurveType, tBone, chain.CollisionRadiusCustomCurve);
        }
      }
    }

    public override void Reboot()
    {
      base.Reboot();

      for (int i = 0; i < BoneData.Length; ++i)
      {
        Reboot(i);
      }
    }

    public void Reboot(int iChain)
    {
      var aBone = BoneData[iChain];

      if (aBone == null)
        return;

      foreach (var bone in aBone)
      {
        bone.Instance.PositionSpring.Reset(bone.Transform.position);
        bone.Instance.RotationSpring.Reset(bone.Transform.rotation);
        bone.CachedPosition = bone.Transform.position;
        bone.CachedRotation = bone.Transform.rotation;
        bone.CachedScale = bone.Transform.localScale;
      }
    }

    private float m_minScale = 1.0f;
    internal float MinScale { get { return m_minScale; } }
    public override void PrepareExecute()
    {
      base.PrepareExecute();
  
      // repurpose rotation effect flag for bone rotation delta back-propagation
      Params.Bits.SetBit(BoingWork.ReactorFlags.EnableRotationEffect, false);

      float dt = Time.fixedDeltaTime;

      m_minScale = Mathf.Min(transform.localScale.x, transform.localScale.y, transform.localScale.z);

      for (int iChain = 0; iChain < BoneData.Length; ++iChain)
      {
        var chain = BoneChains[iChain];
        var aBone = BoneData[iChain];

        if (aBone == null || chain.Root == null || aBone.Length == 0)
          continue;

        // update length from root
        float maxLengthFromRoot = 0.0f;
        foreach (var bone in aBone)
        {
          if (bone.ParentIndex < 0)
          {
            bone.LengthFromRoot = 0.0f;
            continue;
          }

          var parentBone = aBone[bone.ParentIndex];
          float distFromParent = Vector3.Distance(bone.Transform.position, parentBone.Transform.position);
          bone.LengthFromRoot = parentBone.LengthFromRoot + distFromParent;
          maxLengthFromRoot = Mathf.Max(maxLengthFromRoot, bone.LengthFromRoot);
        }
        float maxLengthFromRootInv = MathUtil.InvSafe(maxLengthFromRoot);

        // set up bones
        foreach(var bone in aBone)
        {
          // evaluate curves
          float tBone = bone.LengthFromRoot * maxLengthFromRootInv;
          bone.AnimationBlend = Chain.EvaluateCurve(chain.AnimationBlendCurveType, tBone, chain.AnimationBlendCustomCurve);
          bone.LengthStiffness = Chain.EvaluateCurve(chain.LengthStiffnessCurveType, tBone, chain.LengthStiffnessCustomCurve);
          bone.PoseStiffness = Chain.EvaluateCurve(chain.PoseStiffnessCurveType, tBone, chain.PoseStiffnessCustomCurve);
          bone.BendAngleCap = chain.MaxBendAngleCap * MathUtil.Deg2Rad * Chain.EvaluateCurve(chain.BendAngleCapCurveType, tBone, chain.BendAngleCapCustomCurve);
          bone.CollisionRadius = chain.MaxCollisionRadius * Chain.EvaluateCurve(chain.CollisionRadiusCurveType, tBone, chain.CollisionRadiusCustomCurve);
          bone.SquashAndStretch = Chain.EvaluateCurve(chain.SquashAndStretchCurveType, tBone, chain.SquashAndStretchCustomCurve);
        }

        // compute target transform
        var rootBone = aBone[0];
        Vector3 rootAnimPos = rootBone.Transform.position;
        foreach (var bone in aBone)
        {
          bone.RotationInverse = Quaternion.Inverse(bone.Transform.rotation);
          bone.SpringRotation = bone.Instance.RotationSpring.ValueQuat;
          bone.SpringRotationInverse = Quaternion.Inverse(bone.SpringRotation);

          Vector3 targetPos = bone.Transform.position;
          Quaternion targetRot = bone.Transform.rotation;

          // compute translation & rotation in parent space
          if (bone.ParentIndex >= 0)
          {
            // TODO: use parent spring transform to compute blended position & rotation

            var parentBone = aBone[bone.ParentIndex];

            Vector3 parentAnimPos = parentBone.Transform.position;
            Vector3 parentSpringPos = parentBone.Instance.PositionSpring.Value;

            Vector3 springPosPs = parentBone.SpringRotationInverse * (bone.Instance.PositionSpring.Value - parentSpringPos);
            Quaternion springRotPs = parentBone.SpringRotationInverse * bone.Instance.RotationSpring.ValueQuat;

            Vector3 animPos = bone.Transform.position;
            Quaternion animRot = bone.Transform.rotation;
            Vector3 animPosPs = parentBone.RotationInverse * (animPos - parentAnimPos);
            Quaternion animRotPs = parentBone.RotationInverse * animRot;

            // apply pose stiffness
            float tPoseStiffness = bone.PoseStiffness;
            Vector3 blendedPosPs = Vector3.Lerp(springPosPs, animPosPs, tPoseStiffness);
            Quaternion blendedRotPs = Quaternion.Slerp(springRotPs, animRotPs, tPoseStiffness);

            targetPos = parentSpringPos + (parentBone.SpringRotation * blendedPosPs);
            targetRot = parentBone.SpringRotation * blendedRotPs;

            // bend angle cap
            if (bone.BendAngleCap < MathUtil.Pi - MathUtil.Epsilon)
            {
              Vector3 targetPosDelta = targetPos - rootAnimPos;
              targetPosDelta = VectorUtil.ClampBend(targetPosDelta, animPos - rootAnimPos, bone.BendAngleCap);
              targetPos = rootAnimPos + targetPosDelta;
            }
          }

          // do we need target-level collision?
          /*
          // Boing Kit colliders
          if (chain.EnableBoingKitCollision)
          {
            foreach (var collider in BoingColliders)
            {
              if (collider == null)
                continue;

              Vector3 push;
              bool collided = collider.Collide(targetPos, MinScale * bone.CollisionRadius, out push);
              if (!collided)
                continue;

              targetPos += push;
            }
          }

          // Unity colliders
          if (chain.EnableUnityCollision)
          {
            foreach (var rigidbody in UnityRigidBodies)
            {
              if (rigidbody == null)
                continue;

              var collider = rigidbody.GetComponent<Collider>();
              if (collider == null)
                continue;

              if (!bone.Bounds.Intersects(collider.bounds))
                continue;

              SharedSphereCollider.center = targetPos;
              SharedSphereCollider.radius = bone.CollisionRadius;

              Vector3 pushDir;
              float pushDist;
              bool collided = 
              Physics.ComputePenetration
              (
                SharedSphereCollider, Vector3.zero, Quaternion.identity, 
                collider, collider.transform.position, collider.transform.rotation, 
                out pushDir, out pushDist
              );
              if (!collided)
                continue;

              targetPos += pushDir * pushDist;
            }
          }
          */

          if (chain.ParamsOverride == null)
          {
            bone.Instance.PrepareExecute
            (
              ref Params, 
              targetPos, 
              targetRot, 
              MinScale, 
              true
            );
          }
          else
          {
            bone.Instance.PrepareExecute
            (
              ref chain.ParamsOverride.Params, 
              targetPos, 
              targetRot, 
              MinScale, 
              true
            );
          }
        }
      }
    }

    public void AccumulateTarget(ref BoingEffector.Params effector)
    {
      for (int iChain = 0; iChain < BoneData.Length; ++iChain)
      {
        var chain = BoneChains[iChain];
        var aBone = BoneData[iChain];

        if (aBone == null)
          continue;

        if (!chain.EffectorReaction)
          continue;

        foreach (var bone in aBone)
        {
          if (chain.ParamsOverride == null)
          {
            bone.Instance.AccumulateTarget(ref Params, ref effector);
          }
          else
          {
            Bits32 bits = chain.ParamsOverride.Params.Bits;
            chain.ParamsOverride.Params.Bits = Params.Bits;
            bone.Instance.AccumulateTarget(ref chain.ParamsOverride.Params, ref effector);
            chain.ParamsOverride.Params.Bits = bits;
          }
        }
      }
    }

    public void EndAccumulateTargets()
    {
      for (int iChain = 0; iChain < BoneData.Length; ++iChain)
      {
        var chain = BoneChains[iChain];
        var aBone = BoneData[iChain];

        if (aBone == null)
          continue;

        foreach (var bone in aBone)
        {
          if (chain.ParamsOverride == null)
          {
            bone.Instance.EndAccumulateTargets(ref Params);
          }
          else
          {
            bone.Instance.EndAccumulateTargets(ref chain.ParamsOverride.Params);
          }
        }
      }
    }

    public new void Restore()
    {
      if (LastPullResultsFrame < Time.frameCount)
        return;

      for (int iChain = 0; iChain < BoneData.Length; ++iChain)
      {
        var chain = BoneChains[iChain];
        var aBone = BoneData[iChain];

        if (aBone == null)
          continue;

        for (int iBone = 0; iBone < aBone.Length; ++iBone)
        {
          var bone = aBone[iBone];

          // skip fixed root
          if (iBone == 0 && !chain.LooseRoot)
            continue;

          bone.Transform.position = bone.CachedPosition;
          bone.Transform.rotation = bone.CachedRotation;
          bone.Transform.localScale = bone.CachedScale;
        }
      }

      var sharedCircleCollider = SharedSphereCollider;
      if (sharedCircleCollider != null)
      {
        sharedCircleCollider.radius = 0.0f;
      }
    }

    #if UNITY_EDITOR
    public void OnDrawGizmos()
    {
      if (BoneData == null)
        return;

      bool selected = false;
      foreach (var selectedGo in UnityEditor.Selection.gameObjects)
      {
        if (gameObject == selectedGo)
        {
          selected = true;
          break;
        }

        foreach (var collider in BoingColliders)
        {
          if (collider.gameObject == selectedGo)
          {
            selected = true;
            break;
          }
        }
        if (selected)
          break;
      }

      if (!selected)
        return;

      for (int iChain = 0; iChain < BoneData.Length; ++iChain)
      {
        var chain = BoneChains[iChain];
        var aBone = BoneData[iChain];

        if (aBone == null)
          continue;

        foreach (var bone in aBone)
        {
          var parentBone = 
            bone.ParentIndex >= 0 
              ? aBone[bone.ParentIndex] 
              : null;
          
          Vector3 boneAnimPos = Application.isPlaying ? bone.CachedPosition : bone.Transform.position;
          Vector3 boneTargetPos = bone.Instance.PositionTarget;
          Vector3 boneSpringPos = bone.Instance.PositionSpring.Value;
          Vector3 boneBlendedPos = bone.BlendedPosition;
          Quaternion boneAnimRot = Application.isPlaying ? bone.CachedRotation : bone.Transform.rotation;
          Quaternion boneTargetRot = QuaternionUtil.FromVector4(bone.Instance.RotationTarget);
          Quaternion boneSpringRot = bone.Instance.RotationSpring.ValueQuat;
          Quaternion boneBlendedRot = bone.BlendedRotation;

          float boneRadius = 
            (chain.EnableBoingKitCollision || chain.EnableUnityCollision || chain.EnableInterChainCollision)
              ? MinScale * bone.CollisionRadius 
              : 0.02f;

          Gizmos.color = Color.white;
          if (DebugDrawRawBones)
          {
            Gizmos.matrix = Matrix4x4.TRS(boneAnimPos, boneAnimRot, Vector3.one);
            Gizmos.DrawWireSphere(Vector3.zero, boneRadius);
            Gizmos.matrix = Matrix4x4.identity;

            if (parentBone != null)
            {
              Vector3 parentAnimPos = 
                Application.isPlaying 
                  ? parentBone.CachedPosition 
                  : parentBone.Transform.position;
              
              Gizmos.DrawLine(boneAnimPos, parentAnimPos);
            }

            if (DebugDrawBoneNames)
            {
              Handles.Label(boneAnimPos, bone.Transform.name);
            }

            if (DebugDrawLengthFromRoot)
            {
              float tBone = Mathf.Clamp01(bone.LengthFromRoot * MathUtil.InvSafe(chain.MaxLengthFromRoot));
              Handles.Label(boneAnimPos, bone.LengthFromRoot.ToString("n3") + " (t: " + tBone.ToString("n2") + ")");
            }
          }

          Gizmos.color = Color.yellow;
          if (DebugDrawBoingBones && Application.isPlaying)
          {
            Gizmos.matrix = Matrix4x4.TRS(boneSpringPos, boneSpringRot, Vector3.one);
            Gizmos.DrawWireSphere(Vector3.zero, boneRadius);
            Gizmos.matrix = Matrix4x4.identity;

            if (parentBone != null)
            {
              Vector3 parentSpringPos = parentBone.Instance.PositionSpring.Value;

              Gizmos.DrawLine(boneSpringPos, parentSpringPos);
            }

            if (DebugDrawBoneNames)
            {
              Handles.Label(boneSpringPos, bone.Transform.name);
            }
          }

          Gizmos.color = Color.red;
          if (DebugDrawTargetBones && Application.isPlaying)
          {
            Gizmos.matrix = Matrix4x4.TRS(boneTargetPos, boneTargetRot, Vector3.one);
            Gizmos.DrawWireSphere(Vector3.zero, boneRadius);
            Gizmos.matrix = Matrix4x4.identity;

            if (parentBone != null)
            {
              Vector3 parentTargetPos = parentBone.Instance.PositionTarget;

              Gizmos.DrawLine(boneTargetPos, parentTargetPos);
            }

            if (DebugDrawBoneNames)
            {
              Handles.Label(boneTargetPos, bone.Transform.name);
            }
          }

          Gizmos.color = Color.green;
          if (DebugDrawFinalBones && Application.isPlaying)
          {
            Gizmos.matrix = Matrix4x4.TRS(boneBlendedPos, boneBlendedRot, Vector3.one);
            Gizmos.DrawWireSphere(Vector3.zero, boneRadius);
            Gizmos.matrix = Matrix4x4.identity;

            if (parentBone != null)
            {
              Vector3 blendedParentBone = Vector3.Lerp(parentBone.Instance.PositionSpring.Value, parentBone.CachedPosition, parentBone.AnimationBlend);

              Gizmos.DrawLine(boneBlendedPos, blendedParentBone);
            }

            if (DebugDrawBoneNames)
            {
              Handles.Label(boneBlendedPos, bone.Transform.name);
            }
          }
        }

        Gizmos.color = Color.cyan;
        if (DebugDrawChainBounds && (chain.EnableBoingKitCollision || chain.EnableUnityCollision))
        {
          Gizmos.matrix = Matrix4x4.Translate(chain.Bounds.center);
          Gizmos.DrawWireCube(Vector3.zero, chain.Bounds.size);
          Gizmos.matrix = Matrix4x4.identity;
        }
      }

      if (DebugDrawColliders)
      {
        foreach (var collider in BoingColliders)
        {
          if (collider == null)
            continue;
  
          collider.DrawGizmos();
        }
      }
    }
    #endif
  }
}
