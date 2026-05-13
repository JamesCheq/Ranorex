/*
 * Created by Ranorex
 * User: Jos
 * Date: 7 May 2026
 * Time: 9:59 am
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

namespace RanorexFramework.Setup
{
    /// <summary>
    /// Description of Coded_StartAUT.
    /// </summary>
    [TestModule("14245E6E-2FD1-4927-8671-699A7F1ACE25", ModuleType.UserCode, 1)]
    public class Coded_StartAUT : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Coded_StartAUT()
        {
        	StartAutProcessIDVar = "";
            // Do not delete - a parameterless constructor is required!
        }
        
        string _StartAutProcessIDVar;
        
        [TestVariable("37dc5c0a-997f-4e14-8b37-a17864c06e2f")]
        public string StartAutProcessIDVar
        {
            get { return _StartAutProcessIDVar; }
            set { _StartAutProcessIDVar = value; }
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
            
            string appPath = @"C:\Users\JamesFornis\Documents\Ranorex\RanorexStudio Projects\RanorexFramework\RanorexFramework\Applications\RxDemoApp.exe";
            
            StartAutProcessIDVar = ValueConverter.ToString(Host.Local.RunApplication(appPath, "", "", false));
        }
    }
}
