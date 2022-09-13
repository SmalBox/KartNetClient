using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SmalBox
{
    public class LoginMono : MonoSingletonDontDestory<LoginMono>
    {
        public Action action;
        public bool loginStatus = false;
        public bool logoutAction = false;
        // Update is called once per frame
        void Update()
        {
            if (loginStatus)
            {
                loginStatus = false;
            }
            if (logoutAction)
            {
                logoutAction = false;
            }
            if (action != null)
            {
                action?.Invoke();
                action = null;
            }
        }
    }
}

