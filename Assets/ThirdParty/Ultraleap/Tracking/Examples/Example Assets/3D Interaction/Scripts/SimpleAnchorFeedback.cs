/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2022.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using Leap.Unity.Interaction;
using UnityEngine;

namespace Leap.InteractionEngine.Examples
{

    [RequireComponent(typeof(Leap.Unity.Interaction.Anchor))]
    [AddComponentMenu("")]
    public class SimpleAnchorFeedback : MonoBehaviour
    {

        public Transform scaleTarget;

        private Leap.Unity.Interaction.Anchor _anchor;

        private Vector3 _initScaleVector;
        private float _curScale = 1F;

        void Start()
        {
            _anchor = GetComponent<Leap.Unity.Interaction.Anchor>();

            _initScaleVector = scaleTarget.transform.localScale;
        }

        void Update()
        {
            float _targetScale = 1F;

            if (_anchor.isPreferred)
            {
                _targetScale = 1.3F;
            }

            if (_anchor.hasAnchoredObjects)
            {
                _targetScale = 2.4F;
            }

            _curScale = Mathf.Lerp(_curScale, _targetScale, 20F * Time.deltaTime);

            scaleTarget.transform.localScale = _curScale * _initScaleVector;
        }

    }

}