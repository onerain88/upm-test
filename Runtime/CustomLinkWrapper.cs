using System;
using System.Collections.Generic;
using TapTap.Common;
using UnityEngine;

namespace TapTap.Billboard
{
    public class CustomLinkWrapper
    {
        public string customLink;

        public TapError error;

        public CustomLinkWrapper(string url)
        {
            customLink =  url;
        }
    }
}