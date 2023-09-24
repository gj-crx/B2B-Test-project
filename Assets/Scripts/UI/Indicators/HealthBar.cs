using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;

        public void ValueChanged(float currentValue, float MaxValue) => healthSlider.value = currentValue / MaxValue;
    }
}
