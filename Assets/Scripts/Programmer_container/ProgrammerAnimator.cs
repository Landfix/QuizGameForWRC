using Spine.Unity;
using UnityEngine;

namespace Programmer_container
{
    [RequireComponent(typeof(SkeletonGraphic))]
    public class ProgrammerAnimator : MonoBehaviour
    {
        private const string IdleState = "idle";
        private const string SmokesHeavilyState = "smokesHeavily";
        private const string FaintlySmokesState = "faintlySmokes";
        private const string BurnState = "burn";
        
        [SerializeField] private SkeletonGraphic _skeletonGraphic;

        public void Initialize()
        {
            SetIdleState();
        }

        public void SetIdleState() => 
            _skeletonGraphic.AnimationState.SetAnimation(0,IdleState,true);

        public void SetFaintlySmokesState() => 
            _skeletonGraphic.AnimationState.SetAnimation(0,FaintlySmokesState,true);

        public void SetSmokesHeavilyState() => 
            _skeletonGraphic.AnimationState.SetAnimation(0,SmokesHeavilyState,true);

        public void SetBurnState() => 
            _skeletonGraphic.AnimationState.SetAnimation(0,BurnState,true);
    }
}