using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Drug : MonoBehaviour
{

    
    [Header("PostProcessSetup")]
    public PostProcessProfile postProcessPrincipal;
    public PostProcessProfile postProcessTrip1;
    public PostProcessProfile postProcessTrip2;

    [SerializeField] private float vignetteDef;

    public Vignette _Vignette;
    public Vignette _VignetteTrip1;
    public Vignette _VignetteTrip2;
    private LensDistortion _LensDist;

    public bool needOpen;
    public bool needClose;

    [Header("Trip Setup")]
    public bool trip1;
    public bool trip2;
    [SerializeField] private float multi = 1.5f;
    [SerializeField] private float minShake = -25;
    [SerializeField] private float maxShake = 25;

    public bool shaking;


    // Start is called before the first frame update
    void Start()
    {
        postProcessPrincipal.TryGetSettings(out _Vignette);
        postProcessTrip1.TryGetSettings(out _VignetteTrip1);
        postProcessTrip2.TryGetSettings(out _VignetteTrip2);

        if (trip2)
        {
            postProcessTrip2.TryGetSettings(out _LensDist);
            _LensDist.intensity.value = 0.4f;
            shaking = true;
        }
        if (trip1)
        {
            postProcessTrip1.TryGetSettings(out _LensDist);
            _LensDist.intensity.value = 0.4f;
            shaking = true;
            _VignetteTrip1.intensity.value = vignetteDef;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trip1 && !trip2)
        {
            CloseEyes(_VignetteTrip1);
            OpenEyes(_VignetteTrip1);
        }

        if(trip2 && !trip1)
        {
            CloseEyes(_VignetteTrip2);
            OpenEyes(_VignetteTrip2);
        }
        if(!trip1 && !trip2)
        {
            CloseEyes(_Vignette);
            OpenEyes(_Vignette);
        }

        Trip();
    }

    void CloseEyes(Vignette toClose)
    {
        if (toClose.intensity.value < 10 && needClose && !needOpen)
        {
            toClose.intensity.value += 0.5f * Time.deltaTime;
        }
    }
    void OpenEyes(Vignette toOpen)
    {
       if(needOpen && !needClose && toOpen.intensity.value >= 0)
        {
            toOpen.intensity.value -= 0.7f * Time.deltaTime;
        } 
    }

    void Trip()
    {
        if (trip2 ||trip1)
        {
            if(_LensDist.intensity.value <= maxShake && shaking)
            {
                _LensDist.intensity.value += multi * Time.deltaTime;
            }
            else if(_LensDist.intensity.value >= maxShake)
            {
                shaking = false;
            }

            if(_LensDist.intensity.value >= minShake && !shaking)
            {
                _LensDist.intensity.value -= multi * Time.deltaTime;
            }
            else if (_LensDist.intensity.value <= maxShake)
            {
                shaking = true;
            }

        }
    }
}
