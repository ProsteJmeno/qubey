using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Assets.scripts
{
    class lvl3 : MonoBehaviour
    {
        public deathEffect death;
        public Animator Animator;

        public PostProcessProfile profile;
        public bool efct;

        public int stage;

        private float distortion = 0;
        private float Distortion
        {
            get => distortion;
            set
            {
                distortion = value;

                var ld = profile.GetSetting<LensDistortion>();
                ld.intensityX.value = distortion;
                ld.intensityY.value = distortion;
            }
        }
        private float aberration = 0;

        public void Start()
        {
            stage = 0;
        }

        private float Aberration
        {
            get => aberration;
            set
            {
                aberration = value;

                var ld = profile.GetSetting<ChromaticAberration>();
                ld.intensity.value = aberration;
            }
        }

        private void Update()
        {
            if (efct)
            {
                if (!(stage >= 5))
                {
                    stage++;
                    var ld = stage * -20;
                    var ca = stage * 0.2f;
                    profile.GetSetting<LensDistortion>().intensity.value = ld;
                    profile.GetSetting<ChromaticAberration>().intensity.value = ca;
                    efct = false;
                }
                else
                {
                    death.nextLevel(Animator, 2);
                }
                
            }
        }

        private IEnumerator StageUp(int stage, float wait)
        {
            yield return new WaitForSeconds(wait);
            var ld = stage * -20;
            var ca = stage * 0.2f;
            profile.GetSetting<LensDistortion>().intensity.value = ld;
            profile.GetSetting<ChromaticAberration>().intensity.value = ca;
        }

#if UNITY_EDITOR
        private void OnDestroy()
        {
            stage = 0;
            profile.GetSetting<LensDistortion>().intensity.value = 0;
            profile.GetSetting<LensDistortion>().intensityX.value = 1;
            profile.GetSetting<LensDistortion>().intensityY.value = 1;
            profile.GetSetting<ChromaticAberration>().intensity.value = 0;
            efct = false;
        }
#endif

    }
}
