using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Recoloring : MonoBehaviour
{
   [SerializeField] 
   private float _recoloringDuration;

   [SerializeField]
   private float _delayRecoloring;

   [SerializeField]
   private Renderer _cubeRenderer;

   private Color _currentColor;
   private Color _newColor;
   private float _recoloringTime;
   private float _timeAfterRecoloring;
   private bool _isWaiting;

   private void Awake()
   {
      _newColor = CreateNewColor();
   }

   private void Update()
   {
      TryChangeColor();
   }

   private void ChangeColor()
   {
      _recoloringTime += Time.deltaTime;
      var progress = _recoloringTime / _recoloringDuration;
      _cubeRenderer.material.color = Color.Lerp(_currentColor, _newColor, progress);

      if (_recoloringTime >= _recoloringDuration)
      {
         _recoloringTime = 0;
         _timeAfterRecoloring = 0;
         _currentColor = _newColor;
         _isWaiting = true;
         _newColor = CreateNewColor();
      }
   }

   private Color CreateNewColor()
   {
      return Random.ColorHSV(0, 1, 0.8f, 1, 0.5f, 0.5f);
   }

   private void TryChangeColor()
   {
      if (_isWaiting)
      {
         _timeAfterRecoloring += Time.deltaTime;
         
         if (_timeAfterRecoloring >= _delayRecoloring)
         {
            _isWaiting = false;
         }
         else
         {
            return;
         }
      }
      
      ChangeColor();
   }
}
