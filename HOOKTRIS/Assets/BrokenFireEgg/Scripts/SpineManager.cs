using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineManager : MonoBehaviour {
    SkeletonAnimation SA;

        [SpineAnimation(dataField: "skeletonAnimation")]
        public string die = "";
        [SpineAnimation(dataField: "skeletonAnimation")]
        public string idle = "";
        [SpineAnimation(dataField: "skeletonAnimation")]
        public string throw0 = "";
        [SpineAnimation(dataField: "skeletonAnimation")]
        public string throw1 = "";
        [SpineAnimation(dataField: "skeletonAnimation")]
        public string move = "";
        [SpineAnimation(dataField: "skeletonAnimation")]
        public string jump = "";
        [SpineAnimation(dataField: "skeletonAnimation")]
        public string clear = "";
    
    public void ChangeAnimation(string action,int tracknum,bool loop)
    {
        SA.AnimationState.SetAnimation(tracknum, action, loop);

    }
    public void Start()
    {
        SA = GetComponent<SkeletonAnimation>();
        Debug.Log(move);
    }
}
