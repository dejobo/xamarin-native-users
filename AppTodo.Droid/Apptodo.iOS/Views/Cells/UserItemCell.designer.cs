// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Apptodo.iOS.Views
{
    [Register ("UserItemCell")]
    partial class UserItemCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbUserName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lbUserName != null) {
                lbUserName.Dispose ();
                lbUserName = null;
            }
        }
    }
}