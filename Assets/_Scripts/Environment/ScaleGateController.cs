using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using _Scripts;
using _Scripts.Environment;
using UnityEngine;

public class ScaleGateController : MonoBehaviour
{
    [SerializeField] private List<GateInfo> gates;
    
    private readonly Color _upscaleColor = new (0.4f, 1f, 0.51f);
    private readonly Color _downscaleColor = new (1f, 0.33f, 0.15f);

    private void Start()
    {
        foreach (var gate in gates)
        {
            gate.scaleGate.gateInfo = gate;
        }
    }

    private void OnValidate()
    {
        for (var i = 0; i < gates.Count; ++i)
        {
            gates[i].scaleGate.textUI.SetText
            (((int)gates[i].scaleFactor * (int)gates[i].scaleType).ToString(CultureInfo.InvariantCulture));
            
            switch (gates[i].scaleType)
            {
                case GateInfo.ScaleType.Upscale:
                    gates[i].scaleGate.textUI.color = _upscaleColor;
                    break;
                case GateInfo.ScaleType.Downscale:
                    gates[i].scaleGate.textUI.color = _downscaleColor;
                    break;
            }
            
            switch (i)
            {
                case 0 when gates.Count == 1:
                    gates[i].name = "Gate";
                    break;
                case 0:
                    gates[i].name = "Left Gate";
                    break;
                case 1:
                    gates[i].name = "Right Gate";
                    break;
                default:
                    gates[i].name = $"Gate {i+1}";
                    break;
            }
        }
    }
}
