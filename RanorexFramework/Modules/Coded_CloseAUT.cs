/*
 * Created by Ranorex
 * User: Jos
 * Date: 7 May 2026
 * Time: 10:27 am
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace RanorexFramework.Teardown
{
    /// <summary>
    /// Description of Coded_CloseAUT.
    /// </summary>
    [TestModule("522AEC84-CCCE-40A4-8003-99974163B8F7", ModuleType.UserCode, 1)]
    public class Coded_CloseAUT : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Coded_CloseAUT()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        string _CloseAutProcessIDVar;

        /// <summary>
        /// Gets or sets the value of variable CloseAutProcessIDVar.
        /// </summary>
        [TestVariable("f51bebf5-6db3-4910-b78a-88d6c87520bb")]
        public string CloseAutProcessIDVar
        {
            get { return _CloseAutProcessIDVar; }
            set { _CloseAutProcessIDVar = value; }
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Host.Current.CloseApplication(int.Parse(CloseAutProcessIDVar), 500);
        }
    }
}
