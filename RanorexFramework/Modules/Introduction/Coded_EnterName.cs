using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using MyTest1.Helpers;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace RanorexFramework.Modules.Introduction
{
    [TestModule("EB967F9D-D445-4706-8B04-7464A7E63E89", ModuleType.UserCode, 1)]
    public class Coded_EnterName : ITestModule
    {
        public Coded_EnterName()
        {
            // Required constructor
        }

        string _CodedEnterName = "";
        [TestVariable("43075dd5-aeec-4ba1-b612-90849bdad0cf")]
        public string CodedEnterName
        {
            get { return _CodedEnterName; }
            set { _CodedEnterName = value; }
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;

            // Repository
            var repo = RanorexFramework.Repository.RanorexFrameworkRepository.Instance;

            // Elements
            var txtFullName = repo.RxMainFrame.Introduction.TxtUserName;
            var txtFullNameInfo = repo.RxMainFrame.Introduction.TxtUserNameInfo;
            var btnSubmit = repo.RxMainFrame.Introduction.BtnSubmitUserName;
            var btnSubmitInfo = repo.RxMainFrame.Introduction.BtnSubmitUserNameInfo;

            // 🔹 Excel Data (NEW helper - ExcelDataReader)
            string sampleName = ExcelHelper.GetSingleValue("Sheet1", "Name");

            if (string.IsNullOrEmpty(sampleName))
                throw new Exception("Excel value for 'Name' is empty.");

            // =========================
            // STEP 1: Enter Name
            // =========================
            Report.Log(ReportLevel.Info, "Input", $"Entering name: {sampleName}", txtFullNameInfo);

            txtFullName.PressKeys(sampleName);

            // =========================
            // STEP 2: Click Submit
            // =========================
            Report.Log(ReportLevel.Info, "Click", "Click Submit button", btnSubmitInfo);

            btnSubmit.Click();
        }
    }
}