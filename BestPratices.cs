// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Colocar aqui minha assinatura

//Referencias Codigos
//https://docs.unity3d.com/Manual/PlatformDependentCompilation.html

// Utilizar apenas namespace que eu estou realmente usando
using UnityEngine;
using System;

//Aprender e usar mues proprios namespaces
namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// Component that allows dragging an object with your hand on HoloLens.
    /// Dragging is done by calculating the angular delta and z-delta between the current and previous hand positions,
    /// and then repositioning the object based on that.
    /// </summary>
    public class HandDraggable : MonoBehaviour, IFocusable, IInputHandler, ISourceStateHandler // Aprender a importa essas coisas
    {
        /// <summary>
        /// Event triggered when dragging starts.
        /// </summary>
        public event Action StartedDragging; // Usar sumary a aprender melhor eventos
        
        [Tooltip("Transform that will be dragged. Defaults to the object of the component.")]
        public Transform HostTransform;
        
        public enum RotationModeEnum
        {
            Default,
            LockObjectRotation,
            OrientTowardUser,
            OrientTowardUserAndKeepUpright
        }
        public RotationModeEnum RotationMode = RotationModeEnum.Default;
        
        private static float objRefDistance; // usar private e static
        
        public void StopDragging()
        {
        Debug.LogError(string.Format("The key \"{0}\" wasn't found in the Text file for the module \"{1}\".", key, this.name));
        
#if UNITY_2017_2_OR_NEWER
            InteractionSourceInfo sourceKind;
            currentInputSource.TryGetSourceKind(currentInputSourceId, out sourceKind);
            switch (sourceKind)
            {
                case InteractionSourceInfo.Hand:
                    currentInputSource.TryGetGripPosition(currentInputSourceId, out inputPosition);
                    break;
                case InteractionSourceInfo.Controller:
                    currentInputSource.TryGetPointerPosition(currentInputSourceId, out inputPosition);
                    break;
            }
#else
            currentInputSource.TryGetPointerPosition(currentInputSourceId, out inputPosition);
#endif
         }
     }
}
