using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Assets.scripts
{
    class AnimateDistortion : MonoBehaviour
    {
        public PostProcessProfile profile;

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

        private TweenerCore<float, float, FloatOptions> tween;
        private float aberration = 0;
        private Sequence sequence;

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

        private void Start()
        {
            Distortion = 0;
            tween = DOTween
                .To(() => Distortion, v => Distortion = v, 0.3f, 1)
                .SetEase(Ease.InOutQuad)
                .SetLoops(-1, LoopType.Yoyo);

            Aberration = 0;
            var aberrationTween = DOTween
                    .To(() => Aberration, va => Aberration = va, 1, 0.25f)
                    .SetEase(Ease.OutQuad)
                    .SetLoops(2, LoopType.Yoyo);

            sequence = DOTween.Sequence()
                .Append(aberrationTween)
                .AppendInterval(3)
                .SetEase(Ease.Linear)
                .SetLoops(-1);

            //var ca = profile.GetSetting<ChromaticAberration>();
            //    ca.intensity.value = 0f;

            //    DOTween
            //        .To(() => ca.intensity.value, va => ca.intensity.value = va, 1, 0.1f)
            //        .SetEase(Ease.InOutQuad)
            //        .SetLoops(2, LoopType.Yoyo);

        }

        private void OnDestroy()
        {
            tween.Kill();
            sequence.Kill();
        }
    }
}
